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
        private int RaiseMatchesNum;
        private ProbsCoefsBetsCreator Creator;
        private MatchDayResultsDialog Dialog;

        public MainForm()
        {
            InitializeComponent();
            GenMatchDayResultsBTN.Enabled = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void RunBtn_Click(object sender, EventArgs e)
        {
            if ((MatchesNumTxtBx.Text == "") && (BetsNumTxtBx.Text == ""))
            {
                MessageBox.Show("Invalid input");
            }
            else
            {
                this.MatchesNum = Convert.ToInt32(MatchesNumTxtBx.Text);
                this.BetsNum = Convert.ToInt32(BetsNumTxtBx.Text);
                Creator = new ProbsCoefsBetsCreator(MatchesNum, Rake, BetsNum, MaxWinnings);
                List<DataGridViewsRepository> repository = new List<DataGridViewsRepository>();
                repository.Add(new Bets() { DGV = dataGridViewBets, ListContent = new List<TablesContent>(Creator.AllBetsForTable)});
                repository.Add(new Results() { DGV = dataGridViewResults, ListContent = new List<TablesContent>(Creator.Tree.AllResultsInTable) });
                repository.Add(new ProbsCoefs() { DGV = dataGridViewProbsCoefs, ListContent = new List<TablesContent>(Creator.GennedParams) });
                foreach (DataGridViewsRepository elem in repository)
                {
                    elem.ConfigureDGV();
                }
                GenMatchDayResultsBTN.Enabled = true;
            }
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
            RaiseMatchesNum = Convert.ToInt32(ReraiseMatchesTBX.Text);
        }

        private void RakeTBX_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            RakeTBX.Mask = "0.000";
            Rake = Convert.ToDouble(RakeTBX.Text);
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
            
        }
    }
}
