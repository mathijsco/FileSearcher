using FileSearcher.Ui.Controls;
using FileSearcher.Ui.Entries;

namespace FileSearcher.Ui
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.lstcPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.chkRecursive = new System.Windows.Forms.CheckBox();
            this.chkRegularExpressions = new System.Windows.Forms.CheckBox();
            this.tabsFilterOptions = new System.Windows.Forms.TabControl();
            this.tabBasic = new System.Windows.Forms.TabPage();
            this.chkSearchInZip = new System.Windows.Forms.CheckBox();
            this.chkMatchFullPath = new System.Windows.Forms.CheckBox();
            this.cmbFolder = new System.Windows.Forms.ComboBox();
            this.chkFolderFavorites = new System.Windows.Forms.CheckBox();
            this.chkIncludeFoldersInResults = new System.Windows.Forms.CheckBox();
            this.chkIgnoreCase = new System.Windows.Forms.CheckBox();
            this.cmbCriteria = new System.Windows.Forms.ComboBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tabContent = new System.Windows.Forms.TabPage();
            this.chkContentInOfficeFiles = new System.Windows.Forms.CheckBox();
            this.chkContentEncodingUtf16Big = new System.Windows.Forms.CheckBox();
            this.chkContentEncodingDetect = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkContentEncodingUtf16Little = new System.Windows.Forms.CheckBox();
            this.chkContentEncodingAscii = new System.Windows.Forms.CheckBox();
            this.chkContentEncodingUtf8 = new System.Windows.Forms.CheckBox();
            this.chkContentEncodingAnsii = new System.Windows.Forms.CheckBox();
            this.chkContentWholeWords = new System.Windows.Forms.CheckBox();
            this.chkContentIgnoreCase = new System.Windows.Forms.CheckBox();
            this.chkContentRegex = new System.Windows.Forms.CheckBox();
            this.cmbContent = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabDates = new System.Windows.Forms.TabPage();
            this.chkDateBetweenEnabled = new System.Windows.Forms.CheckBox();
            this.chkDateOlderEnabled = new System.Windows.Forms.CheckBox();
            this.cmbDateOlderMultiplier = new System.Windows.Forms.ComboBox();
            this.dateDateBetweenEnd = new System.Windows.Forms.DateTimePicker();
            this.dateDateBetweenStart = new System.Windows.Forms.DateTimePicker();
            this.numDateOlderValue = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.chkDateCreated = new System.Windows.Forms.CheckBox();
            this.chkDateChanged = new System.Windows.Forms.CheckBox();
            this.chkDateAccessed = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabOthers = new System.Windows.Forms.TabPage();
            this.chkSizeEnabled = new System.Windows.Forms.CheckBox();
            this.numSizeValue = new System.Windows.Forms.NumericUpDown();
            this.cmbSizeMultiplier = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSizeOperator = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkAttributeHidden = new System.Windows.Forms.CheckBox();
            this.chkAttributeEncrypted = new System.Windows.Forms.CheckBox();
            this.chkAttributeCompressed = new System.Windows.Forms.CheckBox();
            this.chkAttributeSparse = new System.Windows.Forms.CheckBox();
            this.chkAttributeTemporary = new System.Windows.Forms.CheckBox();
            this.chkAttributeArchive = new System.Windows.Forms.CheckBox();
            this.chkAttributeSystem = new System.Windows.Forms.CheckBox();
            this.chkAttributeReadonly = new System.Windows.Forms.CheckBox();
            this.tabDuplicates = new System.Windows.Forms.TabPage();
            this.chkDuplicateContent = new System.Windows.Forms.CheckBox();
            this.chkDuplicateSize = new System.Windows.Forms.CheckBox();
            this.chkDuplicateName = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelExceptions = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lstResults = new FileSearcher.Ui.Controls.LargeListViewUserControl();
            this.tabsFilterOptions.SuspendLayout();
            this.tabBasic.SuspendLayout();
            this.tabContent.SuspendLayout();
            this.tabDates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDateOlderValue)).BeginInit();
            this.tabOthers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSizeValue)).BeginInit();
            this.tabDuplicates.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Criteria";
            // 
            // lstcPath
            // 
            this.lstcPath.Text = "Path";
            this.lstcPath.Width = 435;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "In folder";
            // 
            // chkRecursive
            // 
            this.chkRecursive.AutoSize = true;
            this.chkRecursive.Checked = true;
            this.chkRecursive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecursive.Location = new System.Drawing.Point(227, 59);
            this.chkRecursive.Name = "chkRecursive";
            this.chkRecursive.Size = new System.Drawing.Size(112, 17);
            this.chkRecursive.TabIndex = 7;
            this.chkRecursive.Text = "Include subfolders";
            this.chkRecursive.UseVisualStyleBackColor = true;
            // 
            // chkRegularExpressions
            // 
            this.chkRegularExpressions.AutoSize = true;
            this.chkRegularExpressions.Location = new System.Drawing.Point(82, 105);
            this.chkRegularExpressions.Name = "chkRegularExpressions";
            this.chkRegularExpressions.Size = new System.Drawing.Size(121, 17);
            this.chkRegularExpressions.TabIndex = 10;
            this.chkRegularExpressions.Text = "Regular expressions";
            this.chkRegularExpressions.UseVisualStyleBackColor = true;
            // 
            // tabsFilterOptions
            // 
            this.tabsFilterOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabsFilterOptions.Controls.Add(this.tabBasic);
            this.tabsFilterOptions.Controls.Add(this.tabContent);
            this.tabsFilterOptions.Controls.Add(this.tabDates);
            this.tabsFilterOptions.Controls.Add(this.tabOthers);
            this.tabsFilterOptions.Controls.Add(this.tabDuplicates);
            this.tabsFilterOptions.Controls.Add(this.tabConfig);
            this.tabsFilterOptions.ImageList = this.imageList1;
            this.tabsFilterOptions.Location = new System.Drawing.Point(12, 12);
            this.tabsFilterOptions.Name = "tabsFilterOptions";
            this.tabsFilterOptions.SelectedIndex = 0;
            this.tabsFilterOptions.Size = new System.Drawing.Size(680, 181);
            this.tabsFilterOptions.TabIndex = 0;
            this.tabsFilterOptions.SelectedIndexChanged += new System.EventHandler(this.tabsFilterOptions_SelectedIndexChanged);
            this.tabsFilterOptions.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabsFilterOptions_Selecting);
            // 
            // tabBasic
            // 
            this.tabBasic.Controls.Add(this.chkSearchInZip);
            this.tabBasic.Controls.Add(this.chkMatchFullPath);
            this.tabBasic.Controls.Add(this.cmbFolder);
            this.tabBasic.Controls.Add(this.chkFolderFavorites);
            this.tabBasic.Controls.Add(this.chkIncludeFoldersInResults);
            this.tabBasic.Controls.Add(this.chkIgnoreCase);
            this.tabBasic.Controls.Add(this.cmbCriteria);
            this.tabBasic.Controls.Add(this.btnBrowse);
            this.tabBasic.Controls.Add(this.label1);
            this.tabBasic.Controls.Add(this.chkRegularExpressions);
            this.tabBasic.Controls.Add(this.label2);
            this.tabBasic.Controls.Add(this.chkRecursive);
            this.tabBasic.Location = new System.Drawing.Point(4, 23);
            this.tabBasic.Name = "tabBasic";
            this.tabBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tabBasic.Size = new System.Drawing.Size(672, 154);
            this.tabBasic.TabIndex = 0;
            this.tabBasic.Text = "Basic";
            this.tabBasic.UseVisualStyleBackColor = true;
            // 
            // chkSearchInZip
            // 
            this.chkSearchInZip.AutoSize = true;
            this.chkSearchInZip.Location = new System.Drawing.Point(227, 105);
            this.chkSearchInZip.Name = "chkSearchInZip";
            this.chkSearchInZip.Size = new System.Drawing.Size(112, 17);
            this.chkSearchInZip.TabIndex = 11;
            this.chkSearchInZip.Text = "Search in ZIP files";
            this.chkSearchInZip.UseVisualStyleBackColor = true;
            // 
            // chkMatchFullPath
            // 
            this.chkMatchFullPath.AutoSize = true;
            this.chkMatchFullPath.Location = new System.Drawing.Point(82, 82);
            this.chkMatchFullPath.Name = "chkMatchFullPath";
            this.chkMatchFullPath.Size = new System.Drawing.Size(96, 17);
            this.chkMatchFullPath.TabIndex = 8;
            this.chkMatchFullPath.Text = "Match full path";
            this.chkMatchFullPath.UseVisualStyleBackColor = true;
            // 
            // cmbFolder
            // 
            this.cmbFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFolder.FormattingEnabled = true;
            this.cmbFolder.Location = new System.Drawing.Point(82, 33);
            this.cmbFolder.Name = "cmbFolder";
            this.cmbFolder.Size = new System.Drawing.Size(503, 21);
            this.cmbFolder.TabIndex = 3;
            this.cmbFolder.SelectedIndexChanged += new System.EventHandler(this.txtFolder_TextChanged);
            this.cmbFolder.TextChanged += new System.EventHandler(this.txtFolder_TextChanged);
            // 
            // chkFolderFavorites
            // 
            this.chkFolderFavorites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFolderFavorites.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkFolderFavorites.Location = new System.Drawing.Point(638, 31);
            this.chkFolderFavorites.Name = "chkFolderFavorites";
            this.chkFolderFavorites.Size = new System.Drawing.Size(28, 23);
            this.chkFolderFavorites.TabIndex = 5;
            this.chkFolderFavorites.Text = "ê";
            this.chkFolderFavorites.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.chkFolderFavorites, "Add or remove from favorites");
            this.chkFolderFavorites.UseVisualStyleBackColor = true;
            this.chkFolderFavorites.Click += new System.EventHandler(this.chkFolderFavorites_Click);
            // 
            // chkIncludeFoldersInResults
            // 
            this.chkIncludeFoldersInResults.AutoSize = true;
            this.chkIncludeFoldersInResults.Location = new System.Drawing.Point(227, 82);
            this.chkIncludeFoldersInResults.Name = "chkIncludeFoldersInResults";
            this.chkIncludeFoldersInResults.Size = new System.Drawing.Size(139, 17);
            this.chkIncludeFoldersInResults.TabIndex = 9;
            this.chkIncludeFoldersInResults.Text = "Include folders in results";
            this.chkIncludeFoldersInResults.UseVisualStyleBackColor = true;
            // 
            // chkIgnoreCase
            // 
            this.chkIgnoreCase.AutoSize = true;
            this.chkIgnoreCase.Checked = true;
            this.chkIgnoreCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIgnoreCase.Location = new System.Drawing.Point(82, 60);
            this.chkIgnoreCase.Name = "chkIgnoreCase";
            this.chkIgnoreCase.Size = new System.Drawing.Size(90, 17);
            this.chkIgnoreCase.TabIndex = 6;
            this.chkIgnoreCase.Text = "Ignore casing";
            this.chkIgnoreCase.UseVisualStyleBackColor = true;
            // 
            // cmbCriteria
            // 
            this.cmbCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCriteria.FormattingEnabled = true;
            this.cmbCriteria.Location = new System.Drawing.Point(82, 6);
            this.cmbCriteria.Name = "cmbCriteria";
            this.cmbCriteria.Size = new System.Drawing.Size(584, 21);
            this.cmbCriteria.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(591, 31);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(41, 23);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "...";
            this.toolTip.SetToolTip(this.btnBrowse, "Browse for a folder");
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // tabContent
            // 
            this.tabContent.Controls.Add(this.chkContentInOfficeFiles);
            this.tabContent.Controls.Add(this.chkContentEncodingUtf16Big);
            this.tabContent.Controls.Add(this.chkContentEncodingDetect);
            this.tabContent.Controls.Add(this.label8);
            this.tabContent.Controls.Add(this.chkContentEncodingUtf16Little);
            this.tabContent.Controls.Add(this.chkContentEncodingAscii);
            this.tabContent.Controls.Add(this.chkContentEncodingUtf8);
            this.tabContent.Controls.Add(this.chkContentEncodingAnsii);
            this.tabContent.Controls.Add(this.chkContentWholeWords);
            this.tabContent.Controls.Add(this.chkContentIgnoreCase);
            this.tabContent.Controls.Add(this.chkContentRegex);
            this.tabContent.Controls.Add(this.cmbContent);
            this.tabContent.Controls.Add(this.label6);
            this.tabContent.Location = new System.Drawing.Point(4, 23);
            this.tabContent.Name = "tabContent";
            this.tabContent.Padding = new System.Windows.Forms.Padding(3);
            this.tabContent.Size = new System.Drawing.Size(672, 154);
            this.tabContent.TabIndex = 2;
            this.tabContent.Text = "Content";
            this.tabContent.UseVisualStyleBackColor = true;
            // 
            // chkContentInOfficeFiles
            // 
            this.chkContentInOfficeFiles.AutoSize = true;
            this.chkContentInOfficeFiles.Enabled = false;
            this.chkContentInOfficeFiles.Location = new System.Drawing.Point(227, 56);
            this.chkContentInOfficeFiles.Name = "chkContentInOfficeFiles";
            this.chkContentInOfficeFiles.Size = new System.Drawing.Size(202, 17);
            this.chkContentInOfficeFiles.TabIndex = 5;
            this.chkContentInOfficeFiles.Text = "Search in Microsoft Open Office XML";
            this.chkContentInOfficeFiles.UseVisualStyleBackColor = true;
            // 
            // chkContentEncodingUtf16Big
            // 
            this.chkContentEncodingUtf16Big.AutoSize = true;
            this.chkContentEncodingUtf16Big.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.chkContentEncodingUtf16Big.Location = new System.Drawing.Point(354, 110);
            this.chkContentEncodingUtf16Big.Name = "chkContentEncodingUtf16Big";
            this.chkContentEncodingUtf16Big.Size = new System.Drawing.Size(161, 17);
            this.chkContentEncodingUtf16Big.TabIndex = 12;
            this.chkContentEncodingUtf16Big.Text = "UTF16 Unicode (Big endian)";
            this.chkContentEncodingUtf16Big.UseVisualStyleBackColor = true;
            this.chkContentEncodingUtf16Big.CheckedChanged += new System.EventHandler(this.chkContentEncoding_CheckedChanged);
            // 
            // chkContentEncodingDetect
            // 
            this.chkContentEncodingDetect.AutoSize = true;
            this.chkContentEncodingDetect.Checked = true;
            this.chkContentEncodingDetect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkContentEncodingDetect.Location = new System.Drawing.Point(82, 87);
            this.chkContentEncodingDetect.Name = "chkContentEncodingDetect";
            this.chkContentEncodingDetect.Size = new System.Drawing.Size(121, 17);
            this.chkContentEncodingDetect.TabIndex = 7;
            this.chkContentEncodingDetect.Text = "Automatically detect";
            this.chkContentEncodingDetect.UseVisualStyleBackColor = true;
            this.chkContentEncodingDetect.CheckedChanged += new System.EventHandler(this.chkContentEncoding_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Encoding";
            // 
            // chkContentEncodingUtf16Little
            // 
            this.chkContentEncodingUtf16Little.AutoSize = true;
            this.chkContentEncodingUtf16Little.Location = new System.Drawing.Point(354, 88);
            this.chkContentEncodingUtf16Little.Name = "chkContentEncodingUtf16Little";
            this.chkContentEncodingUtf16Little.Size = new System.Drawing.Size(168, 17);
            this.chkContentEncodingUtf16Little.TabIndex = 11;
            this.chkContentEncodingUtf16Little.Text = "UTF16 Unicode (Little endian)";
            this.chkContentEncodingUtf16Little.UseVisualStyleBackColor = true;
            this.chkContentEncodingUtf16Little.CheckedChanged += new System.EventHandler(this.chkContentEncoding_CheckedChanged);
            // 
            // chkContentEncodingAscii
            // 
            this.chkContentEncodingAscii.AutoSize = true;
            this.chkContentEncodingAscii.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.chkContentEncodingAscii.Location = new System.Drawing.Point(227, 110);
            this.chkContentEncodingAscii.Name = "chkContentEncodingAscii";
            this.chkContentEncodingAscii.Size = new System.Drawing.Size(85, 17);
            this.chkContentEncodingAscii.TabIndex = 10;
            this.chkContentEncodingAscii.Text = "ASCII (DOS)";
            this.chkContentEncodingAscii.UseVisualStyleBackColor = true;
            this.chkContentEncodingAscii.CheckedChanged += new System.EventHandler(this.chkContentEncoding_CheckedChanged);
            // 
            // chkContentEncodingUtf8
            // 
            this.chkContentEncodingUtf8.AutoSize = true;
            this.chkContentEncodingUtf8.Location = new System.Drawing.Point(227, 87);
            this.chkContentEncodingUtf8.Name = "chkContentEncodingUtf8";
            this.chkContentEncodingUtf8.Size = new System.Drawing.Size(53, 17);
            this.chkContentEncodingUtf8.TabIndex = 9;
            this.chkContentEncodingUtf8.Text = "UTF8";
            this.chkContentEncodingUtf8.UseVisualStyleBackColor = true;
            this.chkContentEncodingUtf8.CheckedChanged += new System.EventHandler(this.chkContentEncoding_CheckedChanged);
            // 
            // chkContentEncodingAnsii
            // 
            this.chkContentEncodingAnsii.AutoSize = true;
            this.chkContentEncodingAnsii.Location = new System.Drawing.Point(82, 110);
            this.chkContentEncodingAnsii.Name = "chkContentEncodingAnsii";
            this.chkContentEncodingAnsii.Size = new System.Drawing.Size(107, 17);
            this.chkContentEncodingAnsii.TabIndex = 8;
            this.chkContentEncodingAnsii.Text = "ANSII (Windows)";
            this.chkContentEncodingAnsii.UseVisualStyleBackColor = true;
            this.chkContentEncodingAnsii.CheckedChanged += new System.EventHandler(this.chkContentEncoding_CheckedChanged);
            // 
            // chkContentWholeWords
            // 
            this.chkContentWholeWords.AutoSize = true;
            this.chkContentWholeWords.Location = new System.Drawing.Point(82, 56);
            this.chkContentWholeWords.Name = "chkContentWholeWords";
            this.chkContentWholeWords.Size = new System.Drawing.Size(110, 17);
            this.chkContentWholeWords.TabIndex = 3;
            this.chkContentWholeWords.Text = "Whole words only";
            this.chkContentWholeWords.UseVisualStyleBackColor = true;
            this.chkContentWholeWords.CheckedChanged += new System.EventHandler(this.chkContentRegex_CheckedChanged);
            // 
            // chkContentIgnoreCase
            // 
            this.chkContentIgnoreCase.AutoSize = true;
            this.chkContentIgnoreCase.Checked = true;
            this.chkContentIgnoreCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkContentIgnoreCase.Location = new System.Drawing.Point(227, 33);
            this.chkContentIgnoreCase.Name = "chkContentIgnoreCase";
            this.chkContentIgnoreCase.Size = new System.Drawing.Size(90, 17);
            this.chkContentIgnoreCase.TabIndex = 4;
            this.chkContentIgnoreCase.Text = "Ignore casing";
            this.chkContentIgnoreCase.UseVisualStyleBackColor = true;
            // 
            // chkContentRegex
            // 
            this.chkContentRegex.AutoSize = true;
            this.chkContentRegex.Enabled = false;
            this.chkContentRegex.Location = new System.Drawing.Point(82, 33);
            this.chkContentRegex.Name = "chkContentRegex";
            this.chkContentRegex.Size = new System.Drawing.Size(121, 17);
            this.chkContentRegex.TabIndex = 2;
            this.chkContentRegex.Text = "Regular expressions";
            this.chkContentRegex.UseVisualStyleBackColor = true;
            this.chkContentRegex.CheckedChanged += new System.EventHandler(this.chkContentRegex_CheckedChanged);
            // 
            // cmbContent
            // 
            this.cmbContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbContent.FormattingEnabled = true;
            this.cmbContent.Location = new System.Drawing.Point(82, 6);
            this.cmbContent.Name = "cmbContent";
            this.cmbContent.Size = new System.Drawing.Size(584, 21);
            this.cmbContent.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Text";
            // 
            // tabDates
            // 
            this.tabDates.Controls.Add(this.chkDateBetweenEnabled);
            this.tabDates.Controls.Add(this.chkDateOlderEnabled);
            this.tabDates.Controls.Add(this.cmbDateOlderMultiplier);
            this.tabDates.Controls.Add(this.dateDateBetweenEnd);
            this.tabDates.Controls.Add(this.dateDateBetweenStart);
            this.tabDates.Controls.Add(this.numDateOlderValue);
            this.tabDates.Controls.Add(this.label7);
            this.tabDates.Controls.Add(this.chkDateCreated);
            this.tabDates.Controls.Add(this.chkDateChanged);
            this.tabDates.Controls.Add(this.chkDateAccessed);
            this.tabDates.Controls.Add(this.label5);
            this.tabDates.Location = new System.Drawing.Point(4, 23);
            this.tabDates.Name = "tabDates";
            this.tabDates.Padding = new System.Windows.Forms.Padding(3);
            this.tabDates.Size = new System.Drawing.Size(672, 154);
            this.tabDates.TabIndex = 1;
            this.tabDates.Text = "Dates";
            this.tabDates.UseVisualStyleBackColor = true;
            // 
            // chkDateBetweenEnabled
            // 
            this.chkDateBetweenEnabled.AutoSize = true;
            this.chkDateBetweenEnabled.Enabled = false;
            this.chkDateBetweenEnabled.Location = new System.Drawing.Point(82, 92);
            this.chkDateBetweenEnabled.Name = "chkDateBetweenEnabled";
            this.chkDateBetweenEnabled.Size = new System.Drawing.Size(68, 17);
            this.chkDateBetweenEnabled.TabIndex = 8;
            this.chkDateBetweenEnabled.Text = "Between";
            this.chkDateBetweenEnabled.UseVisualStyleBackColor = true;
            this.chkDateBetweenEnabled.CheckedChanged += new System.EventHandler(this.chkDateEnabled_CheckedChanged);
            // 
            // chkDateOlderEnabled
            // 
            this.chkDateOlderEnabled.AutoSize = true;
            this.chkDateOlderEnabled.Enabled = false;
            this.chkDateOlderEnabled.Location = new System.Drawing.Point(82, 37);
            this.chkDateOlderEnabled.Name = "chkDateOlderEnabled";
            this.chkDateOlderEnabled.Size = new System.Drawing.Size(93, 17);
            this.chkDateOlderEnabled.TabIndex = 5;
            this.chkDateOlderEnabled.Text = "Not older than";
            this.chkDateOlderEnabled.UseVisualStyleBackColor = true;
            this.chkDateOlderEnabled.CheckedChanged += new System.EventHandler(this.chkDateEnabled_CheckedChanged);
            // 
            // cmbDateOlderMultiplier
            // 
            this.cmbDateOlderMultiplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDateOlderMultiplier.Enabled = false;
            this.cmbDateOlderMultiplier.FormattingEnabled = true;
            this.cmbDateOlderMultiplier.Items.AddRange(new object[] {
            "minutes",
            "hours",
            "days",
            "weeks",
            "months",
            "years"});
            this.cmbDateOlderMultiplier.Location = new System.Drawing.Point(208, 59);
            this.cmbDateOlderMultiplier.Name = "cmbDateOlderMultiplier";
            this.cmbDateOlderMultiplier.Size = new System.Drawing.Size(81, 21);
            this.cmbDateOlderMultiplier.TabIndex = 7;
            // 
            // dateDateBetweenEnd
            // 
            this.dateDateBetweenEnd.Enabled = false;
            this.dateDateBetweenEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDateBetweenEnd.Location = new System.Drawing.Point(198, 115);
            this.dateDateBetweenEnd.Name = "dateDateBetweenEnd";
            this.dateDateBetweenEnd.Size = new System.Drawing.Size(107, 20);
            this.dateDateBetweenEnd.TabIndex = 10;
            // 
            // dateDateBetweenStart
            // 
            this.dateDateBetweenStart.Enabled = false;
            this.dateDateBetweenStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDateBetweenStart.Location = new System.Drawing.Point(82, 115);
            this.dateDateBetweenStart.Name = "dateDateBetweenStart";
            this.dateDateBetweenStart.Size = new System.Drawing.Size(107, 20);
            this.dateDateBetweenStart.TabIndex = 9;
            // 
            // numDateOlderValue
            // 
            this.numDateOlderValue.Enabled = false;
            this.numDateOlderValue.Location = new System.Drawing.Point(82, 60);
            this.numDateOlderValue.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numDateOlderValue.Name = "numDateOlderValue";
            this.numDateOlderValue.Size = new System.Drawing.Size(120, 20);
            this.numDateOlderValue.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Filter";
            // 
            // chkDateCreated
            // 
            this.chkDateCreated.AutoSize = true;
            this.chkDateCreated.Location = new System.Drawing.Point(314, 8);
            this.chkDateCreated.Name = "chkDateCreated";
            this.chkDateCreated.Size = new System.Drawing.Size(63, 17);
            this.chkDateCreated.TabIndex = 3;
            this.chkDateCreated.Text = "Created";
            this.chkDateCreated.UseVisualStyleBackColor = true;
            this.chkDateCreated.CheckedChanged += new System.EventHandler(this.chkDate_CheckedChanged);
            // 
            // chkDateChanged
            // 
            this.chkDateChanged.AutoSize = true;
            this.chkDateChanged.Location = new System.Drawing.Point(198, 8);
            this.chkDateChanged.Name = "chkDateChanged";
            this.chkDateChanged.Size = new System.Drawing.Size(91, 17);
            this.chkDateChanged.TabIndex = 2;
            this.chkDateChanged.Text = "Last changed";
            this.chkDateChanged.UseVisualStyleBackColor = true;
            this.chkDateChanged.CheckedChanged += new System.EventHandler(this.chkDate_CheckedChanged);
            // 
            // chkDateAccessed
            // 
            this.chkDateAccessed.AutoSize = true;
            this.chkDateAccessed.Location = new System.Drawing.Point(82, 8);
            this.chkDateAccessed.Name = "chkDateAccessed";
            this.chkDateAccessed.Size = new System.Drawing.Size(95, 17);
            this.chkDateAccessed.TabIndex = 1;
            this.chkDateAccessed.Text = "Last accessed";
            this.chkDateAccessed.UseVisualStyleBackColor = true;
            this.chkDateAccessed.CheckedChanged += new System.EventHandler(this.chkDate_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Date field";
            // 
            // tabOthers
            // 
            this.tabOthers.Controls.Add(this.chkSizeEnabled);
            this.tabOthers.Controls.Add(this.numSizeValue);
            this.tabOthers.Controls.Add(this.cmbSizeMultiplier);
            this.tabOthers.Controls.Add(this.label4);
            this.tabOthers.Controls.Add(this.cmbSizeOperator);
            this.tabOthers.Controls.Add(this.label3);
            this.tabOthers.Controls.Add(this.chkAttributeHidden);
            this.tabOthers.Controls.Add(this.chkAttributeEncrypted);
            this.tabOthers.Controls.Add(this.chkAttributeCompressed);
            this.tabOthers.Controls.Add(this.chkAttributeSparse);
            this.tabOthers.Controls.Add(this.chkAttributeTemporary);
            this.tabOthers.Controls.Add(this.chkAttributeArchive);
            this.tabOthers.Controls.Add(this.chkAttributeSystem);
            this.tabOthers.Controls.Add(this.chkAttributeReadonly);
            this.tabOthers.Location = new System.Drawing.Point(4, 23);
            this.tabOthers.Name = "tabOthers";
            this.tabOthers.Size = new System.Drawing.Size(672, 154);
            this.tabOthers.TabIndex = 3;
            this.tabOthers.Text = "Size and attributes";
            this.tabOthers.UseVisualStyleBackColor = true;
            // 
            // chkSizeEnabled
            // 
            this.chkSizeEnabled.AutoSize = true;
            this.chkSizeEnabled.Location = new System.Drawing.Point(82, 87);
            this.chkSizeEnabled.Name = "chkSizeEnabled";
            this.chkSizeEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkSizeEnabled.TabIndex = 10;
            this.chkSizeEnabled.Text = "Enabled";
            this.chkSizeEnabled.UseVisualStyleBackColor = true;
            this.chkSizeEnabled.CheckedChanged += new System.EventHandler(this.chkSizeEnabled_CheckedChanged);
            // 
            // numSizeValue
            // 
            this.numSizeValue.Enabled = false;
            this.numSizeValue.Location = new System.Drawing.Point(148, 110);
            this.numSizeValue.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numSizeValue.Name = "numSizeValue";
            this.numSizeValue.Size = new System.Drawing.Size(86, 20);
            this.numSizeValue.TabIndex = 12;
            // 
            // cmbSizeMultiplier
            // 
            this.cmbSizeMultiplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSizeMultiplier.Enabled = false;
            this.cmbSizeMultiplier.FormattingEnabled = true;
            this.cmbSizeMultiplier.Items.AddRange(new object[] {
            "B",
            "KB",
            "MB",
            "GB",
            "TB"});
            this.cmbSizeMultiplier.Location = new System.Drawing.Point(240, 110);
            this.cmbSizeMultiplier.Name = "cmbSizeMultiplier";
            this.cmbSizeMultiplier.Size = new System.Drawing.Size(60, 21);
            this.cmbSizeMultiplier.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Attributes";
            // 
            // cmbSizeOperator
            // 
            this.cmbSizeOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSizeOperator.Enabled = false;
            this.cmbSizeOperator.FormattingEnabled = true;
            this.cmbSizeOperator.Items.AddRange(new object[] {
            "+/-",
            "<=",
            "=",
            ">="});
            this.cmbSizeOperator.Location = new System.Drawing.Point(82, 110);
            this.cmbSizeOperator.Name = "cmbSizeOperator";
            this.cmbSizeOperator.Size = new System.Drawing.Size(60, 21);
            this.cmbSizeOperator.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Size of file";
            // 
            // chkAttributeHidden
            // 
            this.chkAttributeHidden.AutoSize = true;
            this.chkAttributeHidden.Checked = true;
            this.chkAttributeHidden.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkAttributeHidden.Location = new System.Drawing.Point(82, 31);
            this.chkAttributeHidden.Name = "chkAttributeHidden";
            this.chkAttributeHidden.Size = new System.Drawing.Size(60, 17);
            this.chkAttributeHidden.TabIndex = 2;
            this.chkAttributeHidden.Text = "Hidden";
            this.chkAttributeHidden.ThreeState = true;
            this.chkAttributeHidden.UseVisualStyleBackColor = true;
            // 
            // chkAttributeEncrypted
            // 
            this.chkAttributeEncrypted.AutoSize = true;
            this.chkAttributeEncrypted.Checked = true;
            this.chkAttributeEncrypted.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkAttributeEncrypted.Location = new System.Drawing.Point(198, 54);
            this.chkAttributeEncrypted.Name = "chkAttributeEncrypted";
            this.chkAttributeEncrypted.Size = new System.Drawing.Size(74, 17);
            this.chkAttributeEncrypted.TabIndex = 6;
            this.chkAttributeEncrypted.Text = "Encrypted";
            this.chkAttributeEncrypted.ThreeState = true;
            this.chkAttributeEncrypted.UseVisualStyleBackColor = true;
            // 
            // chkAttributeCompressed
            // 
            this.chkAttributeCompressed.AutoSize = true;
            this.chkAttributeCompressed.Checked = true;
            this.chkAttributeCompressed.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkAttributeCompressed.Location = new System.Drawing.Point(198, 31);
            this.chkAttributeCompressed.Name = "chkAttributeCompressed";
            this.chkAttributeCompressed.Size = new System.Drawing.Size(84, 17);
            this.chkAttributeCompressed.TabIndex = 5;
            this.chkAttributeCompressed.Text = "Compressed";
            this.chkAttributeCompressed.ThreeState = true;
            this.chkAttributeCompressed.UseVisualStyleBackColor = true;
            // 
            // chkAttributeSparse
            // 
            this.chkAttributeSparse.AutoSize = true;
            this.chkAttributeSparse.Checked = true;
            this.chkAttributeSparse.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkAttributeSparse.Location = new System.Drawing.Point(314, 31);
            this.chkAttributeSparse.Name = "chkAttributeSparse";
            this.chkAttributeSparse.Size = new System.Drawing.Size(59, 17);
            this.chkAttributeSparse.TabIndex = 8;
            this.chkAttributeSparse.Text = "Sparse";
            this.chkAttributeSparse.ThreeState = true;
            this.chkAttributeSparse.UseVisualStyleBackColor = true;
            // 
            // chkAttributeTemporary
            // 
            this.chkAttributeTemporary.AutoSize = true;
            this.chkAttributeTemporary.Checked = true;
            this.chkAttributeTemporary.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkAttributeTemporary.Location = new System.Drawing.Point(314, 8);
            this.chkAttributeTemporary.Name = "chkAttributeTemporary";
            this.chkAttributeTemporary.Size = new System.Drawing.Size(76, 17);
            this.chkAttributeTemporary.TabIndex = 7;
            this.chkAttributeTemporary.Text = "Temporary";
            this.chkAttributeTemporary.ThreeState = true;
            this.chkAttributeTemporary.UseVisualStyleBackColor = true;
            // 
            // chkAttributeArchive
            // 
            this.chkAttributeArchive.AutoSize = true;
            this.chkAttributeArchive.Checked = true;
            this.chkAttributeArchive.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkAttributeArchive.Location = new System.Drawing.Point(82, 54);
            this.chkAttributeArchive.Name = "chkAttributeArchive";
            this.chkAttributeArchive.Size = new System.Drawing.Size(62, 17);
            this.chkAttributeArchive.TabIndex = 3;
            this.chkAttributeArchive.Text = "Archive";
            this.chkAttributeArchive.ThreeState = true;
            this.chkAttributeArchive.UseVisualStyleBackColor = true;
            // 
            // chkAttributeSystem
            // 
            this.chkAttributeSystem.AutoSize = true;
            this.chkAttributeSystem.Checked = true;
            this.chkAttributeSystem.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkAttributeSystem.Location = new System.Drawing.Point(198, 8);
            this.chkAttributeSystem.Name = "chkAttributeSystem";
            this.chkAttributeSystem.Size = new System.Drawing.Size(60, 17);
            this.chkAttributeSystem.TabIndex = 4;
            this.chkAttributeSystem.Text = "System";
            this.chkAttributeSystem.ThreeState = true;
            this.chkAttributeSystem.UseVisualStyleBackColor = true;
            // 
            // chkAttributeReadonly
            // 
            this.chkAttributeReadonly.AutoSize = true;
            this.chkAttributeReadonly.Checked = true;
            this.chkAttributeReadonly.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkAttributeReadonly.Location = new System.Drawing.Point(82, 8);
            this.chkAttributeReadonly.Name = "chkAttributeReadonly";
            this.chkAttributeReadonly.Size = new System.Drawing.Size(74, 17);
            this.chkAttributeReadonly.TabIndex = 1;
            this.chkAttributeReadonly.Text = "Read only";
            this.chkAttributeReadonly.ThreeState = true;
            this.chkAttributeReadonly.UseVisualStyleBackColor = true;
            // 
            // tabDuplicates
            // 
            this.tabDuplicates.Controls.Add(this.chkDuplicateContent);
            this.tabDuplicates.Controls.Add(this.chkDuplicateSize);
            this.tabDuplicates.Controls.Add(this.chkDuplicateName);
            this.tabDuplicates.Controls.Add(this.label9);
            this.tabDuplicates.Location = new System.Drawing.Point(4, 23);
            this.tabDuplicates.Name = "tabDuplicates";
            this.tabDuplicates.Padding = new System.Windows.Forms.Padding(3);
            this.tabDuplicates.Size = new System.Drawing.Size(672, 154);
            this.tabDuplicates.TabIndex = 4;
            this.tabDuplicates.Text = "Duplicates";
            this.tabDuplicates.UseVisualStyleBackColor = true;
            // 
            // chkDuplicateContent
            // 
            this.chkDuplicateContent.AutoSize = true;
            this.chkDuplicateContent.Location = new System.Drawing.Point(82, 54);
            this.chkDuplicateContent.Name = "chkDuplicateContent";
            this.chkDuplicateContent.Size = new System.Drawing.Size(63, 17);
            this.chkDuplicateContent.TabIndex = 4;
            this.chkDuplicateContent.Text = "Content";
            this.chkDuplicateContent.UseVisualStyleBackColor = true;
            this.chkDuplicateContent.CheckedChanged += new System.EventHandler(this.chkDuplicate_CheckedChanged);
            // 
            // chkDuplicateSize
            // 
            this.chkDuplicateSize.AutoSize = true;
            this.chkDuplicateSize.Location = new System.Drawing.Point(82, 31);
            this.chkDuplicateSize.Name = "chkDuplicateSize";
            this.chkDuplicateSize.Size = new System.Drawing.Size(46, 17);
            this.chkDuplicateSize.TabIndex = 3;
            this.chkDuplicateSize.Text = "Size";
            this.chkDuplicateSize.UseVisualStyleBackColor = true;
            this.chkDuplicateSize.CheckedChanged += new System.EventHandler(this.chkDuplicate_CheckedChanged);
            // 
            // chkDuplicateName
            // 
            this.chkDuplicateName.AutoSize = true;
            this.chkDuplicateName.Location = new System.Drawing.Point(82, 8);
            this.chkDuplicateName.Name = "chkDuplicateName";
            this.chkDuplicateName.Size = new System.Drawing.Size(71, 17);
            this.chkDuplicateName.TabIndex = 2;
            this.chkDuplicateName.Text = "File name";
            this.chkDuplicateName.UseVisualStyleBackColor = true;
            this.chkDuplicateName.CheckedChanged += new System.EventHandler(this.chkDuplicate_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Scan for";
            // 
            // tabConfig
            // 
            this.tabConfig.ImageKey = "Config.png";
            this.tabConfig.Location = new System.Drawing.Point(4, 23);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Size = new System.Drawing.Size(672, 154);
            this.tabConfig.TabIndex = 5;
            this.tabConfig.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Config.png");
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(698, 33);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(698, 62);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Please specify the path where to start searching.";
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.toolStripStatusLabel2,
            this.statusLabelExceptions,
            this.statusProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 414);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(785, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(668, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // statusLabelExceptions
            // 
            this.statusLabelExceptions.IsLink = true;
            this.statusLabelExceptions.Name = "statusLabelExceptions";
            this.statusLabelExceptions.Size = new System.Drawing.Size(0, 17);
            this.statusLabelExceptions.Click += new System.EventHandler(this.statusLabelExceptions_Click);
            // 
            // statusProgress
            // 
            this.statusProgress.Name = "statusProgress";
            this.statusProgress.Size = new System.Drawing.Size(100, 16);
            // 
            // lstResults
            // 
            this.lstResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstResults.Location = new System.Drawing.Point(12, 199);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(761, 212);
            this.lstResults.TabIndex = 4;
            this.lstResults.FileOpened += new System.EventHandler<FileSearcher.Ui.Entries.PathEventArgs>(this.lstResults_FileOpened);
            this.lstResults.DirectoryOpened += new System.EventHandler<FileSearcher.Ui.Entries.PathEventArgs>(this.lstResults_DirectoryOpened);
            this.lstResults.Enter += new System.EventHandler(this.lstResults_Enter);
            this.lstResults.Leave += new System.EventHandler(this.lstResults_Leave);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(785, 436);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tabsFilterOptions);
            this.MinimumSize = new System.Drawing.Size(530, 370);
            this.Name = "MainForm";
            this.Text = "Where is it?";
            this.tabsFilterOptions.ResumeLayout(false);
            this.tabBasic.ResumeLayout(false);
            this.tabBasic.PerformLayout();
            this.tabContent.ResumeLayout(false);
            this.tabContent.PerformLayout();
            this.tabDates.ResumeLayout(false);
            this.tabDates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDateOlderValue)).EndInit();
            this.tabOthers.ResumeLayout(false);
            this.tabOthers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSizeValue)).EndInit();
            this.tabDuplicates.ResumeLayout(false);
            this.tabDuplicates.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader lstcPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkRecursive;
        private System.Windows.Forms.CheckBox chkRegularExpressions;
        private System.Windows.Forms.TabControl tabsFilterOptions;
        private System.Windows.Forms.TabPage tabBasic;
        private System.Windows.Forms.TabPage tabDates;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private LargeListViewUserControl lstResults;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ComboBox cmbCriteria;
        private System.Windows.Forms.TabPage tabContent;
        private System.Windows.Forms.CheckBox chkIgnoreCase;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TabPage tabOthers;
        private System.Windows.Forms.CheckBox chkAttributeReadonly;
        private System.Windows.Forms.CheckBox chkAttributeHidden;
        private System.Windows.Forms.CheckBox chkAttributeEncrypted;
        private System.Windows.Forms.CheckBox chkAttributeCompressed;
        private System.Windows.Forms.CheckBox chkAttributeSparse;
        private System.Windows.Forms.CheckBox chkAttributeTemporary;
        private System.Windows.Forms.CheckBox chkAttributeArchive;
        private System.Windows.Forms.CheckBox chkAttributeSystem;
        private System.Windows.Forms.CheckBox chkIncludeFoldersInResults;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSizeOperator;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numSizeValue;
        private System.Windows.Forms.ComboBox cmbSizeMultiplier;
        private System.Windows.Forms.CheckBox chkSizeEnabled;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkDateCreated;
        private System.Windows.Forms.CheckBox chkDateChanged;
        private System.Windows.Forms.CheckBox chkDateAccessed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbDateOlderMultiplier;
        private System.Windows.Forms.DateTimePicker dateDateBetweenEnd;
        private System.Windows.Forms.DateTimePicker dateDateBetweenStart;
        private System.Windows.Forms.NumericUpDown numDateOlderValue;
        private System.Windows.Forms.CheckBox chkDateBetweenEnabled;
        private System.Windows.Forms.CheckBox chkDateOlderEnabled;
        private System.Windows.Forms.ComboBox cmbContent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkContentRegex;
        private System.Windows.Forms.CheckBox chkContentIgnoreCase;
        private System.Windows.Forms.CheckBox chkContentWholeWords;
        private System.Windows.Forms.CheckBox chkContentEncodingUtf16Little;
        private System.Windows.Forms.CheckBox chkContentEncodingAscii;
        private System.Windows.Forms.CheckBox chkContentEncodingUtf8;
        private System.Windows.Forms.CheckBox chkContentEncodingAnsii;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkContentEncodingUtf16Big;
        private System.Windows.Forms.CheckBox chkContentEncodingDetect;
        private System.Windows.Forms.TabPage tabDuplicates;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkDuplicateContent;
        private System.Windows.Forms.CheckBox chkDuplicateSize;
        private System.Windows.Forms.CheckBox chkDuplicateName;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripProgressBar statusProgress;
        private System.Windows.Forms.CheckBox chkFolderFavorites;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ComboBox cmbFolder;
        private System.Windows.Forms.TabPage tabConfig;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox chkMatchFullPath;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelExceptions;
        private System.Windows.Forms.CheckBox chkSearchInZip;
        private System.Windows.Forms.CheckBox chkContentInOfficeFiles;
    }
}

