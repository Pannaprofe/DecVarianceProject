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
    public partial class MainForm : Form
    {
        private int MatchesNum = 6;
        private const double Rake = 0.05;
        private int NumberOfBets = 2;
        private int MaxWinnings = 10000;
        private ProbsCoefsCreator Creator;

        public MainForm()
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
                ConfigureBetsInfoTableAppearence();
                ConfigureResultsTableAppearence();
                ConfigureCoefsProbsTableAppearence();
                //this.dataGridViewBets.Sort(this.dataGridViewBets.Columns[0], ListSortDirection.Descending);
            }
        }

        private void ConfigureBetsInfoTableAppearence()
        {
            dataGridViewBets.ReadOnly = true;
            DataGridViewColumn betNumColumn = dataGridViewBets.Columns[0];
            betNumColumn.Width = 50;
            DataGridViewColumn betSizeColumn = dataGridViewBets.Columns[1];
            betSizeColumn.Width = 60;
            DataGridViewColumn coefColumn = dataGridViewBets.Columns[2];
            coefColumn.Width = 70;
            DataGridViewColumn chosenMatchesResultsColumn = dataGridViewBets.Columns[3];
            chosenMatchesResultsColumn.Width = dataGridViewBets.Width - (betSizeColumn.Width + coefColumn.Width + betNumColumn.Width);
        }

        private void ConfigureResultsTableAppearence()
        {
            dataGridViewResults.ReadOnly = true;
            DataGridViewColumn nodeNumColumn = dataGridViewResults.Columns[0];
            nodeNumColumn.Width = 50;
            DataGridViewColumn probabilityColumn = dataGridViewResults.Columns[1];
            probabilityColumn.Width = 60;
            int patternWidth = (int)dataGridViewResults.Width/6;
            DataGridViewColumn paymentsColumn = dataGridViewResults.Columns[2];
            paymentsColumn.Width = patternWidth;
            DataGridViewColumn winningsColumn = dataGridViewResults.Columns[3];
            winningsColumn.Width = patternWidth;
            DataGridViewColumn netWonColumn = dataGridViewResults.Columns[4];
            netWonColumn.Width = patternWidth;
            DataGridViewColumn pathColumn = dataGridViewResults.Columns[5];
            pathColumn.Width = dataGridViewResults.Width - (nodeNumColumn.Width + probabilityColumn.Width + paymentsColumn.Width + winningsColumn.Width + netWonColumn.Width);
        }

        private void ConfigureCoefsProbsTableAppearence()
        {
            dataGridViewProbsCoefs.ReadOnly = true;
            foreach (DataGridViewColumn column in dataGridViewProbsCoefs.Columns)
            {
                dataGridViewProbsCoefs.Columns[column.Name].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            DataGridViewColumn matchNumColumn = dataGridViewProbsCoefs.Columns[0];
            matchNumColumn.Width = 40;
            
            int patternWidth = (int)(dataGridViewProbsCoefs.Width - matchNumColumn.Width)/6;
            DataGridViewColumn probP1Column = dataGridViewProbsCoefs.Columns[1];
            probP1Column.Width = patternWidth;
            DataGridViewColumn probXColumn = dataGridViewProbsCoefs.Columns[2];
            probXColumn.Width = patternWidth;
            DataGridViewColumn probP2Column = dataGridViewProbsCoefs.Columns[3];
            probP2Column.Width = patternWidth;
            DataGridViewColumn coefP1Column = dataGridViewProbsCoefs.Columns[4];
            coefP1Column.Width = patternWidth;
            DataGridViewColumn coefXColumn = dataGridViewProbsCoefs.Columns[5];
            coefXColumn.Width = patternWidth;
            DataGridViewColumn coefP2Column = dataGridViewProbsCoefs.Columns[6];
            coefP2Column.Width = patternWidth;
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
