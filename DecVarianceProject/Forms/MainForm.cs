using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Windows.Forms;
using DecVarianceProject.Properties;
using System.Text;

namespace DecVarianceProject.Forms
{
    public partial class MainForm : Form
    {
        private Singleton Instance;
        private MatchDayResultsDialog _dialog;

        public MainForm()
        {
            Instance = Singleton.Instance;
            InitializeComponent();
            GenMatchDayResultsBTN.Enabled = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Instance.Rake = Convert.ToDouble(RakeTBX.Text);
            Instance.RaiseSumPercent = Convert.ToDouble(RaiseSumPercentTBX.Text);
        }
        private void RunBtn_Click(object sender, EventArgs e)
        {
            if ((MatchesNumTxtBx.Text == "") && (BetsNumTxtBx.Text == ""))
            {
                MessageBox.Show(Resources.MainForm_RunBtn_Click_Invalid_input);
            }
            else
            {
                if (Math.Abs(Instance.Rake) <= 0.0001)
                {
                    var result = MessageBox.Show(Resources.MainForm_RunBtn_Click_Rake_is_equal_to_0__would_you_like_to_continue,Resources.MainForm_RunBtn_Click_Rake_issue,MessageBoxButtons.YesNo);
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
            Instance.MatchesNum = Convert.ToInt32(MatchesNumTxtBx.Text);
            Instance.BetsNum = Convert.ToInt32(BetsNumTxtBx.Text);
            Instance.RaiseMatchesNum = Convert.ToInt32(ReraiseMatchesTBX.Text);
            Instance.Creator = new ProbsCoefsBetsCreator();
            Instance.BetSplitter = new BetSplitter();
            var repository = new List<DataGridViewsRepository>
            {
                new BetsTable() {Dgv = dataGridViewBets, ListContent = new List<ITablesContent>(Instance.AllBetsForTable)},
                new ResultsTable()
                {
                    Dgv = dataGridViewResults,
                    ListContent = new List<ITablesContent>(Instance.AllResultsInTable)
                },
                new ProbsCoefsTable()
                {
                    Dgv = dataGridViewProbsCoefs,
                    ListContent = new List<ITablesContent>(Instance.GennedParams)
                },
                new MatchesToRaiseTable()
                {
                    ListContent = new List<ITablesContent>(Instance.MatchesToRaiseTable),
                    Dgv = dataGridViewMatchesToRaise
                }
            };
            foreach (var elem in repository)
            {
                elem.ConfigureDgv();
            }
            GenMatchDayResultsBTN.Enabled = true;
        }

        private static void DigitalInput(KeyPressEventArgs e)
        {
            var ch = e.KeyChar;
            if (!char.IsDigit(ch) && (ch != 8) && (ch != 46))  // turning on backspace and del keys
                e.Handled = true;
        } 
        
        private void MatchesNumTxtBx_KeyPress(object sender, KeyPressEventArgs e)
        {
           DigitalInput(e);
           Instance.MatchesNum = Convert.ToInt32(MatchesNumTxtBx.Text);

        }
        private void BetsNumTxtBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            DigitalInput(e);
            Instance.BetsNum = Convert.ToInt32(BetsNumTxtBx.Text);
        }

        private void ReraiseMatchesTBX_KeyPress(object sender, KeyPressEventArgs e)
        {
            DigitalInput(e);
            Instance.RaiseMatchesNum = Convert.ToInt32(ReraiseMatchesTBX.Text);
        }

        private void RakeTBX_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            var rake = Convert.ToDouble(RakeTBX.Text);
            if (rake < 1)
            {
                Instance.Rake = rake;
            }
            else
            {
                MessageBox.Show(Resources.MainForm_RakeTBX_MaskInputRejected_rake___1_required);
            }
        }

        private void GenMatchDayResultsBTN_Click(object sender, EventArgs e)
        {
            GenMatchDayResults(false);
        }

        private void GenMatchDayResults(bool automatic)
        {
            _dialog = new MatchDayResultsDialog(Instance.MatchesNum, automatic, Instance.ProbsMarathon);
            if (!automatic)
            {
                var dr = _dialog.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    var matchday = new MatchDayResultsTable() { ListContent = new List<ITablesContent>(Instance.MatchDayResults), Dgv = dataGridViewMatchDayResults };
                    matchday.ConfigureDgv();
                }
            }
            var matchday1 = new MatchDayResultsTable() { ListContent = new List<ITablesContent>(Instance.MatchDayResults), Dgv = dataGridViewMatchDayResults };
            matchday1.ConfigureDgv();
            
