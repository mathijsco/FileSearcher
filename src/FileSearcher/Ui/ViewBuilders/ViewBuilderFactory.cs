using System.Collections.Generic;
using FileSearcher.Model.Engine;
using FileSearcher.Model.CriterionSchemas;
using FileSearcher.Plugin;
using System.Linq;

namespace FileSearcher.Ui.ViewBuilders
{
    internal static class ViewBuilderFactory
    {
        public static IViewBuilder Create(IEnumerable<ICriterion> criteria)
        {
            var criteriaList = criteria as IList<ICriterion> ?? criteria.ToList();

            IViewBuilder builder = null;
            var currentWeight = CriterionWeight.None;

            // Get the local criterion.
            foreach (var criterion in criteriaList.Where(c => !(c is ICriterionPlugin)))
            {
                var b = GetLocalViewBuilder(criterion);
                if (b != null)
                {
                    if (criterion.Weight >= currentWeight)
                    {
                        currentWeight = criterion.Weight;
                        builder = b;
                    }
                }
            }

            // Get them from the plugins
            foreach (var factory in Plugins.Loaded().Select(p => p.GetViewBuilderFactory()).Where(f => f != null))
            {
                foreach (var criterion in criteriaList.OfType<ICriterionPlugin>())
                {
                    var b = factory.CreateViewBuilder(criterion);
                    if (b != null)
                    {
                        if (criterion.Weight >= currentWeight)
                        {
                            currentWeight = criterion.Weight;
                            builder = b;
                        }
                    }
                }
            }

            return builder ?? new DefaultViewBuilder();
        }

        private static IViewBuilder GetLocalViewBuilder(ICriterion criterion)
        {
            if (criterion is DuplicateFileCriterion)
                return new DuplicateViewBuilder();
            else if (criterion is NameAndZipCriterion)
                return new ZipViewBuilder();
            return null;
        }
    }
}
