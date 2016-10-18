using System;
using System.IO;
using FileSearcher.Model.Engine;

namespace FileSearcher.Model.CriterionSchemas
{
    internal class SizeCriterion : CriterionBase, ICriterion
    {
        private readonly long? _minLengthInBytes;
        private readonly long? _maxLengthInBytes;

        public SizeCriterion(long? minLengthInBytes, long? maxLengthInBytes)
        {
            if (minLengthInBytes != null && minLengthInBytes < 0)
                throw new ArgumentOutOfRangeException("minLengthInBytes", "The specified minimum length cannot be less than 0 bytes.");
            if (maxLengthInBytes != null && maxLengthInBytes < 0)
                throw new ArgumentOutOfRangeException("maxLengthInBytes", "The specified maximum length cannot be less than 0 bytes.");
            if (minLengthInBytes == null && maxLengthInBytes == null)
                throw new ArgumentException("Cannot have both minimum and maximum values set as null.");
            if (minLengthInBytes != null && maxLengthInBytes != null && minLengthInBytes > maxLengthInBytes)
                throw new ArgumentException("The maximum value must be greater than or equal to the minimum.");

            _minLengthInBytes = minLengthInBytes;
            _maxLengthInBytes = maxLengthInBytes;
        }

        public string Name { get { return "File sizes"; } }

        public CriterionWeight Weight { get { return CriterionWeight.Medium; } }

        public bool DirectorySupport { get { return false; } }

        public bool FileSupport { get { return true; } }

        public bool IsMatch(FileSystemInfo fileSystemInfo, ICriterionContext context)
        {
            var file = (FileInfo) fileSystemInfo;
            return (_minLengthInBytes == null || file.Length >= _minLengthInBytes.Value)
                && (_maxLengthInBytes == null || file.Length <= _maxLengthInBytes.Value);
        }
    }
}
