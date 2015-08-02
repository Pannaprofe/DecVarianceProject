using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Windows.Forms;
using DecVarianceProject.Properties;
using DecVarianceProject.Structures.DataGridViewsRepositoryFolder;
using DecVarianceProject.Structures.Tables;

namespace DecVarianceProject.Forms
{
    public partial class TestEstimationForm : Form
    {
        public List<TestTable> TestTableList { get; private set; }

        public double EvBefore { get; private set; }
        public double EvAfter { get; private set; }
        public double VarianceBefore { get; private set; }
        public double VarianceAfter { get; private set; }
        public double EvProfit { get; private set; }
        public double VarianceDiff { get; private set; }


        public TestEstimationForm(List<TestTable> list)
        {
            TestTableList = list;
            InitializeComponent();
            var testListResults = new List<ITablesContent>(list);
            var test = new Test() { Dgv = dataGridViewTest, ListContent = testListResults };
            test.ConfigureDgv();
            EstimateEv();
            EstimateVariance();
            MarathonEVBeforeTBX.Text = Convert.ToString(EvBefore, CultureInfo.InvariantCulture);
            MarathonEVAfterTBX.Text = Convert.ToString(EvAfter, CultureInfo.InvariantCulture);
            VarianceBeforeTBX.Text = Convert.ToString(VarianceBefore, CultureInfo.InvariantCulture);
            VarianceAfterTBX.Text = Convert.ToString(VarianceAfter, CultureInfo.InvariantCulture);
            EvProfitTBX.Text = Convert.ToString(EvProfit, CultureInfo.InvariantCulture);
            VarianceDifferenceTBX.Text = Convert.ToString(VarianceDiff, CultureInfo.InvariantCulture);
        }

        private void EstimateEv()
        {
            foreach (var row in TestTableList)
            {
                EvBefore += row.NetWonBefore;
                EvAfter += row.NetWonAfter;
            }
            EvBefore /= TestTableList.Count;
            EvAfter /= TestTableList.Count;
            EvProfit = (EvAfter - EvBefore) / EvBefore;
            EvProfit = Math.Round(EvProfit, 3);
        }

        private void EstimateVariance()
        {
            foreach(var row in TestTableList)
            {
                VarianceBefore += Math.Pow(row.NetWonBefore - EvBefore, 2);
                VarianceAfter += Math.Pow(row.NetWonAfter - EvAfter, 2);
            }
            VarianceBefore /= TestTableList.Count;
            VarianceAfter /= TestTableList.Count;
            VarianceDiff = (VarianceAfter - VarianceBefore)/VarianceBefore;
            VarianceDiff = Math.Round(VarianceDiff, 3);
        }

        private void OKBTN_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                Filter =
                    Resources.TestEstimationForm_saveToolStripMenuItem_Click_omg_files____omg____omg_All_files__________
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileActions.Save(sfd.FileName,TestTableList);
            }
        }


    }
}
