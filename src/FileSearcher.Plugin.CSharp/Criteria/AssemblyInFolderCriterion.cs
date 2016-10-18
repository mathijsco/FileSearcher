using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FileSearcher.Model.Engine;

namespace FileSearcher.Plugin.CSharp.Criteria
{
    internal class AssemblyInFolderCriterion : ReferenceCriterionBase
    {
        private readonly string _folderLocation;

        public AssemblyInFolderCriterion(string folderLocation)
        {
            if (folderLocation == null) throw new ArgumentNullException("folderLocation");

            _folderLocation = folderLocation.TrimEnd('\\');
        }

        protected override bool IsMatch(string assemblyName, string fullHintPath)
        {
            return !string.IsNullOrEmpty(fullHintPath) && fullHintPath.StartsWith(_folderLocation + "\\", StringComparison.OrdinalIgnoreCase);
        }
    }
}
