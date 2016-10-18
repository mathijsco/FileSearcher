using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileSearcher.Helpers;
using FileSearcher.Model.EncodingDetection;
using FileSearcher.Model.Engine;
using FileSearcher.Model.Entities;
using FileSearcher.Properties;
using FileSearcher.Ui.Configuration;
using FileSearcher.Ui.Entries;
using System.Diagnostics;
using FileSearcher.Plugin;
using System.Text.RegularExpressions;
using System.Globalization;
using FileSearcher.Ui.ViewBuilders;

namespace FileSearcher.Ui
{
    internal partial class MainForm : Form
    {
        private SearchEngine _searchEngine;
        private readonly IList<TabPage> _tabBucket;
        private ExceptionsForm _exceptionsForm;
        private bool _resultsViewIsUpdated = false;

        public MainForm(string startPath)
        {
            InitializeComponent();
            this.Icon = Resources.Icon;
            _tabBucket = new Collection<TabPage>();

            // Load favorites
            if (Settings.Default.FolderFavorites != null)
                cmbFolder.Items.AddRange(Settings.Default.FolderFavorites.Cast<object>().ToArray());

            if (!string.IsNullOrEmpty(startPath))
            {
                //TODO: Resolve strange GUIDS in paths, like libraries.
                if (startPath.StartsWith("::"))
                    MessageBox.Show(@"Finding files has no support for searching in libraries or other system folders.\r\nPlease use the search tool directly on the folder or choose it in the directory picker.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    cmbFolder.Text = startPath;
            }
            if (string.IsNullOrEmpty(cmbFolder.Text))
                cmbFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            chkFolderFavorites.Font = new Font("Wingdings 2", chkFolderFavorites.Font.Size);

            cmbSizeOperator.SelectedIndex = 0; // +/-
            cmbSizeMultiplier.SelectedIndex = 2; // MB
            cmbDateOlderMultiplier.SelectedIndex = 2; // days

            // Add tags to the tabs so we can find it back.
            tabContent.Tag = new VisibleFilter(DefaultFilter.Content) { Visible = true };
            tabDates.Tag = new VisibleFilter(DefaultFilter.Dates) { Visible = true };
            tabOthers.Tag = new VisibleFilter(DefaultFilter.SizeAndAttributes) { Visible = true };
            tabDuplicates.Tag = new VisibleFilter(DefaultFilter.Duplicates) { Visible = true };
            _tabBucket.Add(tabContent);
            _tabBucket.Add(tabDates);
            _tabBucket.Add(tabOthers);
            _tabBucket.Add(tabDuplicates);

            LoadPlugins();
            ApplyVisibleTabs(VisibleFilterHelper.Deserialize(Settings.Default.VisibleFilters));

            this.Shown += (sender, args) => cmbCriteria.Focus();
        }

        private void LoadPlugins()
        {
            foreach (var plugin in Plugins.All())
            {
                var page = new TabPage(plugin.TabTitle) {UseVisualStyleBackColor = true};
                var panel = new Panel {Dock = DockStyle.Fill, Padding = new Padding(3) };
                page.Tag = new VisibleFilter(DefaultFilter.Plugin) {PluginId = plugin.PluginId, Visible = true};

                var control = plugin.BuildTabPage();
                control.Dock = DockStyle.Fill;
                panel.Controls.Add(control);
                page.Controls.Add(panel);

                _tabBucket.Add(page);
                tabsFilterOptions.TabPages.Add(page);
            }
            tabsFilterOptions.TabPages.Remove(tabConfig);
            tabsFilterOptions.TabPages.Add(tabConfig);
        }

        private void ApplyVisibleTabs(IList<VisibleFilter> filters)
        {
            if (filters == null || filters.Count <= 0)
                return;

            // Remove all except the BASIC
            while (tabsFilterOptions.TabPages.Count > 1)
                tabsFilterOptions.TabPages.RemoveAt(1);

            // Add only selected
            foreach (var tab in _tabBucket)
            {
                var vf = (VisibleFilter)tab.Tag;
                var entry = filters.FirstOrDefault(f => f.Filter == vf.Filter && f.PluginId == vf.PluginId);
                if (entry == null || entry.Visible || (entry.Filter == DefaultFilter.Plugin && entry.PluginId == Guid.Empty))
                    tabsFilterOptions.TabPages.Add(tab);
            }

            // Read the config
            tabsFilterOptions.TabPages.Add(tabConfig);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (_searchEngine != null && _searchEngine.IsRunning)
            {
                _searchEngine.Stop();
                btnSearch.Enabled = false;
                return;
            }

            var directoryInfo = new DirectoryInfo(cmbFolder.Text.Trim('\\') + "\\");
            if (!directoryInfo.Exists)
            {
                MessageBox.Show(@"The specified folder does not exist.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var text = cmbCriteria.SelectedItem != null ? (string)cmbCriteria.SelectedItem : cmbCriteria.Text;

            try
            {
                if (chkRegularExpressions.Checked)
                    // ReSharper disable ReturnValueOfPureMethodIsNotUsed
                    Regex.IsMatch("", text); // Do nothing with the value, just validate it for argument.
                    // ReSharper restore ReturnValueOfPureMethodIsNotUsed
            }
            catch (ArgumentException)
            {
                MessageBox.Show(@"The specified regular expression is not valid.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            statusProgress.Style = ProgressBarStyle.Marquee;
            lstResults.ClearContent();
            _resultsViewIsUpdated = false;

            // Save the criteria
            if (!string.IsNullOrEmpty(text))
            {
                if (cmbCriteria.Items.Contains(text))
                    cmbCriteria.Items.Remove(text);
                cmbCriteria.Items.Insert(0, text);
                cmbCriteria.SelectedItem = 0;
            }
            // Save the content combobox
            var content = cmbContent.SelectedItem != null ? (string)cmbContent.SelectedItem : cmbContent.Text;
            if (!string.IsNullOrEmpty(content))
            {
                if (cmbContent.Items.Contains(content))
                    cmbContent.Items.Remove(content);
                cmbContent.Items.Insert(0, content);
                cmbContent.SelectedItem = 0;
            }

            // Save the content
            btnSearch.Text = @"Stop";
            statusLabel.Text = @"Searching... Please wait.";
            statusLabelExceptions.Text = null;
            tabsFilterOptions.Enabled = false;

            _searchEngine = new SearchEngine(BuildOptions(directoryInfo, text), Plugins.All().Select(f => f.GetCriterion()).Where(f => f != null).SelectMany(f => f));
            _searchEngine.Start(LoadList, LoadListFinished);
        }

        private void LoadList(IEnumerable<SearchResult> searchResults)
        {
            if (lstResults.InvokeRequired)
            {
                lstResults.BeginInvoke((Action<IEnumerable<SearchResult>>)LoadList, searchResults);
                return;
            }

            if (!_resultsViewIsUpdated)
            {
                lstResults.SetViewBuilder(ViewBuilderFactory.Create(_searchEngine.UsedCriteria));
                _resultsViewIsUpdated = true;
            }
            lstResults.AddSearchResults(searchResults);
        }

        private void LoadListFinished()
        {
            if (lstResults.InvokeRequired)
            {
                lstResults.Invoke((Action)LoadListFinished);
                return;
            }

            var exceptions = _searchEngine.Exceptions;
            if (exceptions.Count > 0)
                statusLabelExceptions.Text = string.Format(CultureInfo.InvariantCulture, "{0} exception(s) occurred", exceptions.Count);

            btnSearch.Text = @"Search";
            btnSearch.Enabled = true;
            statusLabel.Text = @"Done in " + _searchEngine.OperatingTime.GetFriendlyNotation() + @". Found " + lstResults.Count + @" records.";
            tabsFilterOptions.Enabled = true;
            statusProgress.Style = ProgressBarStyle.Blocks;
            if (lstResults.Count > 0)
                lstResults.Focus();
            else
                cmbCriteria.Focus();
        }

        private void lstResults_DirectoryOpened(object sender, PathEventArgs e)
        {
            Process.Start(new ProcessStartInfo("explorer.exe", "\"" + e.Entry.FileSystemInfo.FullName + "\""));
        }

        private void lstResults_FileOpened(object sender, PathEventArgs e)
        {
            Process.Start(new ProcessStartInfo("explorer.exe", "/select,\"" + e.Entry.FileSystemInfo.FullName + "\""));
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = cmbFolder.Text;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // Set the selected index to -1 so when the text is set the index is forgotten.
                cmbFolder.SelectedIndex = -1;
                cmbFolder.Text = folderBrowserDialog.SelectedPath;
                
            }
        }

        private void txtFolder_TextChanged(object sender, EventArgs e)
        {
            cmbFolder.ForeColor = Directory.Exists(cmbFolder.Text) ? SystemColors.WindowText : Color.Red;
            chkFolderFavorites.Checked = cmbFolder.Items.Contains(cmbFolder.Text.TrimEnd('\\'));
        }

        private void chkFolderFavorites_Click(object sender, EventArgs e)
        {
            var text = cmbFolder.SelectedIndex >= 0 ? (string)cmbFolder.Items[cmbFolder.SelectedIndex] : cmbFolder.Text.TrimEnd('\\');
            // Remove it
            if (cmbFolder.Items.Contains(text))
            {
                if (cmbFolder.SelectedIndex >= 0) cmbFolder.Items.RemoveAt(cmbFolder.SelectedIndex);
                else cmbFolder.Items.Remove(text);

                cmbFolder.Text = text;
                chkFolderFavorites.Checked = false;
            }
            // Add the new one
            else if (!string.IsNullOrEmpty(text))
            {
                var range = cmbFolder.Items.Cast<string>().Select(s => s.TrimEnd('\\')).Union(Enumerable.Repeat(text, 1)).OrderBy(s => s).ToArray();

                cmbFolder.Items.Clear();
                cmbFolder.Items.AddRange(range);

                //cmbFolder.Items.Insert(0, cmbFolder.Text.TrimEnd('\\'));
                cmbFolder.SelectedIndex = cmbFolder.Items.IndexOf(text);
                chkFolderFavorites.Checked = true;
            }

            if (Settings.Default.FolderFavorites == null)
                Settings.Default.FolderFavorites = new StringCollection();
            Settings.Default.FolderFavorites.Clear();
            Settings.Default.FolderFavorites.AddRange(cmbFolder.Items.Cast<string>().ToArray());
            Settings.Default.Save();
        }

        private void lstResults_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = null;
        }

        private void lstResults_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = btnSearch;
        }

        private void tabsFilterOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabsFilterOptions.SelectedTab == tabBasic)
                cmbCriteria.Focus();
            else if (tabsFilterOptions.SelectedTab == tabContent)
                cmbContent.Focus();
        }

