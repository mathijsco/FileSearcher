using System;
using System.Linq;
using FileSearcher.Model.Engine;
using System.IO;
using Ionic.Zip;
using System.Collections.ObjectModel;

namespace FileSearcher.Model.CriterionSchemas
{
    internal class NameAndZipCriterion : NameCriterion
    {
        public NameAndZipCriterion(string value, bool ignoreCasing, bool matchFullPath)
            : base(value, ignoreCasing, matchFullPath)
        {
        }

        public override CriterionWeight Weight
        {
            get { return CriterionWeight.Light; }
        }

        public override bool IsMatch(FileSystemInfo fileSystemInfo, ICriterionContext context)
        {
            // Normal match
            if (base.IsMatch(fileSystemInfo, context))
                return true;

            // Should be ending with .ZIP
            if (string.IsNullOrEmpty(fileSystemInfo.Extension) || !fileSystemInfo.Extension.Equals(".zip", StringComparison.OrdinalIgnoreCase))
                return false;

            // All found entries in the ZIP file.
            var myContext = (ZipCriterionContext)context;

            using (var zip = ZipFile.Read(fileSystemInfo.FullName))
            {
                foreach (var entry in zip.EntryFileNames.Select(e => e.Replace('/', '\\')))
                {
                    if (IsMatch(this.MatchFullPath ? Path.Combine(fileSystemInfo.FullName, entry) : Path.GetFileName(entry)))
                    {
                        myContext.Childs.Add(entry);
                    }
                }
            }

            return myContext.Childs.Count > 0;
        }

        public override ICriterionContext BuildContext()
        {
            return new ZipCriterionContext();
        }
    }
}
