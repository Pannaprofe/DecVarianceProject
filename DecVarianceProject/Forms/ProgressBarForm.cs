using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecVarianceProject
{
    public partial class ProgressBarForm : Form
    {
        public ProgressBarForm(int max)
        {
            InitializeComponent();
            progressBar.Maximum = max;
            this.Show();
        }

        public void IncProgressBarValue()
        {
            progressBar.Value++;
            if (progressBar.Value == progressBar.Maximum)
            {
                this.Close();
            }
            double tmp = progressBar.Value / progressBar.Maximum;
            LBL.Text = Convert.ToString(Math.Round(tmp,2) * 100) + "%";
            progressBar.Refresh();
        }
    }
}
