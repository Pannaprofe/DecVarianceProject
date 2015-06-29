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
    public partial class Form1 : Form
    {
        private int MatchesNum = 6;
        private const double Rake = 0.05;
        private int NumberOfBets = 2;
        private int MaxWinnings = 10000;
        private ProbsCoefsCreator Creator;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void RunBtn_Click(object sender, EventArgs e)
        {
            if ((MatchesNumTxtBx.Text == "") && (BetsNumTxtBx.Text == ""))
            {
                MessageBox.Show("Invalid input");
            }
            else
            {
                this.MatchesNum = Convert.ToInt32(MatchesNumTxtBx.Text);
                this.NumberOfBets = Convert.ToInt32(BetsNumTxtBx.Text);
                Creator = new ProbsCoefsCreator(MatchesNum, Rake, NumberOfBets, MaxWinnings);
                dataGridViewResults.DataSource = Creator.Tree.AllResultsInTable;
                dataGridViewProbsCoefs.DataSource = Creator.GennedParams;
                dataGridViewBets.DataSource = Creator.AllMadeBets;
            }
        }
        
        private void MatchesNumTxtBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && (ch != 8) && (ch != 46))  // turning on backspace and del keys
                e.Handled = true;
        }
        private void BetsNumTxtBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && (ch != 8) && (ch != 46))  // turning on backspace and del keys
                e.Handled = true;
        }
        private void MatchesNumTxtBx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MatchesNum = Convert.ToInt32(MatchesNumTxtBx.Text);
            }
            catch
            {

            }
        }
        private void BetsNumTxtBx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                NumberOfBets = Convert.ToInt32(BetsNumTxtBx.Text);
            }
            catch
            {

            }
        }
    }
}
