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
        public List<MatchParams> Probs { get; private set; }
        public int MatchesNum { get; private set; }
        private Random RandomNum = new Random();

        public MatchDayResultsDialog(int matchesNum,bool IsAutomatic,List<MatchParams> probs)
        {
            this.Probs = probs;
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

        private string GenMatchResults(bool automaticGen,int matchNum)
        {
            if (automaticGen)
            {
                int range = 1000;
                int middleLowEdge = (int)(Probs[matchNum].P1 * range);
                int middleHighEdge = (int)(Probs[matchNum].P2 * range) + middleLowEdge;
                int res = RandomNum.Next(0, range);
                if (res < middleLowEdge)
                    return "P1";
                if ((res >= middleLowEdge) && (res < middleHighEdge))
                    return "P2";
                else
                    return "X";
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
                    MatchOutcome = GenMatchResults(AutomaticGen,i)
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
