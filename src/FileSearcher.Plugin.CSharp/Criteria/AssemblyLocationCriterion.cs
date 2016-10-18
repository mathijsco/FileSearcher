using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FileSearcher.Model.Engine;

namespace FileSearcher.Plugin.CSharp.Criteria
{
    internal class AssemblyLocationCriterion : ReferenceCriterionBase
    {
        private readonly string _assemblyLocation;

        public AssemblyLocationCriterion(string assemblyLocation)
        {
            if (assemblyLocation == null) throw new ArgumentNullException("assemblyLocation");

            _assemblyLocation = assemblyLocation;
        }

        protected override bool IsMatch(string assemblyName, string fullHintPath)
        {
            return !string.IsNullOrEmpty(fullHintPath) && _assemblyLocation.Equals(fullHintPath, StringComparison.OrdinalIgnoreCase);
        }
    }
}
