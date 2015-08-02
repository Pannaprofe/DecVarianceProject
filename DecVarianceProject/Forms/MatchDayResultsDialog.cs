using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DecVarianceProject.Structures;
using DecVarianceProject.Structures.DataGridViewsRepositoryFolder;
using DecVarianceProject.Structures.Tables;

namespace DecVarianceProject.Forms
{
    public partial class MatchDayResultsDialog : Form
    {
        public List<MatchDayResultsTable> MatchDayResultsList { get; private set; }

        public MatchDayResults MatchDayResults { get; private set; }
        public List<MatchParams> Probs { get; private set; }
        public int MatchesNum { get; private set; }
        private readonly Random _randomNum = new Random();

        public MatchDayResultsDialog(int matchesNum,bool isAutomatic,List<MatchParams> probs)
        {
            Probs = probs;
            MatchesNum = matchesNum;
            InitializeComponent();
            dataGridViewMatchDayResults.Visible = false;
            MatchDayResultsList = new List<MatchDayResultsTable>();
            AcceptButton = OkBTN;
            if (isAutomatic)
                OkBTN_Click(this, new EventArgs());
        }

        private void OkBTN_Click(object sender, EventArgs e)
        {
            CreateTable(true);
            MatchDayResultsList = DgvToList(dataGridViewMatchDayResults);
            Close();
            DialogResult = DialogResult.OK;
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
                int res = _randomNum.Next(0, range);
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

        private void CreateTable(bool automaticGen)
        {
            //clear datagridview
            if (dataGridViewMatchDayResults.DataSource != null)
            {
                 dataGridViewMatchDayResults.DataSource = null;
                 dataGridViewMatchDayResults.Refresh();
            }
            else
            {
                dataGridViewMatchDayResults.Rows.Clear();
                dataGridViewMatchDayResults.Refresh();
            }
            MatchDayResultsList.Clear();
            //-----------------
            
            for (int i = 0; i < MatchesNum; i++)
            {
                var result = new MatchDayResultsTable()
                {
                    MatchNum = i,
                    MatchOutcome = GenMatchResults(automaticGen,i)
                };
                MatchDayResultsList.Add(result);
            }
            MatchDayResults = new MatchDayResults() { Dgv = dataGridViewMatchDayResults, ListContent = new List<ITablesContent>(MatchDayResultsList) };
            MatchDayResults.ConfigureDgv();
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
