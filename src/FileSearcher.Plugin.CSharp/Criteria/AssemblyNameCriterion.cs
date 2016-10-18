using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using FileSearcher.Model.Engine;

namespace FileSearcher.Plugin.CSharp.Criteria
{
    internal class AssemblyNameCriterion : ReferenceCriterionBase
    {
        private readonly AssemblyName _assemblyName;

        public AssemblyNameCriterion(AssemblyName assemblyName)
        {
            if (assemblyName == null) throw new ArgumentNullException("assemblyName");

            _assemblyName = assemblyName;
        }

        protected override bool IsMatch(string assemblyName, string fullHintPath)
        {
            // Hard pointer to a file
            if (fullHintPath != null)
            {
                if (!File.Exists(fullHintPath)) return false;

                var name = AssemblyName.GetAssemblyName(fullHintPath);
                if (AssemblyName.ReferenceMatchesDefinition(name, _assemblyName))
                    return true;
            }
            // GAC or BIN
            else
            {
                if (AssemblyName.ReferenceMatchesDefinition(new AssemblyName(assemblyName), _assemblyName))
                    return true;
            }
            return false;
        }
    }
}
