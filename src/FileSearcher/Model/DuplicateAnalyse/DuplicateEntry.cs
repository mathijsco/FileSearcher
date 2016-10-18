using System;
using System.Collections.Generic;
using System.IO;

namespace FileSearcher.Model.DuplicateAnalyse
{
    internal sealed class DuplicateEntry : IEquatable<DuplicateEntry>
    {
        private const int BufferSize = 1024*32; // 32KB
        private const uint HashByteSize = 1024 * 32; // Default: 16

        private readonly DuplicatesContainer _container;
        private bool _hasHashOfFirstBytes;
        private int _hashOfFirstBytes;

        internal DuplicateEntry(DuplicatesContainer container, FileInfo rootEntry)
        {
            if (container == null) throw new ArgumentNullException("container");
            if (rootEntry == null) throw new ArgumentNullException("rootEntry");

            _container = container;
            this.FileInfos = new List<FileInfo>();
            this.FileInfos.Add(rootEntry);
        }

        public IList<FileInfo> FileInfos { get; private set; }

        public FileInfo RootInfo { get { return this.FileInfos[0]; } }

        public bool IsDuplicate { get { return this.FileInfos.Count > 1; } }

        public void Merge(DuplicateEntry otherEntry)
        {
            foreach (var file in otherEntry.FileInfos)
            {
                this.FileInfos.Add(file);
            }
        }

        public bool Equals(DuplicateEntry other)
        {
            if (other == null) return false;

            var info = this.RootInfo;
            var otherInfo = other.RootInfo;

            // Validate the items
            if (_container.CheckName && info.Name != otherInfo.Name)
                return false;
            if (_container.CheckSize && info.Length != otherInfo.Length)
                return false;
            if (_container.CheckContent && info.Length > 0 && !CompareFiles(this, other)) // Size must be larger than 0, otherwise opening file is waste of time.
                return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as DuplicateEntry);
        }

        public override int GetHashCode()
        {
            var info = this.RootInfo;
            int hashCode = 0;
            if (_container.CheckName)
                hashCode ^= info.Name.GetHashCode();
            if (_container.CheckSize)
                hashCode ^= info.Length.GetHashCode();

            return hashCode;
        }

        private static bool CompareFiles(DuplicateEntry file1, DuplicateEntry file2)
        {
            // Quick check if the hashes are not the same.
            if (file1._hasHashOfFirstBytes && file2._hasHashOfFirstBytes && file1._hashOfFirstBytes != file2._hashOfFirstBytes)
                return false;

            // If the file1 has no hash, but file2 has, switch the variables.
            if (!file1._hasHashOfFirstBytes && file2._hasHashOfFirstBytes)
            {
                var t = file1;
                file1 = file2;
                file2 = t;
            }


            var buffer1 = new byte[BufferSize];
            var buffer2 = new byte[BufferSize];
            bool firstRun = true;

            using (var stream2 = file2.RootInfo.OpenRead())
            using (var stream1 = new LazyDisposable<FileStream>(() => file1.RootInfo.OpenRead()))
            {
                int length2, length1;
                while ((length2 = stream2.Read(buffer2, 0, BufferSize)) > 0)
                {
                    // Only check the hashes on the first go.
                    if (firstRun)
                    {
                        // Calculate the hash of file 2
                        if (!file2._hasHashOfFirstBytes)
                        {
                            file2._hashOfFirstBytes = CalculateHasOfFirstBytes(buffer2, length2);
                            file2._hasHashOfFirstBytes = true;
                        }

                        // If file 1 has an has of the first bytes, use it.
                        if (file1._hasHashOfFirstBytes)
                        {
                            // Hashes do not match.
                            if (file1._hashOfFirstBytes != file2._hashOfFirstBytes)
                                return false;
                        }
                        firstRun = false;
                    }

                    // Start opening a stream for file 1s.
                    length1 = stream1.Instance.Read(buffer1, 0, BufferSize);

                    // Calculate the hash of file 1
                    if (!file1._hasHashOfFirstBytes)
                    {
                        file1._hashOfFirstBytes = CalculateHasOfFirstBytes(buffer1, length1);
                        file1._hasHashOfFirstBytes = true;

                        if (file1._hashOfFirstBytes != file2._hashOfFirstBytes)
                            return false;
                    }

                    // Length is different. This should never occur because it is already tested. Next is to compare the buffers.
                    if (length1 != length2 || !ByteArrayComparer.UnsafeCompare(buffer1, buffer2))
                        return false;
                }
            }

            return true;
        }


        private static int CalculateHasOfFirstBytes(byte[] firstBytes, int length)
        {
            int h = 0, n = 0;
            var lengthMax = Math.Min(HashByteSize, length);
            while (n < lengthMax)
            {
                h ^= (firstBytes[n++] << 24) | (firstBytes[n++] << 16) | (firstBytes[n++] << 8) | firstBytes[n++];
            }

            //var h = 0;
            //var lengthMax = Math.Min(HashByteSize, length);
            //for (int n = 0; n < lengthMax; )
            //{
            //    h ^= (firstBytes[n++] << 24) | (firstBytes[n++] << 16) | (firstBytes[n++] << 8) | firstBytes[n++];
            //}

            return h;
        }
    }
}
