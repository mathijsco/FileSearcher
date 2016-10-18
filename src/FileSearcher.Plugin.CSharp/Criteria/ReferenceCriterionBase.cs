using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using FileSearcher.Model.Engine;

namespace FileSearcher.Plugin.CSharp.Criteria
{
    internal abstract class ReferenceCriterionBase : CriterionBase, ICriterionPlugin
    {
        public string Name { get { return ".csproj assembly references"; } }

        public CriterionWeight Weight { get {return CriterionWeight.Heavy; } }

        public bool DirectorySupport { get { return false; } }

        public bool FileSupport { get { return true; } }

        public bool IsMatch(FileSystemInfo fileSystemInfo, ICriterionContext context)
        {
            if (!fileSystemInfo.Extension.Equals(".csproj", StringComparison.OrdinalIgnoreCase) && !fileSystemInfo.Extension.Equals(".vbproj", StringComparison.OrdinalIgnoreCase))
                return false;

            var directory = Path.GetDirectoryName(fileSystemInfo.FullName);
            if (directory == null)
                return false;

            var xml = XDocument.Load(fileSystemInfo.FullName);
            var manager = new XmlNamespaceManager(new NameTable());
            manager.AddNamespace("ns", "http://schemas.microsoft.com/developer/msbuild/2003");

            var elements = xml.XPathSelectElements("//ns:Project/ns:ItemGroup/ns:Reference", manager);
            foreach (var reference in elements)
            {
                var assemblyName = (string)reference.Attribute("Include");
                var location = (string)reference.Element("{http://schemas.microsoft.com/developer/msbuild/2003}HintPath");
                var fullHintPath = location != null ? Path.GetFullPath(Path.Combine(directory, location)) : null;

                if (IsMatch(assemblyName, fullHintPath))
                    return true;
            }

            return false;
        }

        protected abstract bool IsMatch(string assemblyName, string fullHintPath);
    }
}
