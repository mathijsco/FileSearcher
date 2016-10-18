using System;
using System.Collections.Generic;
using FileSearcher.Plugin.CSharp.Criteria;
using System.Windows.Forms;

namespace FileSearcher.Plugin.CSharp
{
    public class DotNetPlugin : IPluginFacade
    {
        private DotNetTabPage _tabPage;

        public Guid PluginId { get { return new Guid("f8bc1486-3613-45f6-89fb-69ef58d45b51"); } }

        public string TabTitle { get { return ".NET projects"; } }

        public UserControl BuildTabPage()
        {
            return _tabPage ?? (_tabPage = new DotNetTabPage());
        }

        public ICriterionPlugin[] GetCriterion()
        {
            if (_tabPage == null)
                throw new InvalidOperationException("Cannot get the options if the tab is not yet generated.");

            var list = new List<ICriterionPlugin>();

            var options = _tabPage.GetOptions();
            if (options.AssemblyName != null)
                list.Add(new AssemblyNameCriterion(options.AssemblyName));
            else if (!string.IsNullOrEmpty(options.AssemblyPath))
                list.Add(new AssemblyLocationCriterion(options.AssemblyPath));
            else if (!string.IsNullOrEmpty(options.AssembliesFolder))
                list.Add(new AssemblyInFolderCriterion(options.AssembliesFolder));

            return list.ToArray();
        }

        public IViewBuilderFactory GetViewBuilderFactory()
        {
            return null;
        }
    }
}
