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
                ConfigureDataGridViewBets();
                ConfigureDataGridViewResults();
                ConfigureDataGridViewProbsCoefs();
            }
        }

        private void ConfigureDataGridViewBets()
        {
            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("BetNum").DataType = typeof(Int32);
                table.Columns.Add("BetSize").DataType = typeof(Int32);
                table.Columns.Add("Coef").DataType = typeof(double);
                table.Columns.Add("MatchResults").DataType = typeof(string);
                var list = new List<TablesContent>(Creator.AllMadeBets);
                dataGridViewBets.DataSource = FillInTheTable(table, list);
                dataGridViewBets.ReadOnly = true;
                DataGridViewColumn betNumColumn = dataGridViewBets.Columns["BetNum"];
                betNumColumn.Width = 50;
                DataGridViewColumn betSizeColumn = dataGridViewBets.Columns["BetSize"];
                betSizeColumn.Width = 60;
                DataGridViewColumn coefColumn = dataGridViewBets.Columns["Coef"];
                coefColumn.Width = 70;
                DataGridViewColumn chosenMatchesResultsColumn = dataGridViewBets.Columns["MatchResults"];
                chosenMatchesResultsColumn.Width = dataGridViewBets.Width - (betSizeColumn.Width + coefColumn.Width + betNumColumn.Width);
                BindSortingEventToATableHeader(dataGridViewBets);
            }
            catch
            {
                MessageBox.Show("The Number of Columns is less then requested in DataGridViewBets Table  or cell type missmatch has occured");
                throw;
            }
        }

        private void ConfigureDataGridViewResults()
        {
            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("Node").DataType = typeof(Int32);
                table.Columns.Add("Probability").DataType = typeof(double);
                table.Columns.Add("Payments").DataType = typeof(double);
                table.Columns.Add("Winnings").DataType = typeof(double);
                table.Columns.Add("NetWon").DataType = typeof(double);
                table.Columns.Add("Path").DataType = typeof(string);
                var list = new List<TablesContent>(Creator.Tree.AllResultsInTable);
                dataGridViewResults.DataSource = FillInTheTable(table, list);
                dataGridViewResults.ReadOnly = true;
                DataGridViewColumn nodeNumColumn = dataGridViewResults.Columns["Node"];
                nodeNumColumn.Width = 50;
                DataGridViewColumn probabilityColumn = dataGridViewResults.Columns["Probability"];
                probabilityColumn.Width = 60;
                int patternWidth = (int)dataGridViewResults.Width / 6;
                DataGridViewColumn paymentsColumn = dataGridViewResults.Columns["Payments"];
                paymentsColumn.Width = patternWidth;
                DataGridViewColumn winningsColumn = dataGridViewResults.Columns["Winnings"];
                winningsColumn.Width = patternWidth;
                DataGridViewColumn netWonColumn = dataGridViewResults.Columns["NetWon"];
                netWonColumn.Width = patternWidth;
                DataGridViewColumn pathColumn = dataGridViewResults.Columns["Path"];
                pathColumn.Width = dataGridViewResults.Width - (nodeNumColumn.Width + probabilityColumn.Width + paymentsColumn.Width + winningsColumn.Width + netWonColumn.Width);
                BindSortingEventToATableHeader(dataGridViewResults);
            }
            catch
            {
                MessageBox.Show("The Number of Columns is less then requested in DataGridViewResults Table  or cell type missmatch has occured");
                throw;
            }
        }

        private void ConfigureDataGridViewProbsCoefs()
        {
            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("MatchNum").DataType = typeof(Int32);
                table.Columns.Add("ProbabilityP1").DataType = typeof(double);
                table.Columns.Add("ProbabilityX").DataType = typeof(double);
                table.Columns.Add("ProbabilityP2").DataType = typeof(double);
                table.Columns.Add("CoefP1").DataType = typeof(double);
                table.Columns.Add("CoefX").DataType = typeof(double);
                table.Columns.Add("CoefP2").DataType = typeof(double);
                var list = new List<TablesContent>(Creator.GennedParams);
                dataGridViewProbsCoefs.DataSource = FillInTheTable(table, list);
                dataGridViewProbsCoefs.ReadOnly = true;
                DataGridViewColumn matchNumColumn = dataGridViewProbsCoefs.Columns["MatchNum"];
                matchNumColumn.Width = 40;

                int patternWidth = (int)(dataGridViewProbsCoefs.Width - matchNumColumn.Width) / 6;
                DataGridViewColumn probP1Column = dataGridViewProbsCoefs.Columns["ProbabilityP1"];
                probP1Column.Width = patternWidth;
                DataGridViewColumn probXColumn = dataGridViewProbsCoefs.Columns["ProbabilityX"];
                probXColumn.Width = patternWidth;
                DataGridViewColumn probP2Column = dataGridViewProbsCoefs.Columns["ProbabilityP2"];
                probP2Column.Width = patternWidth;
                DataGridViewColumn coefP1Column = dataGridViewProbsCoefs.Columns["CoefP1"];
                coefP1Column.Width = patternWidth;
                DataGridViewColumn coefXColumn = dataGridViewProbsCoefs.Columns["CoefX"];
                coefXColumn.Width = patternWidth;
                DataGridViewColumn coefP2Column = dataGridViewProbsCoefs.Columns["CoefP2"];
                coefP2Column.Width = patternWidth;
                BindSortingEventToATableHeader(dataGridViewProbsCoefs);
            }
            catch
            {
                MessageBox.Show("The Number of Columns is less then requested in DataGridViewProbsCoefs Table or cell type missmatch has occured");
                throw;
            }
        }

        private DataTable FillInTheTable(DataTable table, List<TablesContent> list)
        {
            foreach (var row in list)
            {
                var properties = row.GetType().GetProperties();
                var propertiesForTableCount = properties.Count() - 1;   // There is no "Count" column in the table
                string[] rowAsTheList = new string[propertiesForTableCount];
                for (int i = 0; i < propertiesForTableCount; i++)
                {
                    rowAsTheList[i] = Convert.ToString(properties[i].GetValue(row, null));
                }
                table.Rows.Add(rowAsTheList);
            }
            return table;
        }
        private void BindSortingEventToATableHeader(DataGridView dgv)
        {
            List<string> sortColumns = new List<string>();
            dgv.ColumnHeaderMouseClick += (o, e) =>
            {
                DataGridView grid = (o as DataGridView);
                string colName = grid.Columns[e.ColumnIndex].DataPropertyName;

                sortColumns.Remove(colName);
                sortColumns.Add(colName);
                string sortExpr = "";
                foreach (string c in sortColumns)
                    sortExpr = c + "," + sortExpr;

                (grid.DataSource as DataTable).DefaultView.Sort = sortExpr.Trim(',');
            };
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
