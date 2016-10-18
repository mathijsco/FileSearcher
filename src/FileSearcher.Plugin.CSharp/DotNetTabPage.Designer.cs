namespace FileSearcher.Plugin.CSharp
{
    partial class DotNetTabPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DotNetTabPage));
            this.label1 = new System.Windows.Forms.Label();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.btnBrowseReference = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chkFile = new System.Windows.Forms.CheckBox();
            this.chkAssembly = new System.Windows.Forms.CheckBox();
            this.chkFolder = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "References";
            // 
            // txtReference
            // 
            this.txtReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReference.Enabled = false;
            this.txtReference.Location = new System.Drawing.Point(79, 102);
            this.txtReference.Name = "txtReference";
            this.txtReference.ReadOnly = true;
            this.txtReference.Size = new System.Drawing.Size(386, 20);
            this.txtReference.TabIndex = 3;
            // 
            // btnBrowseReference
            // 
            this.btnBrowseReference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseReference.Enabled = false;
            this.btnBrowseReference.Location = new System.Drawing.Point(471, 100);
            this.btnBrowseReference.Name = "btnBrowseReference";
            this.btnBrowseReference.Size = new System.Drawing.Size(41, 23);
            this.btnBrowseReference.TabIndex = 5;
            this.btnBrowseReference.Text = "...";
            this.btnBrowseReference.UseVisualStyleBackColor = true;
            this.btnBrowseReference.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.exe;*.dll";
            this.openFileDialog1.Filter = "All supported files|*.exe;*.dll";
            // 
            // chkFile
            // 
            this.chkFile.AutoSize = true;
            this.chkFile.Location = new System.Drawing.Point(195, 79);
            this.chkFile.Name = "chkFile";
            this.chkFile.Size = new System.Drawing.Size(120, 17);
            this.chkFile.TabIndex = 7;
            this.chkFile.Text = "Specific file location";
            this.chkFile.UseVisualStyleBackColor = true;
            this.chkFile.CheckedChanged += new System.EventHandler(this.chkAssembly_CheckedChanged);
            // 
            // chkAssembly
            // 
            this.chkAssembly.AutoSize = true;
            this.chkAssembly.Location = new System.Drawing.Point(79, 79);
            this.chkAssembly.Name = "chkAssembly";
            this.chkAssembly.Size = new System.Drawing.Size(99, 17);
            this.chkAssembly.TabIndex = 8;
            this.chkAssembly.Text = "Assembly name";
            this.chkAssembly.UseVisualStyleBackColor = true;
            this.chkAssembly.CheckedChanged += new System.EventHandler(this.chkAssembly_CheckedChanged);
            // 
            // chkFolder
            // 
            this.chkFolder.AutoSize = true;
            this.chkFolder.Location = new System.Drawing.Point(327, 79);
            this.chkFolder.Name = "chkFolder";
            this.chkFolder.Size = new System.Drawing.Size(130, 17);
            this.chkFolder.TabIndex = 9;
            this.chkFolder.Text = "Any assembly in folder";
            this.chkFolder.UseVisualStyleBackColor = true;
            this.chkFolder.CheckedChanged += new System.EventHandler(this.chkAssembly_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(509, 70);
            this.label2.TabIndex = 10;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.SelectedPath = "Select a folder where the assemblies are located";
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // DotNetTabPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkFolder);
            this.Controls.Add(this.chkAssembly);
            this.Controls.Add(this.chkFile);
            this.Controls.Add(this.btnBrowseReference);
            this.Controls.Add(this.txtReference);
            this.Controls.Add(this.label1);
            this.Name = "DotNetTabPage";
            this.Size = new System.Drawing.Size(515, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReference;
        private System.Windows.Forms.Button btnBrowseReference;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox chkFile;
        private System.Windows.Forms.CheckBox chkAssembly;
        private System.Windows.Forms.CheckBox chkFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;

    }
}
