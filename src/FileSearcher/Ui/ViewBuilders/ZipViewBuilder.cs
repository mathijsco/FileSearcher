using System;
using System.Collections.Generic;
using FileSearcher.Ui.Entries;
using FileSearcher.Model.Engine;
using FileSearcher.Model.CriterionSchemas;

namespace FileSearcher.Ui.ViewBuilders
{
    internal class ZipViewBuilder : IViewBuilder
    {
        public IEnumerable<IPathEntry> Build(Model.Engine.SearchResult entry, int entryIndex)
        {
            var context = entry.Metadata[typeof(NameAndZipCriterion)];
            var entries = ((ZipCriterionContext)context).Childs;
            if (entries == null)
                throw new OperationCanceledException("Cannot get the entries from the metadata of file '" + entry.FileSystemInfo.FullName + "'.");

            if (entries.Count > 0)
            {
                foreach (var content in entries)
                {
                    yield return new PathZipEntry(entry.FileSystemInfo, content);
                }
            }
            else
                yield return new PathZipEntry(entry.FileSystemInfo, null);
        }

        public Tuple<string, int>[] ColumnSizes
        {
            get
            {
                return new[]
                {
                    new Tuple<string, int>("File name", -1),
                    new Tuple<string, int>("Internal path", -1)
                };
            }
        }
    }
}
