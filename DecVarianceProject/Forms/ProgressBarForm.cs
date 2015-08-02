using System;
using System.Globalization;
using System.Windows.Forms;
using DecVarianceProject.Properties;

namespace DecVarianceProject.Forms
{
    public partial class ProgressBarForm : Form
    {
        public ProgressBarForm(int max)
        {
            InitializeComponent();
            progressBar.Maximum = max;
            Show();
        }

        public void IncProgressBarValue()
        {
            progressBar.Value++;
            if (progressBar.Value == progressBar.Maximum)
            {
                Close();
            }
            // ReSharper disable once PossibleLossOfFraction
            double tmp = progressBar.Value / progressBar.Maximum;
            LBL.Text = Convert.ToString(Math.Round(tmp,2) * 100, CultureInfo.InvariantCulture) + Resources.ProgressBarForm_IncProgressBarValue__;
            progressBar.Refresh();
        }
    }
}
