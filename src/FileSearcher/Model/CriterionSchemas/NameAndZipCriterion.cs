using FileSearcher.Model.Engine;
using Ionic.Zip;
using System;
using System.IO;
using System.Linq;

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
            // All found entries in the ZIP file.
            var myContext = (ZipCriterionContext)context;

            var isZip = !string.IsNullOrEmpty(fileSystemInfo.Extension) && fileSystemInfo.Extension.Equals(".zip", StringComparison.OrdinalIgnoreCase);
            if (isZip)
            {
                using (var zip = ZipFile.Read(fileSystemInfo.FullName))
                {
                    foreach (var entry in zip.EntryFileNames.Select(e => e.Replace('/', '\\').TrimEnd('\\')))
                    {
                        if (IsMatch(this.MatchFullPath ? Path.Combine(fileSystemInfo.FullName, entry) : Path.GetFileName(entry)))
                        {
                            myContext.Childs.Add(entry);
                        }
                    }
                }
            }

            // Normal match of file name
            myContext.ArchiveNameIsMatch = base.IsMatch(fileSystemInfo, context);
            return myContext.ArchiveNameIsMatch || myContext.Childs.Count > 0;
        }

        public override ICriterionContext BuildContext()
        {
            return new ZipCriterionContext();
        }
    }
}
