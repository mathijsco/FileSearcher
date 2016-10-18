using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using FileSearcher.Plugin;
using FileSearcher.Ui.Configuration;
using FileSearcher.Ui.Entries;

namespace FileSearcher.Ui
{
    internal partial class SettingsForm : Form
    {
        private readonly IList<VisibleFilter> _visibleFilters;

        public SettingsForm(IList<VisibleFilter> visibleFilters)
        {
            _visibleFilters = visibleFilters;
            if (visibleFilters == null) throw new ArgumentNullException("visibleFilters");

            InitializeComponent();
            LoadFilters();
        }

        public IList<VisibleFilter> RetrieveVisibleFilters()
        {
            var list = new Collection<VisibleFilter>();
            list.Add(new VisibleFilter(DefaultFilter.Basic) { Visible = true});
            list.Add(new VisibleFilter(DefaultFilter.Content) { Visible = IsChecked(DefaultFilter.Content) });
            list.Add(new VisibleFilter(DefaultFilter.Dates) { Visible = IsChecked(DefaultFilter.Dates) });
            list.Add(new VisibleFilter(DefaultFilter.SizeAndAttributes) { Visible = IsChecked(DefaultFilter.SizeAndAttributes) });
            list.Add(new VisibleFilter(DefaultFilter.Duplicates) { Visible = IsChecked(DefaultFilter.Duplicates) });

            foreach (var p in Plugins.All())
            {
                list.Add(new VisibleFilter(DefaultFilter.Plugin) { Visible = IsChecked(DefaultFilter.Plugin, p.PluginId), PluginId = p.PluginId});
            }

            return list;
        }

        private void LoadFilters()
        {
            //BuildFilterEntry("Basic", DefaultFilter.Basic);
            BuildFilterEntry("Content", DefaultFilter.Content);
            BuildFilterEntry("Dates", DefaultFilter.Dates);
            BuildFilterEntry("Size and attributes", DefaultFilter.SizeAndAttributes);
            BuildFilterEntry("Duplicates", DefaultFilter.Duplicates);

            foreach (var p in Plugins.Loaded())
            {
                BuildFilterEntry(string.Concat(p.TabTitle, " (plugin)"), DefaultFilter.Plugin, p.PluginId);
            }
        }

        private void BuildFilterEntry(string description, DefaultFilter filter, Guid? pluginId = null)
        {
            // Find the proper DefaultFilter object for this item.
            var foundFilter = _visibleFilters.FirstOrDefault(f => f.Filter == filter && (f.Filter != DefaultFilter.Plugin || f.PluginId == pluginId));
            // Create the default settings
            if (foundFilter == null)
                foundFilter = filter == DefaultFilter.Plugin ? new VisibleFilter(filter) {PluginId = pluginId, Visible = true} : new VisibleFilter(filter) { Visible = true };

            // Add the entry to the list
            var entry = new VisibleFilterEntry(foundFilter, description);
            lstFilters.Items.Add(entry, foundFilter.Visible);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private bool IsChecked(DefaultFilter filter, Guid? pluginId = null)
        {
            return lstFilters.CheckedItems.Cast<VisibleFilterEntry>().Any(e => e.Filter.Filter == filter && e.Filter.PluginId == pluginId);
        }
    }
}
