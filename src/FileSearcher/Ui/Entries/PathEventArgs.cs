using System;

namespace FileSearcher.Ui.Entries
{
    internal class PathEventArgs : EventArgs
    {
        private readonly PathEntry _entry;

        public PathEventArgs(PathEntry entry)
        {
            if (entry == null) throw new ArgumentNullException("entry");

            _entry = entry;
        }

        public PathEntry Entry
        {
            get { return _entry; }
        }
    }
}