        private void tabsFilterOptions_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.Action == TabControlAction.Selecting && e.TabPage == tabConfig)
            {
                e.Cancel = true;

                var form = new SettingsForm(new List<VisibleFilter>(VisibleFilterHelper.Deserialize(Settings.Default.VisibleFilters)));
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var filters = form.RetrieveVisibleFilters();
                    ApplyVisibleTabs(filters);
                    Settings.Default.VisibleFilters = VisibleFilterHelper.Serialize(filters);
                    Settings.Default.Save();
                    e.Cancel = false;
                }
            }
        }

        private void statusLabelExceptions_Click(object sender, EventArgs e)
        {
            if (_searchEngine == null || _searchEngine.Exceptions.Count <= 0)
                return;

            var form = _exceptionsForm ?? (_exceptionsForm = new ExceptionsForm());
            form.SetContent(_searchEngine.Exceptions);
            form.ShowDialog();
        }

        #region Checkboxes states

        private void chkSizeEnabled_CheckedChanged(object sender, EventArgs e)
        {
            cmbSizeMultiplier.Enabled = chkSizeEnabled.Checked;
            cmbSizeOperator.Enabled = chkSizeEnabled.Checked;
            numSizeValue.Enabled = chkSizeEnabled.Checked;
            if (numSizeValue.Enabled)
                numSizeValue.Focus();
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            var c = (CheckBox) sender;

            // Check state is undone
            if (c.Checked)
            {
                if (chkDateAccessed != c)
                    chkDateAccessed.Checked = false;
                if (chkDateChanged != c)
                    chkDateChanged.Checked = false;
                if (chkDateCreated != c)
                    chkDateCreated.Checked = false;
            }

            var anyChecked = chkDateAccessed.Checked || chkDateChanged.Checked || chkDateCreated.Checked;
            chkDateOlderEnabled.Enabled = anyChecked;
            chkDateBetweenEnabled.Enabled = anyChecked;
            if (!anyChecked)
            {
                chkDateOlderEnabled.Checked = false;
                chkDateBetweenEnabled.Checked = false;
            }
        }

        private void chkDateEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == chkDateOlderEnabled)
            {
                if (chkDateOlderEnabled.Checked) chkDateBetweenEnabled.Checked = false;
                cmbDateOlderMultiplier.Enabled = chkDateOlderEnabled.Checked;
                numDateOlderValue.Enabled = chkDateOlderEnabled.Checked;
            }
            else if (sender == chkDateBetweenEnabled)
            {
                if (chkDateBetweenEnabled.Checked) chkDateOlderEnabled.Checked = false;
                dateDateBetweenStart.Enabled = chkDateBetweenEnabled.Checked;
                dateDateBetweenEnd.Enabled = chkDateBetweenEnabled.Checked;
            }
        }

        private void chkContentRegex_CheckedChanged(object sender, EventArgs e)
        {
            if (!((CheckBox)sender).Checked) return;
            if (sender == chkContentRegex)
                chkContentWholeWords.Checked = false;
            else if (sender == chkContentWholeWords)
                chkContentRegex.Checked = false;
        }

        private void chkContentEncoding_CheckedChanged(object sender, EventArgs e)
        {
            var checkbox = (CheckBox)sender;

            // If auto is checked, uncheck all others
            if (checkbox == chkContentEncodingDetect && checkbox.Checked)
            {
                chkContentEncodingAnsii.Checked = chkContentEncodingAscii.Checked = chkContentEncodingUtf16Little.Checked =
                    chkContentEncodingUtf8.Checked = chkContentEncodingUtf16Big.Checked = false;
                return;
            }
            
            // If other checkbox is checked, uncheck the auto
            if (checkbox != chkContentEncodingDetect && checkbox.Checked)
                chkContentEncodingDetect.Checked = false;

            // Do not allow unchecking all the items.
            if (!chkContentEncodingDetect.Checked && !chkContentEncodingAnsii.Checked && !chkContentEncodingAscii.Checked && !chkContentEncodingUtf16Little.Checked && !chkContentEncodingUtf8.Checked && !chkContentEncodingUtf16Big.Checked)
                checkbox.Checked = true;
        }

        private void chkDuplicate_CheckedChanged(object sender, EventArgs e)
        {
            var checkbox = (CheckBox)sender;
            // Check the size, if the content is checked.
            if (sender == chkDuplicateContent && checkbox.Checked)
                chkDuplicateSize.Checked = true;
            // Uncheck the content, if the size is unchecked.
            else if (sender == chkDuplicateSize && !checkbox.Checked)
                chkDuplicateContent.Checked = false;
        }

        #endregion

        #region Collect criteria information

        private EngineOptions BuildOptions(DirectoryInfo directoryInfo, string text)
        {
            var options = new EngineOptions(new[] { directoryInfo })
            {
                SearchName = text,
                SearchIncludesFolders = chkIncludeFoldersInResults.Checked,
                SearchNameIgnoreCasing = chkIgnoreCase.Checked,
                SearchNameMatchFullPath = chkMatchFullPath.Checked,
                SearchRecursive = chkRecursive.Checked,
                SearchNameAsRegularExpression = chkRegularExpressions.Checked,
                SearchInArchives = chkSearchInZip.Checked,
                ContentAsRegularExpression = chkContentRegex.Checked,
                ContentText = cmbContent.SelectedItem != null ? (string)cmbContent.SelectedItem : cmbContent.Text,
                ContentIgnoreCasing = chkContentIgnoreCase.Checked,
                ContentWholeWordsOnly = chkContentWholeWords.Checked,
                ContentEncodingFactory = GetContentEncodingFactory(),
                ContentForOfficeXml = chkContentInOfficeFiles.Checked,
                CompareFileName = chkDuplicateName.Checked,
                CompareSize = chkDuplicateSize.Checked,
                CompareContent = chkDuplicateContent.Checked
            };
            ResolveAttributes(options);
            ResolveSizeOptions(options);
            ResolveDateOptions(options);

            return options;
        }

        private void ResolveAttributes(EngineOptions options)
        {
            var attributes = new FileAttributes[3];
            attributes[(int)chkAttributeArchive.CheckState] |= FileAttributes.Archive;
            attributes[(int)chkAttributeCompressed.CheckState] |= FileAttributes.Compressed;
            attributes[(int)chkAttributeEncrypted.CheckState] |= FileAttributes.Encrypted;
            attributes[(int)chkAttributeHidden.CheckState] |= FileAttributes.Hidden;
            attributes[(int)chkAttributeReadonly.CheckState] |= FileAttributes.ReadOnly;
            attributes[(int)chkAttributeSparse.CheckState] |= FileAttributes.SparseFile;
            attributes[(int)chkAttributeSystem.CheckState] |= FileAttributes.System;
            attributes[(int)chkAttributeTemporary.CheckState] |= FileAttributes.Temporary;

            options.AttributesIncluded = attributes[(int) CheckState.Checked];
            options.AttributesExcluded = attributes[(int) CheckState.Unchecked];
        }

        private void ResolveSizeOptions(EngineOptions options)
        {
            if (!chkSizeEnabled.Checked) return;

            var size = (long)((double)numSizeValue.Value * Math.Pow(1024, cmbSizeMultiplier.SelectedIndex));
            switch (cmbSizeOperator.SelectedIndex)
            {
                // Around
                case 0:
                    options.MinimumSize = (long)Math.Round(size * 0.85);
                    options.MaximumSize = (long)Math.Round(size * 1.15);
                    break;
                // Smaller
                case 1:
                    options.MaximumSize = size;
                    break;
                // Equals
                case 2:
                    options.MinimumSize = size;
                    options.MaximumSize = size;
                    break;
                // Greater
                case 3:
                    options.MinimumSize = size;
                    break;
            }
        }

        private void ResolveDateOptions(EngineOptions options)
        {
            var option = chkDateAccessed.Checked ? FileDateOption.Accessed :
                                     chkDateChanged.Checked ? FileDateOption.Changed :
                                         chkDateCreated.Checked ? FileDateOption.Created : FileDateOption.None;
            if (option == FileDateOption.None || (!chkDateOlderEnabled.Checked && !chkDateBetweenEnabled.Checked)) return;
            options.DateOption = option;

            if (chkDateOlderEnabled.Checked)
                options.StartDateTime = GetDateOlder();
            else if (chkDateBetweenEnabled.Checked)
            {
                options.StartDateTime = dateDateBetweenStart.Value.Date;
                options.EndDateTime = dateDateBetweenEnd.Value.AddDays(1).Date.AddMilliseconds(-1);
            }
        }

        private DateTime GetDateOlder()
        {
            var dateTime = DateTime.UtcNow;
            var value = (int)Math.Round(numDateOlderValue.Value);
            switch (cmbDateOlderMultiplier.SelectedIndex)
            {
                // Minutes
                case 0:
                    return dateTime.AddMinutes(value * -1);
                // Hours
                case 1:
                    return dateTime.AddHours(value * -1);
                // Days
                case 2:
                    return dateTime.AddDays(value * -1).Date;
                // Weeks
                case 3:
                    return dateTime.AddDays(value * 7 * -1).Date;
                // Months
                case 4:
                    return dateTime.AddMonths(value * -1).Date;
                // Years
                case 5:
                    return dateTime.AddYears(value * -1).Date;
                default:
                    throw new NotSupportedException();
            }
        }

        private IEncodingFactory GetContentEncodingFactory()
        {
            if (chkContentEncodingDetect.Checked)
                return new EncodingDetector();

            var list = new List<Encoding>();
            if (chkContentEncodingAnsii.Checked)
                list.Add(Encoding.Default);
            if (chkContentEncodingAscii.Checked)
                list.Add(Encoding.ASCII);
            if (chkContentEncodingUtf16Little.Checked)
                list.Add(Encoding.Unicode);
            if (chkContentEncodingUtf16Big.Checked)
                list.Add(Encoding.BigEndianUnicode);
            if (chkContentEncodingUtf8.Checked)
                list.Add(Encoding.UTF8);
            return new EncodingWrapper(list.ToArray());
        }

        #endregion
    }
}
