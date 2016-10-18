using System.IO;
using System.Windows.Forms;

namespace FileSearcher.Ui.Entries
{
    public interface IPathEntry
    {
        FileSystemInfo FileSystemInfo { get; }
        
        bool IsDirectory { get; }

        ListViewItem BuildListViewItem();
    }
}
