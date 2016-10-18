using System;
using System.Collections.Generic;
using FileSearcher.Model.Engine;
using FileSearcher.Ui.Entries;

namespace FileSearcher.Ui.ViewBuilders
{
    public interface IViewBuilder
    {
        IEnumerable<IPathEntry> Build(SearchResult entry, int entryIndex);

        Tuple<string, int>[] ColumnSizes { get; }
    }
}
