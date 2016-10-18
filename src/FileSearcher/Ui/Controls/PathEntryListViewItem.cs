using System;
using System.Windows.Forms;
using FileSearcher.Ui.Entries;

namespace FileSearcher.Ui.Controls
{
    internal class PathEntryListViewItem : ListViewItem
    {
        public PathEntryListViewItem(IPathEntry value)
        {
            if (value == null) throw new ArgumentNullException("value");

            this.Value = value;
            this.Text = this.Value.ToString();
        }

        public IPathEntry Value { get; private set; }
    }
}
