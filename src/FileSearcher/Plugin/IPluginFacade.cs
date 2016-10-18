using System;
using System.Windows.Forms;
namespace FileSearcher.Plugin
{
    public interface IPluginFacade
    {
        Guid PluginId { get; }

        string TabTitle { get; }

        UserControl BuildTabPage();

        ICriterionPlugin[] GetCriterion();

        IViewBuilderFactory GetViewBuilderFactory();
    }
}
