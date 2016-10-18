using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSearcher.Model.DuplicateAnalyse
{
    /// <summary>
    /// Class that contains all the duplicates and validates whether it is a duplicate.
    /// </summary>
    internal class DuplicatesContainer
    {
        private readonly bool _checkName;
        private readonly bool _checkSize;
        private readonly bool _checkContent;
        /// <summary>
        /// Bucket with all the <see cref="DuplicateEntry"/> items.
        /// KEY: Hash code of the entry.
        /// VALUE: IList&lt;DuplicateEntry&gt;.
        /// </summary>
        private readonly Hashtable _bucket;

        internal DuplicatesContainer(bool checkName, bool checkSize, bool checkContent)
        {
            if (checkContent && !checkSize)
                throw new ArgumentException("Cannot check the content is the size is not checked.");

            _checkName = checkName;
            _checkSize = checkSize;
            _checkContent = checkContent;
            _bucket = new Hashtable();


            /* Container:
             * Should have a single array with the items.
             * A hash code can be used for initial find. (Based on name and size).
             * After the hash is the same, do an equals. If true, then add it to the DuplicateEntry as a FileSystemInfo.
             */
        }

        internal bool CheckName { get { return _checkName; } }
        internal bool CheckSize { get { return _checkSize; } }
        internal bool CheckContent { get { return _checkContent; } }

        /// <summary>
        /// Adds a new file to this duplicate container. The file is directly checked if it is a duplicate or not.
        /// </summary>
        /// <param name="fileSystemInfo"></param>
        /// <returns>True if the entry is a duplicate.</returns>
        public bool Add(FileInfo fileSystemInfo)
        {
            var newEntry = new DuplicateEntry(this, fileSystemInfo);

            var collection = GetCollectionFor(newEntry);
            // Check for equal files.
            foreach (var entry in collection)
            {
                if (entry.Equals(newEntry))
                {
                    entry.Merge(newEntry);
                    return true;
                }
            }
            // No equal file, so add it as a new one.
            collection.Add(newEntry);
            return false;
        }

        public IEnumerable<DuplicateEntry> RetreiveDuplicates()
        {
            return _bucket.Values.Cast<IList<DuplicateEntry>>().SelectMany(s => s).Where(f => f.IsDuplicate);
        }

        private IList<DuplicateEntry> GetCollectionFor(DuplicateEntry newEntry)
        {
            var hashCode = newEntry.GetHashCode();
            var entryCollection = _bucket[hashCode] as IList<DuplicateEntry>;
            if (entryCollection == null)
            {
                entryCollection = new List<DuplicateEntry>();
                _bucket[hashCode] = entryCollection;
            }
            return entryCollection;
        }
    }
}
