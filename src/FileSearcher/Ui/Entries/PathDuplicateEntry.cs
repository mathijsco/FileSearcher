using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace FileSearcher.Ui.Entries
{
    internal class PathDuplicateEntry : PathEntry
    {
        private readonly bool _highlight;

        public PathDuplicateEntry(FileSystemInfo fileSystemInfo, bool highlight)
            : base(fileSystemInfo)
        {
            _highlight = highlight;
        }
        
        public override ListViewItem BuildListViewItem()
        {
            var item = new ListViewItem(this.FileSystemInfo.Name);
            item.SubItems.Add(Path.GetDirectoryName(this.FileSystemInfo.FullName));

            if (_highlight)
                item.BackColor = SystemColors.Info;

            return item;
        }
    }
}
