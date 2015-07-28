using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecVarianceProject
{
    public partial class MainForm : Form
    {
        private int MatchesNum;
        private double Rake;
        private int BetsNum;
        private int MaxWinnings = 10000;
        private int ReBetMatchesNum;
        private ProbsCoefsBetsCreator Creator;
        private MatchDayResultsDialog Dialog;
        private double RaiseSumPercent;
        private double RaiseSum;
        private double AllBetsSumm;
        public BetSplitter betSplitter {get;private set;}

        public MainForm()
        {
            InitializeComponent();
            GenMatchDayResultsBTN.Enabled = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Rake = Convert.ToDouble(RakeTBX.Text);
            RaiseSumPercent = Convert.ToDouble(RaiseSumPercentTBX.Text);
        }
        private void RunBtn_Click(object sender, EventArgs e)
        {
            if ((MatchesNumTxtBx.Text == "") && (BetsNumTxtBx.Text == ""))
            {
                MessageBox.Show("Invalid input");
            }
            else
            {
                if (Rake ==0)
                {
                    DialogResult result = MessageBox.Show("Rake is equal to 0, would you like to continue","Rake issue",MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        ExecuteSimulation();
                    }
                }
                else
                {
                    ExecuteSimulation();
                }
            }
        }

        private void ExecuteSimulation()
        {
            this.MatchesNum = Convert.ToInt32(MatchesNumTxtBx.Text);
            this.BetsNum = Convert.ToInt32(BetsNumTxtBx.Text);
            this.ReBetMatchesNum = Convert.ToInt32(ReraiseMatchesTBX.Text);
            Creator = new ProbsCoefsBetsCreator(MatchesNum, Rake, BetsNum, MaxWinnings);
            betSplitter = new BetSplitter(Creator.AllBets, RaiseSumPercent, ReBetMatchesNum, Rake, Creator.CoefsOtherCo);
            RaiseSum = betSplitter.ReBetSum;
            AllBetsSumm = betSplitter.AllBetsSum;
            List<DataGridViewsRepository> repository = new List<DataGridViewsRepository>();
            repository.Add(new Bets() { DGV = dataGridViewBets, ListContent = new List<TablesContent>(Creator.AllBetsForTable) });
            repository.Add(new Results() { DGV = dataGridViewResults, ListContent = new List<TablesContent>(Creator.Tree.AllResultsInTable) });
            repository.Add(new ProbsCoefs() { DGV = dataGridViewProbsCoefs, ListContent = new List<TablesContent>(Creator.GennedParams) });
            repository.Add(new MatchesToRaise() { ListContent = new List<TablesContent>(betSplitter.matchesToRaiseTable), DGV = dataGridViewMatchesToRaise });
            foreach (DataGridViewsRepository elem in repository)
            {
                elem.ConfigureDGV();
            }
            GenMatchDayResultsBTN.Enabled = true;
        }


        private void DigitalInput(KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && (ch != 8) && (ch != 46))  // turning on backspace and del keys
                e.Handled = true;
        } 
        
        private void MatchesNumTxtBx_KeyPress(object sender, KeyPressEventArgs e)
        {
           DigitalInput(e);
           MatchesNum = Convert.ToInt32(MatchesNumTxtBx.Text);

        }
        private void BetsNumTxtBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            DigitalInput(e);
            BetsNum = Convert.ToInt32(BetsNumTxtBx.Text);
        }

        private void ReraiseMatchesTBX_KeyPress(object sender, KeyPressEventArgs e)
        {
            DigitalInput(e);
            ReBetMatchesNum = Convert.ToInt32(ReraiseMatchesTBX.Text);
        }

        private void RakeTBX_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            var rake = Convert.ToDouble(RakeTBX.Text);
            if (rake < 1)
            {
                Rake = rake;
            }
            else
            {
                MessageBox.Show("rake < 1 required");
            }
        }

        private void GenMatchDayResultsBTN_Click(object sender, EventArgs e)
        {
            Dialog = new MatchDayResultsDialog(MatchesNum);
            var dr = Dialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                var matchday = new MatchDayResults() { ListContent = new List<TablesContent>(Dialog.MatchDayResultsList), DGV = dataGridViewMatchDayResults };
                matchday.ConfigureDGV();
            }
            MarathonNetWon netWon = new MarathonNetWon()
            {
                AllBets = Creator.AllBets,
                MatchDayResults = Dialog.MatchDayResultsList
            };
            NetWonBeforeRaisingTBX.Text = Convert.ToString(netWon.EstimateMarathonNetWon());

            betSplitter.GenListOfMarathonBets();
            Creator.AddMarathonBets(betSplitter.MarathonBets);
            netWon = new MarathonNetWon()
            {
                AllBets = Creator.AllBets,
                MatchDayResults = Dialog.MatchDayResultsList
            };
            NetWonAfterRaisingTBX.Text = Convert.ToString(netWon.EstimateMarathonNetWon());
            RaiseSumTBX.Text = Convert.ToString(RaiseSum);
            AllBetsSumTBX.Text = Convert.ToString(AllBetsSumm);
        }

        private void RaiseSumTBX_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            var sum = Convert.ToDouble(RaiseSumPercentTBX.Text);
            RaiseSumPercent = sum;
        }
    }
}
