namespace FileSearcher.Ui
{
    partial class ExceptionsForm
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
            System.Windows.Forms.Panel panel2;
            System.Windows.Forms.Label label1;
            this.btnClose = new System.Windows.Forms.Button();
            this.lstItems = new System.Windows.Forms.ListView();
            this.lstcFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstcException = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            panel2 = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(this.btnClose);
            panel2.Controls.Add(label1);
            panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel2.Location = new System.Drawing.Point(0, 283);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(634, 41);
            panel2.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(547, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.BackColor = System.Drawing.SystemColors.WindowFrame;
            label1.Dock = System.Windows.Forms.DockStyle.Top;
            label1.Location = new System.Drawing.Point(0, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(634, 1);
            label1.TabIndex = 0;
            // 
            // lstItems
            // 
            this.lstItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lstcFile,
            this.lstcException});
            this.lstItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstItems.FullRowSelect = true;
            this.lstItems.GridLines = true;
            this.lstItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstItems.Location = new System.Drawing.Point(0, 0);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(634, 283);
            this.lstItems.TabIndex = 2;
            this.lstItems.UseCompatibleStateImageBehavior = false;
            this.lstItems.View = System.Windows.Forms.View.Details;
            this.lstItems.VirtualMode = true;
            this.lstItems.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lstItems_RetrieveVirtualItem);
            // 
            // lstcFile
            // 
            this.lstcFile.Text = "File";
            this.lstcFile.Width = 400;
            // 
            // lstcException
            // 
            this.lstcException.Text = "Error";
            this.lstcException.Width = 200;
            // 
            // ExceptionsForm
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(634, 324);
            this.Controls.Add(this.lstItems);
            this.Controls.Add(panel2);
            this.MinimizeBox = false;
            this.Name = "ExceptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Exceptions";
            panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView lstItems;
        private System.Windows.Forms.ColumnHeader lstcFile;
        private System.Windows.Forms.ColumnHeader lstcException;
    }
}