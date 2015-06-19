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

        protected const int matchesNum = 6;
        protected const double R = 0.05;
        protected const int NumberOfBets = 2;
        protected List<MatchParams> ProbsMarathon = new List<MatchParams>();
        protected List<MatchParams> ProbsOtherCo = new List<MatchParams>();
        protected List<MatchParams> CoefsMarathon = new List<MatchParams>();
        protected List<MatchParams> CoefsOtherCo = new List<MatchParams>();
        protected Random RandomNum = new Random();   // the way to make this variable global is the only possible as random numbers are equal to the first random number 

        public Form1()
        {
            InitializeComponent();
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
                    double x1 = (1 - R) / probsList[i].X1;
                    double x2 = (1 - R) / probsList[i].X2;
                    double x = (1 - R) / probsList[i].X;

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
            int betSize = RandomNum.Next(1, 10000); //randomize  the size of bet

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
            chosenMatches.Sort();
            BetInfo betinfo = new BetInfo(chosenMatches, outcomes, betSize, coef);
            coef = 1;
            return betinfo;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ObtainData();
            SubTree tree = new SubTree(ProbsMarathon, CoefsMarathon, AllBets);
            RTB_Info.AppendText( GetAllmatchesInfoForPrint());
            RTB_Info.AppendText(GetAllBetsInfoForPrtint());
            RTB_rez.AppendText(tree.StringOutput);
        }

        private string GetAllmatchesInfoForPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Matches info:");
            for (int i = 0; i < ProbsMarathon.Count; i++)
            {
                sb.AppendLine("Probabilities: " + ProbsMarathon[i].X1 + ":" + ProbsMarathon[i].X + ":" + ProbsMarathon[i].X2);
            }
            sb.AppendLine("______________________________________________________________________");
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
    }
}
