using System;
using System.Windows.Forms;
using System.IO;

namespace FileSearcher.Ui.Entries
{
    internal class PathEntry : IPathEntry
    {
        private readonly FileSystemInfo _fileSystemInfo;

        public PathEntry(FileSystemInfo fileSystemInfo)
        {
            if (fileSystemInfo == null) throw new ArgumentNullException("fileSystemInfo");

            _fileSystemInfo = fileSystemInfo;
        }

        public FileSystemInfo FileSystemInfo
        {
            get { return _fileSystemInfo; }
        }

        public bool IsDirectory
        {
            get { return _fileSystemInfo is DirectoryInfo; }
        }

        public virtual ListViewItem BuildListViewItem()
        {
            var name = _fileSystemInfo.FullName;
            if (this.IsDirectory)
                name = string.Concat("[", name, "]");
            return new ListViewItem(name);
        }
    }
}
