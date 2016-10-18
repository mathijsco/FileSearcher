using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FileSearcher.Ui.Configuration;
using System.Collections.Specialized;

namespace FileSearcher.Helpers
{
    internal static class VisibleFilterHelper
    {
        public static StringCollection Serialize(IEnumerable<VisibleFilter> filterList)
        {
            var collection = new StringCollection();
            foreach (var filter in filterList)
            {
                collection.Add((int) filter.Filter + ";" + filter.Visible + ";" + filter.PluginId);
            }
            return collection;
        }

        public static IList<VisibleFilter> Deserialize(StringCollection stringCollection)
        {
            var collection = new Collection<VisibleFilter>();

            if (stringCollection == null || stringCollection.Count <= 0)
                return collection;

            foreach (var entry in stringCollection)
            {
                var split = entry.Split(';');
                collection.Add(new VisibleFilter((DefaultFilter)int.Parse(split[0]))
                {
                    Visible = bool.Parse(split[1]),
                    PluginId = string.IsNullOrWhiteSpace(split[2]) ? (Guid?)null : Guid.Parse(split[2])
                });
            }
            return collection;
        }
    }
}
