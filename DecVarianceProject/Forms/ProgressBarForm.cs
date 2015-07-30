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

        public void SetProgressBarValue(int value)
        {
            progressBar.Value = value;
            if (progressBar.Value == progressBar.Maximum)
            {
                this.Close();
            }
            progressBar.Refresh();
        }
    }
}
