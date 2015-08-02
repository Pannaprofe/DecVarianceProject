using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Windows.Forms;
using DecVarianceProject.Properties;
using DecVarianceProject.Structures.DataGridViewsRepositoryFolder;
using DecVarianceProject.Structures.Tables;

namespace DecVarianceProject.Forms
{
    public partial class MainForm : Form
    {
        private int _matchesNum;
        private double _rake;
        private int _betsNum;
        private readonly int _maxWinnings = 10000;
        private int _reBetMatchesNum;
        private ProbsCoefsBetsCreator _creator;
        private MatchDayResultsDialog _dialog;
        private double _raiseSumPercent;
        private double _raiseSum;
        private double _allBetsSumm;
        private double _netWonBefore;
        private double _netWonAfter;
        public BetSplitter BetSplitter {get;private set;}

        public MainForm()
        {
            InitializeComponent();
            GenMatchDayResultsBTN.Enabled = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _rake = Convert.ToDouble(RakeTBX.Text);
            _raiseSumPercent = Convert.ToDouble(RaiseSumPercentTBX.Text);
        }
        private void RunBtn_Click(object sender, EventArgs e)
        {
            if ((MatchesNumTxtBx.Text == "") && (BetsNumTxtBx.Text == ""))
            {
                MessageBox.Show(Resources.MainForm_RunBtn_Click_Invalid_input);
            }
            else
            {
                if (Math.Abs(_rake) <= 0.0001)
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
            _matchesNum = Convert.ToInt32(MatchesNumTxtBx.Text);
            _betsNum = Convert.ToInt32(BetsNumTxtBx.Text);
            _reBetMatchesNum = Convert.ToInt32(ReraiseMatchesTBX.Text);
            _creator = new ProbsCoefsBetsCreator(_matchesNum, _rake, _betsNum, _maxWinnings);
            BetSplitter = new BetSplitter(_creator.AllBets, _raiseSumPercent, _reBetMatchesNum, _rake, _creator.CoefsOtherCo);
            _raiseSum = BetSplitter.ReBetSum;
            _allBetsSumm = BetSplitter.AllBetsSum;
            var repository = new List<DataGridViewsRepository>
            {
                new Bets() {Dgv = dataGridViewBets, ListContent = new List<ITablesContent>(_creator.AllBetsForTable)},
                new Results()
                {
                    Dgv = dataGridViewResults,
                    ListContent = new List<ITablesContent>(_creator.Tree.AllResultsInTable)
                },
                new ProbsCoefs()
                {
                    Dgv = dataGridViewProbsCoefs,
                    ListContent = new List<ITablesContent>(_creator.GennedParams)
                },
                new MatchesToRaise()
                {
                    ListContent = new List<ITablesContent>(BetSplitter.MatchesToRaiseTable),
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
           _matchesNum = Convert.ToInt32(MatchesNumTxtBx.Text);

        }
        private void BetsNumTxtBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            DigitalInput(e);
            _betsNum = Convert.ToInt32(BetsNumTxtBx.Text);
        }

        private void ReraiseMatchesTBX_KeyPress(object sender, KeyPressEventArgs e)
        {
            DigitalInput(e);
            _reBetMatchesNum = Convert.ToInt32(ReraiseMatchesTBX.Text);
        }

        private void RakeTBX_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            var rake = Convert.ToDouble(RakeTBX.Text);
            if (rake < 1)
            {
                _rake = rake;
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
            _dialog = new MatchDayResultsDialog(_matchesNum, automatic, _creator.ProbsMarathon);
            if (!automatic)
            {
                var dr = _dialog.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    var matchday = new MatchDayResults() { ListContent = new List<ITablesContent>(_dialog.MatchDayResultsList), Dgv = dataGridViewMatchDayResults };
                    matchday.ConfigureDgv();
                }
            }
            var matchday1 = new MatchDayResults() { ListContent = new List<ITablesContent>(_dialog.MatchDayResultsList), Dgv = dataGridViewMatchDayResults };
            matchday1.ConfigureDgv();
            
            //Estimate Marathon NetWon before raising
            MarathonNetWon netWon = new MarathonNetWon()
            {
                AllBets = _creator.AllBets,
                MatchDayResults = _dialog.MatchDayResultsList
            };
            _netWonBefore = Math.Round(netWon.EstimateMarathonNetWon(),2);
            NetWonBeforeRaisingTBX.Text = Convert.ToString(_netWonBefore, CultureInfo.InvariantCulture);
            //----------------------------------------
            //Estimate Marathon NetWon after raising
            BetSplitter.GenListOfMarathonBets();
            _creator.AddMarathonBets(BetSplitter.MarathonBets);
            netWon = new MarathonNetWon()
            {
                AllBets = _creator.AllBets,
                MatchDayResults = _dialog.MatchDayResultsList
            };
            _netWonAfter = Math.Round(netWon.EstimateMarathonNetWon(),2);
            NetWonAfterRaisingTBX.Text = Convert.ToString(_netWonAfter, CultureInfo.InvariantCulture);
            //-----------------------------------------
            RaiseSumTBX.Text = Convert.ToString(_raiseSum, CultureInfo.InvariantCulture);
            AllBetsSumTBX.Text = Convert.ToString(_allBetsSumm, CultureInfo.InvariantCulture);
        }

        private void RaiseSumTBX_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            var sum = Convert.ToDouble(RaiseSumPercentTBX.Text);
            _raiseSumPercent = sum;
        }

        private void TestEvaluationBTN_Click(object sender, EventArgs e)
        {
            const int testsNum = 5;
            const int idModelsMax = 100;
            const int idMatchDaysMax = 100;
            var matchesToRaiseNumList = new List<int>(1) { 2};
            var raisePercentList = new List<double>(1) {0.1};

            var test = new List<TestTable>();
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
                                    var row = new TestTable()
                                    {
                                        IdModel = idModel,
                                        IdMatchDay = idMatchDay,
                                        BetsSumm = _allBetsSumm,
                                        RaiseSumm = _raiseSum,
                                        NetWonBefore = _netWonBefore,
                                        NetWonAfter = _netWonAfter
                                    };
                                    test.Add(row);
                                    progressBarForm.IncProgressBarValue();
                                }
                            }
                            var testForm = new TestEstimationForm(test);
                            var fileName = matchesToRaiseNumList[num-1] + "-" + raisePercentList[j-1] + "-" + idModelsMax + "-" + idMatchDaysMax + "-" + i;
                            testForm.Save(fileName);
                            // testForm.ShowDialog();
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
    }
}
