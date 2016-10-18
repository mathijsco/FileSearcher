using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FileSearcher.Plugin.CSharp
{
    internal class DotNetOptions
    {
        public AssemblyName AssemblyName { get; set; }

        public string AssemblyPath { get; set; }

        public string AssembliesFolder { get; set; }
    }
}
