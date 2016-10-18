using System;
using FileSearcher.Ui.Configuration;

namespace FileSearcher.Ui.Entries
{
    internal class VisibleFilterEntry
    {
        public VisibleFilter Filter { get; private set; }
        public string Description { get; private set; }

        public VisibleFilterEntry(VisibleFilter filter, string description)
        {
            if (filter == null) throw new ArgumentNullException("filter");
            if (description == null) throw new ArgumentNullException("description");

            Filter = filter;
            Description = description;
        }

        public override string ToString()
        {
            return this.Description;
        }
    }
}
