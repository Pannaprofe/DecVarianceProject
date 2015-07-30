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
    public partial class TestEstimationForm : Form
    {
        public List<TestTable> TestTableList { get; private set; }

        public double EVBefore { get; private set; }
        public double EVAfter { get; private set; }
        public double VarianceBefore { get; private set; }
        public double VarianceAfter { get; private set; }
        public TestEstimationForm(List<TestTable> list)
        {
            this.TestTableList = list;
            List<TablesContent> testList = new List<TablesContent>(list);
            InitializeComponent();
            Test test = new Test() { DGV = dataGridViewTest, ListContent = testList };
            test.ConfigureDGV();
            EstimateEV();
            EstimateVariance();
            MarathonEVBeforeTBX.Text = Convert.ToString(EVBefore);
            MarathonEVAfterTBX.Text = Convert.ToString(EVAfter);
            VarianceBeforeTBX.Text = Convert.ToString(VarianceBefore);
            VarianceAfterTBX.Text = Convert.ToString(VarianceAfter);
        }

        private void EstimateEV()
        {
            foreach (var row in TestTableList)
            {
                EVBefore += row.NetWonBefore;
                EVAfter += row.NetWonAfter;
            }
            EVBefore /= TestTableList.Count;
            EVAfter /= TestTableList.Count;
        }

        private void EstimateVariance()
        {
            foreach(var row in TestTableList)
            {
                VarianceBefore += Math.Pow(row.NetWonBefore - EVBefore, 2);
                VarianceAfter += Math.Pow(row.NetWonAfter - EVAfter, 2);
            }
            VarianceBefore /= TestTableList.Count;
            VarianceAfter /= TestTableList.Count;
        }

        private void OKBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "omg files (*.omg)|*.omg|All files (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {

            }
        }

    }
}
