using System.IO;
using FileSearcher.Model.Engine;

namespace FileSearcher.Model.CriterionSchemas
{
    internal class AttributeCriterion : CriterionBase, ICriterion
    {
        private readonly FileAttributes _includedAttributes;
        private readonly FileAttributes _excludedAttributes;

        public AttributeCriterion(FileAttributes includedAttributes, FileAttributes excludedAttributes)
        {
            _includedAttributes = includedAttributes;
            _excludedAttributes = excludedAttributes;
        }

        public string Name { get { return "Attributes"; } }

        public CriterionWeight Weight { get { return CriterionWeight.Medium;} }

        public bool DirectorySupport { get { return true; } }

        public bool FileSupport { get { return true; } }

        public bool IsMatch(FileSystemInfo fileSystemInfo, ICriterionContext context)
        {
            return (fileSystemInfo.Attributes & _includedAttributes) == _includedAttributes
                && (fileSystemInfo.Attributes & _excludedAttributes) == 0;
        }
    }
}
