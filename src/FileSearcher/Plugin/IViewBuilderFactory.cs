using FileSearcher.Ui.ViewBuilders;

namespace FileSearcher.Plugin
{
    public interface IViewBuilderFactory
    {
        IViewBuilder CreateViewBuilder(ICriterionPlugin criteria);
    }
}
