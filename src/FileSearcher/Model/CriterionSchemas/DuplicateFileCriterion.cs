using System.Collections.Generic;
using System.IO;
using System.Linq;
using FileSearcher.Model.DuplicateAnalyse;
using FileSearcher.Model.Engine;
using FileSearcher.Model.Contexts;
using System;

namespace FileSearcher.Model.CriterionSchemas
{
    internal class DuplicateFileCriterion : CriterionBase, ICriterion, IPostProcessingCriterion
    {
        private readonly DuplicatesContainer _container;

        public DuplicateFileCriterion(bool checkName, bool checkSize, bool checkContent)
        {
            _container = new DuplicatesContainer(checkName, checkSize, checkContent);
        }

        public string Name { get { return "Duplicate checks"; } }

        public CriterionWeight Weight { get { return CriterionWeight.Extreme; } }

        public bool DirectorySupport { get { return false; } }

        public bool FileSupport { get { return true; } }

        public bool IsMatch(FileSystemInfo fileSystemInfo, ICriterionContext context)
        {
            return _container.Add((FileInfo)fileSystemInfo);
        }

        public override ICriterionContext BuildContext()
        {
            // Do not return any context, because it is useless here.
            return null;
        }

        public IEnumerable<SearchResult> PostProcess()
        {
            // Skip the first record, because that is teh same one as a.RootInfo.
            return _container.RetreiveDuplicates().Select(a => new SearchResult(a.RootInfo)
            {
                Metadata = new Dictionary<Type, ICriterionContext>
                {
                    {
                        this.GetType(),
                        new DuplicateFileCriterionContext(a.FileInfos.Cast<FileSystemInfo>().Skip(1).ToList())
                    }
                }
            });
        }

    }
}
