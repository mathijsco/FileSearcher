using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;

namespace FileSearcher.Plugin.PsExecutable
{
    public class PsExecutablePlugin : IPluginFacade
    {
        private PsExecutableTabPage _tabPage;

        public Guid PluginId { get { return new Guid("8e227f48-2c31-4e49-ba1c-35cb5614926f"); } }

        public string TabTitle { get { return "PS1 script"; } }

        public UserControl BuildTabPage()
        {
            return _tabPage ?? (_tabPage = new PsExecutableTabPage());
        }

        public ICriterionPlugin[] GetCriterion()
        {
            if (_tabPage == null)
                throw new InvalidOperationException("Cannot get the options if the tab is not yet generated.");

            var list = new Collection<ICriterionPlugin>();
            if (_tabPage.ScriptEnabled && !string.IsNullOrEmpty(_tabPage.ScriptPath))
            {
                list.Add(new PsScriptCriterion(_tabPage.ScriptPath));
            }
            return list.ToArray();
        }

        public IViewBuilderFactory GetViewBuilderFactory()
        {
            return null;
        }
    }
}
