using System;
using System.IO;

namespace FileSearcher.Model.Engine
{
    public class SearchException
    {
        private readonly FileSystemInfo _fileSystemInfo;
        private readonly Exception _originalException;
        private readonly string _friendlyDescription;

        public SearchException(FileSystemInfo fileSystemInfo, Exception originalException, string friendlyDescription)
        {
            if (fileSystemInfo == null) throw new ArgumentNullException("fileSystemInfo");
            if (originalException == null) throw new ArgumentNullException("originalException");
            if (friendlyDescription == null) throw new ArgumentNullException("friendlyDescription");

            _fileSystemInfo = fileSystemInfo;
            _originalException = originalException;
            _friendlyDescription = friendlyDescription;
        }

        public Exception OriginalException
        {
            get { return _originalException; }
        }

        public string FriendlyDescription
        {
            get { return _friendlyDescription; }
        }

        public FileSystemInfo FileSystemInfo
        {
            get { return _fileSystemInfo; }
        }
    }
}
