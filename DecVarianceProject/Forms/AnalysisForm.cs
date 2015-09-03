using System;
using System.Windows.Forms;

namespace DecVarianceProject.Forms
{
    public partial class AnalysisForm : Form
    {
        public string Path { get; private set; }
        public string FolderName { get; private set; }
        public AnalysisForm()
        {
            InitializeComponent();
        }

        private void OpenFolderBTN_Click(object sender, EventArgs e)
        {
            var ofd = new FolderBrowserDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                PathTBX.Text = ofd.SelectedPath;
                Path = ofd.SelectedPath;
                RetrieveFolderName();
            }
        }

        private void RetrieveFolderName()
        {
            var found = Path.LastIndexOf(@"\", StringComparison.Ordinal);
            FolderName = Path.Substring(found+1);
        }

        private void RunBTN_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
