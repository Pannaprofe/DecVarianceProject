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
        private double NetWonBefore;
        private double NetWonAfter;
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
            GenMatchDayResults(false);
        }

        private void GenMatchDayResults(bool automatic)
        {
            Dialog = new MatchDayResultsDialog(MatchesNum, automatic);
            if (!automatic)
            {
                var dr = Dialog.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    var matchday = new MatchDayResults() { ListContent = new List<TablesContent>(Dialog.MatchDayResultsList), DGV = dataGridViewMatchDayResults };
                    matchday.ConfigureDGV();
                }
            }
            var matchday1 = new MatchDayResults() { ListContent = new List<TablesContent>(Dialog.MatchDayResultsList), DGV = dataGridViewMatchDayResults };
            matchday1.ConfigureDGV();
            
            //Estimate Marathon NetWon before raising
            MarathonNetWon netWon = new MarathonNetWon()
            {
                AllBets = Creator.AllBets,
                MatchDayResults = Dialog.MatchDayResultsList
            };
            NetWonBefore = Math.Round(netWon.EstimateMarathonNetWon(),2);
            NetWonBeforeRaisingTBX.Text = Convert.ToString(NetWonBefore);
            //----------------------------------------
            //Estimate Marathon NetWon after raising
            betSplitter.GenListOfMarathonBets();
            Creator.AddMarathonBets(betSplitter.MarathonBets);
            netWon = new MarathonNetWon()
            {
                AllBets = Creator.AllBets,
                MatchDayResults = Dialog.MatchDayResultsList
            };
            NetWonAfter = Math.Round(netWon.EstimateMarathonNetWon(),2);
            NetWonAfterRaisingTBX.Text = Convert.ToString(NetWonAfter);
            //-----------------------------------------
            RaiseSumTBX.Text = Convert.ToString(RaiseSum);
            AllBetsSumTBX.Text = Convert.ToString(AllBetsSumm);
        }

        private void RaiseSumTBX_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            var sum = Convert.ToDouble(RaiseSumPercentTBX.Text);
            RaiseSumPercent = sum;
        }

        private void TestEvaluationBTN_Click(object sender, EventArgs e)
        {
            int idModelsMax = 10;
            int idMatchDaysMax = 10;
            DataTable table = new DataTable();
            List<TestTable> test = new List<TestTable>();
            ProgressBarForm progressBarForm = new ProgressBarForm(idMatchDaysMax*idModelsMax-1);
            for (int idModel = 0; idModel < idModelsMax; idModel++)
            {
                RunBtn_Click(this, new EventArgs());
                for (int idMatchDay = 0; idMatchDay < idMatchDaysMax; idMatchDay++)
                {
                    GenMatchDayResults(true);
                    TestTable row = new TestTable()
                    {
                        IdModel = idModel,
                        IdMatchDay = idMatchDay,
                        BetsSumm = AllBetsSumm,
                        RaiseSumm = RaiseSum,
                        NetWonBefore = NetWonBefore,
                        NetWonAfter = NetWonAfter
                    };
                    test.Add(row);
                    progressBarForm.SetProgressBarValue(idModel * idMatchDaysMax + idMatchDay);
                }
            }
            
            TestEstimationForm testForm = new TestEstimationForm(test);
            testForm.ShowDialog();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "omg files (*.omg)|*.omg|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
