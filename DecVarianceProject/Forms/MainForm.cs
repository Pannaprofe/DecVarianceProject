using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using DecVarianceProject.AppLogic;
using DecVarianceProject.Entities.Structures;
using DecVarianceProject.Properties;

namespace DecVarianceProject.Forms
{
    public partial class MainForm : Form
    {
        private readonly Singleton _instance;

        public MainForm()
        {
            _instance = Singleton.Instance;
            InitializeComponent();
            GenMatchDayResultsBTN.Enabled = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _instance.DgvDictionary = new Dictionary<string,DataGridView >
            {
                {"Bets",dataGridViewBets},
                {"MatchDayResults",dataGridViewMatchDayResults },
                {"MatchesToRaise",dataGridViewMatchesToRaise },
                {"Results",dataGridViewResults },
                {"ProbsCoefs",dataGridViewProbsCoefs }
            };
        }



        private void RunBtn_Click(object sender, EventArgs e)
        {
            _instance.Rake = Convert.ToDouble(RakeTBX.Text);
            _instance.MaxWinnings = 10000;
            _instance.RaiseSumPercent = Convert.ToDouble(RaiseSumPercentTBX.Text);
            _instance.BetsNum = Convert.ToInt32(BetsNumTxtBx.Text);
            _instance.MatchesNum = Convert.ToInt32(MatchesNumTxtBx.Text);
            if (!InputIsCorrect()) return;
            var simulation = new Simulation();
            simulation.Exexute();
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
            _instance.MatchDayResults = new MatchDayResults(dataGridViewMatchDayResults);
            _instance.MatchDayResults.Generate(false);
            NetWonBeforeRaisingTBX.Text = Convert.ToString(_instance.NetWonBefore, CultureInfo.InvariantCulture);
            EvBeforeTBX.Text = Convert.ToString(_instance.EvBefore, CultureInfo.InvariantCulture);
            EvAfterTBX.Text = Convert.ToString(_instance.EvAfter, CultureInfo.InvariantCulture);
            NetWonAfterRaisingTBX.Text = Convert.ToString(_instance.NetWonAfter, CultureInfo.InvariantCulture);
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
            var testsSeries = new TestsSeries(dataGridViewMatchDayResults);
            testsSeries.Execute();
        }

        private bool InputIsCorrect()
        {
            if ((MatchesNumTxtBx.Text != "") || (BetsNumTxtBx.Text != "")) return true;
            MessageBox.Show(Resources.MainForm_RunBtn_Click_Invalid_input);
            return false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var testForm = new TestEstimationForm(FileActions.Open());
            testForm.ShowDialog();
        }

        private void AnalysisBTN_Click(object sender, EventArgs e)
        {
            var analysis = new Analysis();
            analysis.Execute();
        }
    }
}
