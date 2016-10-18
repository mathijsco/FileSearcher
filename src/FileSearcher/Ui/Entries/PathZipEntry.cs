using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace FileSearcher.Ui.Entries
{
    internal class PathZipEntry : PathEntry
    {
        private readonly string _internalName;

        public PathZipEntry(FileSystemInfo fileSystemInfo, string internalName)
            : base(fileSystemInfo)
        {
            _internalName = internalName;
        }

        public override ListViewItem BuildListViewItem()
        {
            var item = new ListViewItem(this.FileSystemInfo.FullName);
            item.SubItems.Add(_internalName);

            return item;
        }
    }
}
