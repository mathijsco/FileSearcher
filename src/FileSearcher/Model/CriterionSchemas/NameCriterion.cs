using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using FileSearcher.Model.Engine;

namespace FileSearcher.Model.CriterionSchemas
{
    internal class NameCriterion : CriterionBase, ICriterion
    {
        // Check if there is a * or ? inside an existing word
        private static readonly Regex LikeRegex = new Regex(@"(\S[*?]\S)|([*?])", RegexOptions.Compiled);
        private static readonly string StarWildcard = Regex.Escape("*");
        private static readonly string QuestionWildcard = Regex.Escape("?");

        private Func<string, bool>[][] _matches;

        private readonly bool _ignoreCasing;
        protected readonly bool MatchFullPath;

        public NameCriterion(string value, bool ignoreCasing, bool matchFullPath)
        {
            if (value == null) throw new ArgumentNullException("value");

            _ignoreCasing = ignoreCasing;
            this.MatchFullPath = matchFullPath;
            BuildMatches(value);
        }

        public string Name { get { return "File and directory names"; } }

        public virtual CriterionWeight Weight
        {
            get { return CriterionWeight.None; }
        }

        public virtual bool DirectorySupport
        {
            get { return true; }
        }

        public virtual bool FileSupport
        {
            get { return true; }
        }

        public virtual bool IsMatch(FileSystemInfo fileSystemInfo, ICriterionContext context)
        {
            var name = this.MatchFullPath ? fileSystemInfo.FullName : fileSystemInfo.Name;
            return IsMatch(name);
        }

        protected bool IsMatch(string filePath)
        {
            foreach (var group in _matches)
            {
                var l = filePath.LastIndexOfAny(new[] { '/', '\\' });
                var isMatch = group.All(g => g(filePath))
                    && (l == -1 || group.Any(g => g(filePath.Substring(l))));

                if (isMatch) return true;
            }
            return false;
        }

        private void BuildMatches(string value)
        {
            var orStatements = new List<Func<string, bool>[]>(); ;

            var split = value.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in split)
            {
                var words = item.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var andStatements = new List<Func<string, bool>>();

                foreach (var word in words)
                {
                    var likeResult = LikeRegex.Match(word);

                    // Build regex for a like statement
                    if (likeResult.Success && likeResult.Groups[1].Success)
                    {
                        var valueRegex = Regex.Escape(word)
                               .Replace(QuestionWildcard, @"\w{1}")
                               .Replace(StarWildcard, @"\w*");
                        var regex = new Regex(valueRegex, RegexOptions.Compiled | (_ignoreCasing ? RegexOptions.IgnoreCase : RegexOptions.None));

                        andStatements.Add((filePath) => regex.IsMatch(filePath));
                    }
                    else
                    {
                        var w = word;
                        if (likeResult.Success && likeResult.Groups[2].Success)
                            w = w.Replace("*", "").Replace("*", "");
                        andStatements.Add((filePath) => filePath.IndexOf(w, _ignoreCasing ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal) >= 0);
                    }
                }

                // Add the AND statement
                orStatements.Add(andStatements.ToArray());
            }

            _matches = orStatements.ToArray();
        }
    }
}
