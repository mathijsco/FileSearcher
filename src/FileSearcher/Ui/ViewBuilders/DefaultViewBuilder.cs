using System;
using System.Collections.Generic;
using FileSearcher.Ui.Entries;

namespace FileSearcher.Ui.ViewBuilders
{
    internal class DefaultViewBuilder : IViewBuilder
    {
        public IEnumerable<IPathEntry> Build(Model.Engine.SearchResult entry, int entryIndex)
        {
            return new[] {new PathEntry(entry.FileSystemInfo)};
        }

        public Tuple<string, int>[] ColumnSizes
        {
            get
            {
                return new[] { new Tuple<string, int>("Results", -1)  };
            }
        }
    }
}
