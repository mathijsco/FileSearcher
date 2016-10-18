using System;

namespace FileSearcher.Ui.Configuration
{
    internal sealed class VisibleFilter
    {
        public VisibleFilter(DefaultFilter filter)
        {
            this.Filter = filter;
        }

        public DefaultFilter Filter { get; private set; }

        public bool Visible { get; set; }

        public Guid? PluginId { get; set; }
    }
}
