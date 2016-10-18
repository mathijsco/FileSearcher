using System;
using System.IO;
using FileSearcher.Model.Engine;

namespace FileSearcher.Model.CriterionSchemas
{
    internal class ContentRegexCriterion : CriterionBase, ICriterion
    {
        private readonly string _regexText;
        private readonly bool _ignoreCase;

        public ContentRegexCriterion(string regexText, bool ignoreCase)
        {
            if (regexText == null) throw new ArgumentNullException("regexText");

            _regexText = regexText;
            _ignoreCase = ignoreCase;
        }

        public string Name { get { return "File content using regular expressions"; } }

        public CriterionWeight Weight { get { return CriterionWeight.Extreme;} }

        public bool DirectorySupport { get { return false; } }

        public bool FileSupport { get { return true; } }

        public bool IsMatch(FileSystemInfo fileSystemInfo, ICriterionContext context)
        {
            var fileInfo = (FileInfo) fileSystemInfo;
            throw new NotImplementedException();
        }
    }
}
