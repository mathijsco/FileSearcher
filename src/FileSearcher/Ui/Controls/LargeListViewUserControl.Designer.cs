namespace FileSearcher.Ui.Controls
{
    partial class LargeListViewUserControl
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
            this.lstItems = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lstItems
            // 
            this.lstItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstItems.FullRowSelect = true;
            this.lstItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstItems.Location = new System.Drawing.Point(0, 0);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(483, 307);
            this.lstItems.TabIndex = 0;
            this.lstItems.UseCompatibleStateImageBehavior = false;
            this.lstItems.View = System.Windows.Forms.View.Details;
            this.lstItems.VirtualMode = true;
            this.lstItems.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.RetrieveVirtualItem);
            this.lstItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstItems_KeyDown);
            this.lstItems.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstItems_MouseDoubleClick);
            // 
            // LargeListViewUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstItems);
            this.Name = "LargeListViewUserControl";
            this.Size = new System.Drawing.Size(483, 307);
            this.SizeChanged += new System.EventHandler(this.LargeListViewUserControl_SizeChanged);
            this.Enter += new System.EventHandler(this.LargeListViewUserControl_Enter);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstItems;
    }
}
