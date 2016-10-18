using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileSearcher.Plugin.PsExecutable
{
    public partial class PsExecutableTabPage : UserControl
    {
        public PsExecutableTabPage()
        {
            InitializeComponent();
        }

        public bool ScriptEnabled
        {
            get { return chkEnabled.Checked; }
        }

        public string ScriptPath
        {
            get { return txtFile.Text; }
        }

        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            txtFile.Enabled = chkEnabled.Checked;
            btnBrowse.Enabled = chkEnabled.Checked;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = openFileDialog.FileName;
            }
        }
    }
}
