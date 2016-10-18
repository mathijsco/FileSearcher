using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace FileSearcher.Plugin.CSharp
{
    public partial class DotNetTabPage : UserControl
    {
        private string _originalAssembly;
        private string _folderLocation;
        private AssemblyName _assemblyName;

        public DotNetTabPage()
        {
            InitializeComponent();
        }

        internal DotNetOptions GetOptions()
        {
            return new DotNetOptions
            {
                AssemblyName = chkAssembly.Checked ? _assemblyName : null,
                AssemblyPath = chkFile.Checked ? _originalAssembly : null,
                AssembliesFolder = chkFolder.Checked ? _folderLocation : null
            };
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if ((chkAssembly.Checked || chkFile.Checked) && openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _originalAssembly = openFileDialog1.FileName;
                    _assemblyName = AssemblyName.GetAssemblyName(openFileDialog1.FileName);
                    _folderLocation = Path.GetDirectoryName(_originalAssembly);
                    folderBrowserDialog1.SelectedPath = _folderLocation;

                    if (chkAssembly.Checked)
                        txtReference.Text = _assemblyName.FullName;
                    else
                        txtReference.Text = _originalAssembly;
                }
                catch (BadImageFormatException)
                {
                    MessageBox.Show(@"Only .NET assemblies are supported.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (chkFolder.Checked && folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                _originalAssembly = null;
                _assemblyName = null;
                _folderLocation = folderBrowserDialog1.SelectedPath;
                txtReference.Text = _folderLocation;
            }
        }

        private void chkAssembly_CheckedChanged(object sender, EventArgs e)
        {
            var checkbox = (CheckBox) sender;
            var enabled = chkFile.Checked || chkAssembly.Checked || chkFolder.Checked;
            txtReference.Enabled = enabled;
            btnBrowseReference.Enabled = enabled;

            if (checkbox.Checked)
            {
                if (checkbox == chkAssembly)
                {
                    chkFile.Checked = false;
                    chkFolder.Checked = false;
                    txtReference.Text = _assemblyName != null ? _assemblyName.FullName : null;
                }
                else if (checkbox == chkFile)
                {
                    chkFolder.Checked = false;
                    chkAssembly.Checked = false;
                    txtReference.Text = _originalAssembly;
                }
                else if (checkbox == chkFolder)
                {
                    chkFile.Checked = false;
                    chkAssembly.Checked = false;
                    txtReference.Text = _folderLocation;
                }
            }
        }
    }
}
