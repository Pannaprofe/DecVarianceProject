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
    public partial class Form1 : Form
    {
        protected List<BetInfo> AllBets = new List<BetInfo>();

        protected int matchesNum = 6;
        protected const double R = 0.05;
        protected int NumberOfBets = 2;
        protected int maxWinnings = 10000;
        protected List<MatchParams> ProbsMarathon;
        protected List<MatchParams> ProbsOtherCo;
        protected List<MatchParams> CoefsMarathon;
        protected List<MatchParams> CoefsOtherCo;
        protected Random RandomNum = new Random();   // the way to make this variable global is the only possible as random numbers are equal to the first random number 

        public Form1()
        {
            InitializeComponent();

            Label label = new Label();
            label.Text = "№";
            ProbsCoefsTable.Controls.Add(label, 0, 0);

            label = new Label();
            label.Text = "P1";
            ProbsCoefsTable.Controls.Add(label, 1, 0);

            label = new Label();
            label.Text = "P1";
            ProbsCoefsTable.Controls.Add(label, 4, 0);

            label = new Label();
            label.Text = "X";
            ProbsCoefsTable.Controls.Add(label, 2, 0);

            label = new Label();
            label.Text = "X";
            ProbsCoefsTable.Controls.Add(label, 5, 0);

            label = new Label();
            label.Text = "P2";
            ProbsCoefsTable.Controls.Add(label, 3, 0);

            label = new Label();
            label.Text = "P2";
            ProbsCoefsTable.Controls.Add(label, 6, 0);
        }

        protected void ObtainData()
        {
            GenProbsMarathon();
            GenProbsOtherCo();
            CoefsMarathon = GetCoefs(ProbsMarathon);
            CoefsOtherCo = GetCoefs(ProbsOtherCo);
            GenAllBetsOfAllPlayers();
        }

        private void GenAllBetsOfAllPlayers()
        {
            BetInfo OnePlayerBet;
            for (int i = 0; i < NumberOfBets; i++)
            {
                OnePlayerBet = GenerateBet();
                AllBets.Add(OnePlayerBet);
            }
        }

        private void GenProbsMarathon()
        {
            double minProb = 0.2;
            Random random = new Random();
            for (int i = 0; i < matchesNum; i++)
            {
                double x1 = Math.Round(random.NextDouble() * (1 - 2 * minProb) + minProb,3);
                //random.NextDouble() * (maximum - minimum) + minimum;
                double x = Math.Round(random.NextDouble() * (1 - x1 - 2 * minProb) + minProb,3);
                double x2 = 1 - x1 - x;
                MatchParams matchParams = new MatchParams(x1, x2, x);
                ProbsMarathon.Add(matchParams);
            }
        }

        private void GenProbsOtherCo()
        {
            double delta = 0.03;
            Random random = new Random();
            try
            {
                for (int i = 0; i < matchesNum; i++)
                {
                    double x1 = ProbsMarathon[i].X1 + Math.Round(random.NextDouble() * (2 * delta),3) - delta;
                    double x2 = ProbsMarathon[i].X2 + Math.Round(random.NextDouble() * (2 * delta),3) - delta;
                    double x = ProbsMarathon[i].X + random.NextDouble() * (2 * delta) - delta;

                    MatchParams matchParams = new MatchParams(x1, x2, x);
                    ProbsOtherCo.Add(matchParams);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }

        }

        private List<MatchParams> GetCoefs(List<MatchParams> probsList)
        {
            var coefList = new List<MatchParams>();
            try
            {
                for (int i = 0; i < probsList.Count; i++)
                {
                    double x1 = Math.Round((1 - R) / probsList[i].X1,3);
                    double x2 = Math.Round((1 - R) / probsList[i].X2,3);
                    double x = Math.Round((1 - R) / probsList[i].X,3);

                    MatchParams matchParams = new MatchParams(x1, x2, x);
                    coefList.Add(matchParams);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }
            return coefList;
        }


        private List<int> GenListOfMatchesInTheBet(int gennedMatchesNumber)
        {
            List<int> rez;
            if (gennedMatchesNumber>matchesNum/2)
            {
                rez = new List<int>(matchesNum);
                for (int i=0; i<matchesNum; i++)
                {
                    rez.Add(i);
                }

                for (int i = 0; i < matchesNum-gennedMatchesNumber; i++)
                {
                    int matchNum = -1;

                    while (!rez.Contains(matchNum))
                    {
                        matchNum = RandomNum.Next(0, matchesNum - 1);
                    }
                    rez.Remove(matchNum);   
                }
            }
            else
            {
                rez = new List<int>();
                for (int i = 0; i < gennedMatchesNumber; i++)
                {
                    int matchNum = RandomNum.Next(0, matchesNum - 1); //randomize the choice of match 
                    while (rez.Contains(matchNum))
                    {
                        matchNum = RandomNum.Next(0, matchesNum - 1); //randomize the choice of match
                    }
                    rez.Add(matchNum);
                }
            }
            return rez;
        }
        private BetInfo GenerateBet()
        {
            var gennedMatchesNumber = RandomNum.Next(1, 10); // randomize the number of matches in express
            List<int> chosenMatches = GenListOfMatchesInTheBet(gennedMatchesNumber);
            List<int> outcomes = new List<int>(gennedMatchesNumber);
            

            for (int i = 0; i < gennedMatchesNumber; i++)
            {
                int matchResult = RandomNum.Next(0, 3); // randomize match result  0 -> x1;  1 -> x; 2 -> x2;
                outcomes.Add(matchResult);
            }
            double coef = 1;
            for (int i = 0; i < chosenMatches.Count; i++)
            {
                switch (outcomes[i])
                {
                    case 0:
                        coef *= CoefsMarathon[chosenMatches[i]].X1;

                        break;
                    case 1:
                        coef *= CoefsMarathon[chosenMatches[i]].X;
                        break;
                    case 2:
                        coef *= CoefsMarathon[chosenMatches[i]].X2;
                        break;
                }
            }
            var maxBet = (int)(maxWinnings/(coef-1));
            int betSize = RandomNum.Next(1, (maxBet>0) ?maxBet:1 ); //randomize  the size of bet
            chosenMatches.Sort();
            BetInfo betinfo = new BetInfo(chosenMatches, outcomes, betSize, coef);
            coef = 1;
            return betinfo;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private string GetAllmatchesInfoForPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Matches info:");
            sb.AppendLine("_______________________________________________________________________________________");
            sb.AppendLine("                 Probabilities                  |                Coefs                           |");
            sb.AppendLine("_______________________________________________________________________________________");
            sb.AppendLine("      P1      |      X        |        P2       |      P1      |      X        |        P2       |");
            for (int i = 0; i < ProbsMarathon.Count; i++)
            {
                sb.AppendLine("    " + ProbsMarathon[i].X1 + "   |   " + ProbsMarathon[i].X + "   |   " + ProbsMarathon[i].X2 + "   |   " + CoefsMarathon[i].X1 + "   |   " + CoefsMarathon[i].X + "   |   " + CoefsMarathon[i].X2);
            }
            sb.AppendLine("_______________________________________________________________________________________");
            return sb.ToString();
        }

        private string GetAllBetsInfoForPrtint()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Made Bets:");
            sb.AppendLine("------------------------------------------------------------------------");
            foreach (BetInfo bet in AllBets)
            {
                sb.AppendLine("Bet Size: " + bet.BetSize);
                sb.AppendLine("Coef: " + bet.Coef);
                StringBuilder sb1 = new StringBuilder();
                for (int i = 0; i < bet.MatchesAndOutcomes.Count; i++ )
                {
                    sb1.Append("{" +bet.MatchesAndOutcomes.MatchList[i] + " - " + bet.MatchesAndOutcomes.Outcomes[i] + "} ");
                }
                sb.AppendLine("Matches - OutComes: " + sb1.ToString());
                sb.AppendLine("------------------------------------------------------------------------");
            }
            sb.AppendLine("______________________________________________________________________");
            return sb.ToString();
        }

        private void MatchesNumTxtBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && (ch != 8) && (ch != 46))  // turning on backspace and del keys
                e.Handled = true;
        }

        private void BetsNumTxtBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && (ch != 8) && (ch != 46))  // turning on backspace and del keys
                e.Handled = true;
        }

        private void MatchesNumTxtBx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                matchesNum = Convert.ToInt32(MatchesNumTxtBx.Text);
            }
            catch
            {

            }
        }

        private void BetsNumTxtBx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                NumberOfBets = Convert.ToInt32(BetsNumTxtBx.Text);
            }
            catch
            {

            }
        }

        private void RunBtn_Click(object sender, EventArgs e)
        {
            if ((MatchesNumTxtBx.Text == "") && (BetsNumTxtBx.Text == ""))
            {
                MessageBox.Show("Invalid input");
            }
            else
            {
                ProbsMarathon = new List<MatchParams>();
                ProbsOtherCo = new List<MatchParams>();
                CoefsMarathon = new List<MatchParams>();
                CoefsOtherCo = new List<MatchParams>();
                RTB_Info.Clear();
                RTB_rez.Clear();
                ObtainData();
                SubTree tree = new SubTree(ProbsMarathon, CoefsMarathon, AllBets);
                FillInTheProbsAndCoefsTable();
                RTB_Info.AppendText(GetAllmatchesInfoForPrint());
                RTB_Info.AppendText(GetAllBetsInfoForPrtint());
                RTB_rez.AppendText(tree.StringOutput);
            }
        }

        private void FillInTheProbsAndCoefsTable()
        {
            for (int i = 0; i < ProbsMarathon.Count; i++)
            {
                Label label = new Label();
                label.Text = i.ToString();
                ProbsCoefsTable.Controls.Add(label, 0, i+1);

                label = new Label();
                label.Text = ProbsMarathon[i].X1.ToString();
                ProbsCoefsTable.Controls.Add(label, 1, i+1);

                label = new Label();
                label.Text = ProbsMarathon[i].X.ToString();
                ProbsCoefsTable.Controls.Add(label, 2, i+1);

                label = new Label();
                label.Text = ProbsMarathon[i].X2.ToString();
                ProbsCoefsTable.Controls.Add(label, 3, i+1);

                label = new Label();
                label.Text = CoefsMarathon[i].X1.ToString();
                ProbsCoefsTable.Controls.Add(label, 4, i+1);

                label = new Label();
                label.Text = CoefsMarathon[i].X.ToString();
                ProbsCoefsTable.Controls.Add(label, 5, i + 1);

                label = new Label();
                label.Text = CoefsMarathon[i].X2.ToString();
                ProbsCoefsTable.Controls.Add(label, 6, i + 1);

            }
        }
        private void ProbsCoefsTable_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