            //Estimate Marathon NetWon before raising
            MarathonNetWon netWon = new MarathonNetWon();
            Instance.NetWonBefore = Math.Round(netWon.EstimateMarathonNetWon(),2);
            NetWonBeforeRaisingTBX.Text = Convert.ToString(Instance.NetWonBefore, CultureInfo.InvariantCulture);
            Instance.EvBefore = Math.Round(netWon.EstimateMarathonEvBefore(), 2);
            EvBeforeTBX.Text = Convert.ToString(Instance.EvBefore,CultureInfo.InvariantCulture);
            //----------------------------------------
            //Estimate Marathon NetWon after raising
            var bets = Instance.AllBets;
            Instance.BetSplitter.GenListOfMarathonBets();
            netWon = new MarathonNetWon();
            Instance.NetWonAfter = Math.Round(netWon.EstimateMarathonNetWon()+Instance.NetWonBefore,2);
            Instance.EvAfter = Math.Round(netWon.EstimateMarathonEvAfter(Instance.MarathonBets), 2);
            EvAfterTBX.Text = Convert.ToString(Instance.EvAfter, CultureInfo.InvariantCulture);
            NetWonAfterRaisingTBX.Text = Convert.ToString(Instance.NetWonAfter, CultureInfo.InvariantCulture);
            Instance.AllBets = new List<Structures.BetInfo>(bets);
            //-----------------------------------------
            RaiseSumTBX.Text = Convert.ToString(Instance.RaiseSumPercent, CultureInfo.InvariantCulture);
            AllBetsSumTBX.Text = Convert.ToString(Instance.AllBetsSum, CultureInfo.InvariantCulture);
        }

        private void RaiseSumTBX_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            var sum = Convert.ToDouble(RaiseSumPercentTBX.Text);
            Instance.RaiseSumPercent = sum;
        }

        private void TestEvaluationBTN_Click(object sender, EventArgs e)
        {
            const int testsNum = 1;
            const int idModelsMax = 1;
            const int idMatchDaysMax = 50;
            var matchesToRaiseNumList = new List<int>(1) { 2};
            var raisePercentList = new List<double>(1) {0.05};

            var test = new List<TestTableContent>();
            var testForm = new TestEstimationForm(test);
            using (var progressBarForm = new ProgressBarForm(testsNum*idMatchDaysMax*idModelsMax*matchesToRaiseNumList.Count*raisePercentList.Count))
            {
                for (var i = 1; i <= testsNum; i++)
                {
                    for (var num = 1; num <= matchesToRaiseNumList.Count; num++ )
                    {
                        for (var j = 1; j <= raisePercentList.Count; j++)
                        {
                            for (var idModel = 1; idModel <= idModelsMax; idModel++)
                            {
                                RunBtn_Click(this, new EventArgs());
                                for (var idMatchDay = 1; idMatchDay <= idMatchDaysMax; idMatchDay++)
                                {
                                    GenMatchDayResults(true);
                                    var row = new TestTableContent()
                                    {
                                        IdModel = idModel,
                                        IdMatchDay = idMatchDay,
                                        BetsSumm = Instance.AllBetsSum,
                                        RaiseSumm = Instance.RaiseSumPercent,
                                        NetWonBefore = Instance.NetWonBefore,
                                        NetWonAfter = Instance.NetWonAfter
                                    };
                                    test.Add(row);
                                    progressBarForm.IncProgressBarValue();
                                }
                            }
                            testForm = new TestEstimationForm(test);
                            var date = DateTime.Now;
                            var format = "MMM_ ddd_d-HH_mm_s_yyyy";
                            var fileName = matchesToRaiseNumList[num - 1] + "-" + raisePercentList[j - 1] + "-" + idModelsMax + "-" + idMatchDaysMax + "-" + i + date.ToString(format);
                            FileActions.Save(fileName, test);
                            testForm.ShowDialog();
                        }
                    }

                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var testForm = new TestEstimationForm(FileActions.Open());
            testForm.ShowDialog();
        }

        private void AnalysisBTN_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            string[] array2 = Directory.GetFiles(@"C:\Users\Guest\Desktop\DecVarianceProject\DecVarianceProject\bin\Debug");
            foreach (var name in array2)
            {
                try
                {
                    var testForm = new TestEstimationForm(FileActions.Open(name));
                    sb.AppendLine(testForm.EvProfit + "  " + testForm.VarianceDiff);
                }
                catch
                {
                    
                }
            }
            using (StreamWriter streamWriter = new StreamWriter("analysis.txt") )
            {
                streamWriter.Write(sb.ToString());
            }
        }
    }
}
