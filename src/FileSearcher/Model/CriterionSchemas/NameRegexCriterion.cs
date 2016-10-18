using System;
using System.IO;
using System.Text.RegularExpressions;
using FileSearcher.Model.Engine;

namespace FileSearcher.Model.CriterionSchemas
{
    internal class NameRegexCriterion : CriterionBase, ICriterion
    {
        private readonly string _regularExpression;
        private readonly bool _ignoreCase;
        private readonly bool _matchFullPath;
        private Regex _cachedRegex;

        public NameRegexCriterion(string regularExpression, bool ignoreCase, bool matchFullPath)
        {
            if (regularExpression == null) throw new ArgumentNullException("regularExpression");
            _regularExpression = regularExpression;
            _ignoreCase = ignoreCase;
            _matchFullPath = matchFullPath;
        }

        public string Name { get { return "File and directory names using regular expressions"; } }

        public CriterionWeight Weight
        {
            get { return CriterionWeight.None; }
        }

        public bool DirectorySupport
        {
            get { return true; }
        }

        public bool FileSupport
        {
            get { return true; }
        }

        public bool IsMatch(FileSystemInfo fileSystemInfo, ICriterionContext context)
        {
            return IsMatch(_matchFullPath ? fileSystemInfo.FullName : fileSystemInfo.Name);
        }

        protected virtual bool IsMatch(string fileName)
        {
            if (_cachedRegex == null)
                _cachedRegex = new Regex(_regularExpression, RegexOptions.Compiled | (_ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None));
            return _cachedRegex.IsMatch(fileName);
        }
    }
}
