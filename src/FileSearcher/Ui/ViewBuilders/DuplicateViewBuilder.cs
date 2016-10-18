using System;
using System.Collections.Generic;
using FileSearcher.Ui.Entries;
using FileSearcher.Model.Contexts;
using FileSearcher.Model.CriterionSchemas;

namespace FileSearcher.Ui.ViewBuilders
{
    internal class DuplicateViewBuilder : IViewBuilder
    {
        public IEnumerable<IPathEntry> Build(Model.Engine.SearchResult entry, int entryIndex)
        {
            bool groupIndicator = (entryIndex & 1) == 1;

            var context = entry.Metadata[typeof(DuplicateFileCriterion)];
            var entries = ((DuplicateFileCriterionContext)context).Childs;
            if (entries == null)
                throw new OperationCanceledException("Cannot get the entries from the metadata of file '" + entry.FileSystemInfo.FullName + "'.");

            yield return new PathDuplicateEntry(entry.FileSystemInfo, groupIndicator);
            foreach (var content in entries)
            {
                yield return new PathDuplicateEntry(content, groupIndicator);
            }
        }

        public Tuple<string, int>[] ColumnSizes
        {
            get
            {
                return new[]
                {
                    new Tuple<string, int>("File name", 250),
                    new Tuple<string, int>("Directory", -1)
                };
            }
        }
    }
}
