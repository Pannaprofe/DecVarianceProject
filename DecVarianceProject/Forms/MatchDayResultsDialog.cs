using DecVarianceProject.Structures.Tables;
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
    public partial class MatchDayResultsDialog : Form
    {
        public List<MatchDayResultsTable> MatchDayResultsList { get; private set; }

        public MatchDayResults Match_Day_Results { get; private set; }
        public int MatchesNum { get; private set; }
        private Random RandomNum = new Random();

        public MatchDayResultsDialog(int matchesNum,bool IsAutomatic)
        {
            MatchesNum = matchesNum;
            InitializeComponent();
            dataGridViewMatchDayResults.Visible = false;
            MatchDayResultsList = new List<MatchDayResultsTable>();
            this.AcceptButton = OkBTN;
            if (IsAutomatic)
                OkBTN_Click(this, new EventArgs());
        }

        private void OkBTN_Click(object sender, EventArgs e)
        {
            CreateTable(true);
            MatchDayResultsList = DgvToList(dataGridViewMatchDayResults);
            this.Close();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public List<MatchDayResultsTable> DgvToList(DataGridView dgv)
        {
            List<MatchDayResultsTable> items = new List<MatchDayResultsTable>();
            foreach (DataGridViewRow dr in dgv.Rows)
            {
                int matchnum = 0;
                string outcome = String.Empty;
                foreach (DataGridViewCell dc in dr.Cells)
                { 
                    if (dc.OwningColumn.Name == "MatchNum")
                    {
                        matchnum = Convert.ToInt32(dc.Value);
                    }
                    if (dc.OwningColumn.Name == "Outcome")
                    {
                        outcome = Convert.ToString(dc.Value);
                    }
                }
                MatchDayResultsTable item = new MatchDayResultsTable()
                {
                    MatchNum = matchnum,
                    MatchOutcome = outcome
                };
                items.Add(item);
            }
            return items;
        }

        private string GenMatchResults(bool AutomaticGen)
        {
            if (AutomaticGen)
            {
                int res = RandomNum.Next(0, 3);
                return (res > 0) ? "P" + res : "X";
            }
            else
            {
                return String.Empty;
            }
        }

        private void CreateTable(bool AutomaticGen)
        {
            //clear datagridview
            if (this.dataGridViewMatchDayResults.DataSource != null)
            {
                 this.dataGridViewMatchDayResults.DataSource = null;
                 this.dataGridViewMatchDayResults.Refresh();
            }
            else
            {
                this.dataGridViewMatchDayResults.Rows.Clear();
                this.dataGridViewMatchDayResults.Refresh();
            }
            MatchDayResultsList.Clear();
            //-----------------
            
            for (int i = 0; i < MatchesNum; i++)
            {
                var result = new MatchDayResultsTable()
                {
                    MatchNum = i,
                    MatchOutcome = GenMatchResults(AutomaticGen)
                };
                MatchDayResultsList.Add(result);
            }
            Match_Day_Results = new MatchDayResults() { DGV = dataGridViewMatchDayResults, ListContent = new List<TablesContent>(MatchDayResultsList) };
            Match_Day_Results.ConfigureDGV();
        }

        private void AutomaticallyRdBtn_Click(object sender, EventArgs e)
        {
            CreateTable(true);
            dataGridViewMatchDayResults.Visible = false;
        }

        private void ManuallyRdBtn_Click(object sender, EventArgs e)
        {
            CreateTable(false);
            dataGridViewMatchDayResults.Visible = true;
        }
    }
}
