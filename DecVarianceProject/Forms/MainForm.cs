using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DecVarianceProject.Properties;
using DecVarianceProject.Structures;
using DecVarianceProject.Structures.DataGridViewsTablesFolder;
using DecVarianceProject.Structures.TablesContents;

namespace DecVarianceProject.Forms
{
    public partial class MainForm : Form
    {
        private readonly Singleton _instance;
        private MatchDayResultsDialog _dialog;

        public MainForm()
        {
            _instance = Singleton.Instance;
            InitializeComponent();
            GenMatchDayResultsBTN.Enabled = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _instance.Rake = Convert.ToDouble(RakeTBX.Text);
            _instance.MaxWinnings = 10000;
            _instance.RaiseSumPercent = Convert.ToDouble(RaiseSumPercentTBX.Text);
        }
        private void RunBtn_Click(object sender, EventArgs e)
        {
            if ((MatchesNumTxtBx.Text == "") && (BetsNumTxtBx.Text == ""))
            {
                MessageBox.Show(Resources.MainForm_RunBtn_Click_Invalid_input);
            }
            else
            {
                if (Math.Abs(_instance.Rake) <= 0.0001)
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
            _instance.MatchesNum = Convert.ToInt32(MatchesNumTxtBx.Text);
            _instance.BetsNum = Convert.ToInt32(BetsNumTxtBx.Text);
            _instance.Creator = new ProbsCoefsBetsCreator();
            _instance.BetSplitter = new BetSplitter();
            var tmp = _instance.AllResultsNoTable.Select(elem => new ResultsInTableContent()
            {
                NetWon = elem.NetWon, NodePathString = elem.NodePathString, Node = elem.Node, Payments = elem.Payments, Probability = elem.Probability, Winnings = elem.Winnings
            }).ToList();

            //List<ResultsInTableContent> lst = (Instance.AllResultsNoTable).
            var repository = new List<DataGridViewsRepository>
            {
                new BetsTable() {Dgv = dataGridViewBets, ListContent = new List<ITablesContent>(_instance.AllBetsForTable)},
                new ResultsTable()
                {
                    Dgv = dataGridViewResults,
                    ListContent = new List<ITablesContent>(tmp)
                },
                new ProbsCoefsTable()
                {
                    Dgv = dataGridViewProbsCoefs,
                    ListContent = new List<ITablesContent>(_instance.GennedParams)
                },
                new MatchesToRaiseTable()
                {
                    ListContent = new List<ITablesContent>(_instance.MatchesToRaiseTable),
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
           _instance.MatchesNum = Convert.ToInt32(MatchesNumTxtBx.Text);

        }
        private void BetsNumTxtBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            DigitalInput(e);
            _instance.BetsNum = Convert.ToInt32(BetsNumTxtBx.Text);
        }

        private void RakeTBX_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            var rake = Convert.ToDouble(RakeTBX.Text);
            if (rake < 1)
            {
                _instance.Rake = rake;
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
            _dialog = new MatchDayResultsDialog(automatic);
            if (!automatic)
            {
                var dr = _dialog.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    var matchday = new MatchDayResultsTable() { ListContent = new List<ITablesContent>(_instance.MatchDayResults), Dgv = dataGridViewMatchDayResults };
                    matchday.ConfigureDgv();
                }
            }
            var matchday1 = new MatchDayResultsTable() { ListContent = new List<ITablesContent>(_instance.MatchDayResults), Dgv = dataGridViewMatchDayResults };
            matchday1.ConfigureDgv();
            
            //Estimate Marathon NetWon before raising
            MarathonNetWon netWon = new MarathonNetWon() { Bets = _instance.ClientsBets};
            _instance.NetWonBefore = Math.Round(netWon.EstimateMarathonNetWon(),2);
            NetWonBeforeRaisingTBX.Text = Convert.ToString(_instance.NetWonBefore, CultureInfo.InvariantCulture);
            _instance.EvBefore = Math.Round(netWon.EstimateMarathonEvBefore(), 2);
            EvBeforeTBX.Text = Convert.ToString(_instance.EvBefore,CultureInfo.InvariantCulture);
            //----------------------------------------
            //Estimate Marathon NetWon after raising
            var bets = _instance.ClientsBets;
            _instance.BetSplitter.GenListOfMarathonBets();    // Result => Instance.MarathonBets
            netWon = new MarathonNetWon() { Bets = _instance.MarathonBets };
            _instance.NetWonAfter = Math.Round(netWon.EstimateMarathonNetWon()+_instance.NetWonBefore,2);
            _instance.EvAfter = Math.Round(netWon.EstimateMarathonEvAfter(_instance.MarathonBets), 2);
            EvAfterTBX.Text = Convert.ToString(_instance.EvAfter, CultureInfo.InvariantCulture);
            NetWonAfterRaisingTBX.Text = Convert.ToString(_instance.NetWonAfter, CultureInfo.InvariantCulture);
            _instance.ClientsBets = new List<BetInfo>(bets);
            //-----------------------------------------
            RaiseSumTBX.Text = Convert.ToString(_instance.RaiseSum, CultureInfo.InvariantCulture);
            AllBetsSumTBX.Text = Convert.ToString(_instance.AllBetsSum, CultureInfo.InvariantCulture);
        }

        private void RaiseSumTBX_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            var sum = Convert.ToDouble(RaiseSumPercentTBX.Text);
            _instance.RaiseSumPercent = sum;
        }

        private void TestEvaluationBTN_Click(object sender, EventArgs e)
        {
            const int testsNum = 1;
            const int idModelsMax = 1;
            const int idMatchDaysMax = 50000;
            var matchesToRaiseNumList = new List<int>(1) { 2};
            var raisePercentList = new List<double>(1) {0.05};

            var test = new List<TestTableContent>();
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
                                        BetsSumm = _instance.AllBetsSum,
                                        RaiseSumm = _instance.RaiseSum,
                                        NetWonBefore = _instance.NetWonBefore,
                                        NetWonAfter = _instance.NetWonAfter
                                    };
                                    test.Add(row);
                                    progressBarForm.IncProgressBarValue();
                                }
                            }
                            var testForm = new TestEstimationForm(test);
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
                    // ignored
                }
            }
            using (StreamWriter streamWriter = new StreamWriter("analysis.txt") )
            {
                streamWriter.Write(sb.ToString());
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
