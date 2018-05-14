using System.IO;
using System.Windows.Forms;

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
            // Normal file
            if (_internalName == null)
                return base.BuildListViewItem();

            // ZIP content
            var name = Path.GetFileName(_internalName);
            var internalPath = Path.GetDirectoryName(_internalName);

            var item = new ListViewItem(name);
            item.SubItems.Add(Path.Combine(this.FileSystemInfo.FullName, internalPath));

            return item;
        }
    }
}
