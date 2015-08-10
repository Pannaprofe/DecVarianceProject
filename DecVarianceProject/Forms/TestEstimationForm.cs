using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Windows.Forms;
using DecVarianceProject.Properties;

namespace DecVarianceProject.Forms
{
    public partial class TestEstimationForm : Form
    {
        public List<TestTableContent> TestTableList { get; private set; }

        public double EvBefore { get; private set; }
        public double EvAfter { get; private set; }
        public double VarianceBefore { get; private set; }
        public double VarianceAfter { get; private set; }
        public double EvProfit { get; private set; }
        public double VarianceDiff { get; private set; }
        public double EV2Before { get; private set; }

        public double EV2After { get; private set; }


        public TestEstimationForm(List<TestTableContent> list)
        {
            TestTableList = list;
            InitializeComponent();
            var testListResults = new List<ITablesContent>(list);
            EstimateEv();
            EstimateVariance();
            var test = new TestTable() { Dgv = dataGridViewTest, ListContent = testListResults };
            test.ConfigureDgv();

            MarathonEVBeforeTBX.Text = Convert.ToString(EvBefore, CultureInfo.InvariantCulture);
            MarathonEVAfterTBX.Text = Convert.ToString(EvAfter, CultureInfo.InvariantCulture);
            VarianceBeforeTBX.Text = Convert.ToString(VarianceBefore, CultureInfo.InvariantCulture);
            VarianceAfterTBX.Text = Convert.ToString(VarianceAfter, CultureInfo.InvariantCulture);
            EvProfitTBX.Text = Convert.ToString(EvProfit, CultureInfo.InvariantCulture);
            VarianceDifferenceTBX.Text = Convert.ToString(VarianceDiff, CultureInfo.InvariantCulture);
        }

        private void EstimateEv()
        {
            int i = 1;
            foreach (var row in TestTableList)
            {
                EvBefore += row.NetWonBefore;
                EvAfter += row.NetWonAfter;
                EV2Before += Math.Pow(row.NetWonBefore, 2);
                EV2After += Math.Pow(row.NetWonAfter, 2);
                row.EVDifference = EvAfter/i - EvBefore/i;
                i++;
            }
            EvBefore /= TestTableList.Count;
            EvAfter /= TestTableList.Count;
            EV2After /= TestTableList.Count;
            EV2Before /= TestTableList.Count;
            EvProfit = (EvAfter - EvBefore) / EvBefore;
            EvProfit = Math.Round(EvProfit, 3);
        }

        

        private void EstimateVariance()
        {
            VarianceBefore = EV2Before - Math.Pow(EvBefore, 2);
            VarianceAfter = EV2After - Math.Pow(EvAfter, 2);
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
