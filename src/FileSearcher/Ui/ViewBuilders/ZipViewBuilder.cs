using FileSearcher.Model.CriterionSchemas;
using FileSearcher.Model.Engine;
using FileSearcher.Ui.Entries;
using System;
using System.Collections.Generic;

namespace FileSearcher.Ui.ViewBuilders
{
    internal class ZipViewBuilder : IViewBuilder
    {
        public IEnumerable<IPathEntry> Build(Model.Engine.SearchResult entry, int entryIndex)
        {
            var context = entry.Metadata[typeof(NameAndZipCriterion)];
            var zipContext = (ZipCriterionContext)context;
            if (zipContext.Childs == null)
                throw new OperationCanceledException("Cannot get the entries from the metadata of file '" + entry.FileSystemInfo.FullName + "'.");

            if (zipContext.ArchiveNameIsMatch)
                yield return new PathZipEntry(entry.FileSystemInfo, null);

            if (zipContext.Childs.Count > 0)
            {
                foreach (var content in zipContext.Childs)
                    yield return new PathZipEntry(entry.FileSystemInfo, content);
            }
        }

        public Tuple<string, int>[] ColumnSizes
        {
            get
            {
                return new[]
                {
                    new Tuple<string, int>("File name", 250),
                    new Tuple<string, int>("Directory and location", -1)
                };
            }
        }
    }
}
