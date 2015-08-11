using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DecVarianceProject.Structures;

namespace DecVarianceProject.Forms
{
    public partial class MatchDayResultsDialog : Form
    {
        private Singleton Instance = Singleton.Instance;
        

        private readonly Random _randomNum = new Random();

        public MatchDayResultsDialog(bool isAutomatic)
        {
            InitializeComponent();
            dataGridViewMatchDayResults.Visible = false;
            Instance.MatchDayResults = new List<MatchDayResultsTableContent>();
            AcceptButton = OkBTN;
            if (isAutomatic)
                OkBTN_Click(this, new EventArgs());
        }

        private void OkBTN_Click(object sender, EventArgs e)
        {
            CreateTable(true);
            Instance.MatchDayResults = DgvToList(dataGridViewMatchDayResults);
            Close();
            DialogResult = DialogResult.OK;
        }

        public List<MatchDayResultsTableContent> DgvToList(DataGridView dgv)
        {
            List<MatchDayResultsTableContent> items = new List<MatchDayResultsTableContent>();
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
                MatchDayResultsTableContent item = new MatchDayResultsTableContent()
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
                int middleLowEdge = (int)(Instance.ProbsMarathon[matchNum][1] * range);
                int middleHighEdge = (int)(Instance.ProbsMarathon[matchNum][2] * range) + middleLowEdge;
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
            Instance.MatchDayResults.Clear();
            //-----------------
            
            for (int i = 0; i < Instance.MatchesNum; i++)
            {
                var result = new MatchDayResultsTableContent()
                {
                    MatchNum = i,
                    MatchOutcome = GenMatchResults(automaticGen,i)
                };
                Instance.MatchDayResults.Add(result);
            }
            Instance.MatchDayResultsTable = new MatchDayResultsTable() { Dgv = dataGridViewMatchDayResults, ListContent = new List<ITablesContent>(Instance.MatchDayResults) };
            Instance.MatchDayResultsTable.ConfigureDgv();
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
