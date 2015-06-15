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
        private List<BetInfo> AllBets = new List<BetInfo>();
        // public List<Match> allMatches = new List<Match>();
        //  public List<SingleMatchBetInfo> OnePlayerBet = new List<SingleMatchBetInfo>();
        // public List<List<SingleMatchBetInfo>> allBetsList = new List<List<SingleMatchBetInfo>>();
        private const int matchesNum = 6;
        private const double R = 0.05;
        private const int NumberOfBets = 2;
        public List<MatchParams> ProbsMarathon = new List<MatchParams>();
        public List<MatchParams> ProbsOtherCo = new List<MatchParams>();
        public List<MatchParams> CoefsMarathon = new List<MatchParams>();
        public List<MatchParams> CoefsOtherCo = new List<MatchParams>();
        private Random RandomNum = new Random();   // the way to make this variable global is the only possible as random numbers are equal to the first random number 

        public Form1()
        {
            InitializeComponent();
        }


        private void ObtainData()
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
            double minProb = 0.01;
            Random random = new Random();
            for (int i = 0; i < matchesNum; i++)
            {
                double x1 = random.NextDouble() * (1 - 2 * minProb) + minProb;
                //random.NextDouble() * (maximum - minimum) + minimum;
                double x = random.NextDouble() * (1 - x1 - 2 * minProb) + minProb;
                double x2 = 1 - x1 - x;
                MatchParams matchParams = new MatchParams(x1, x2, x);
                ProbsMarathon.Add(matchParams);
            }
        }

        private void GenProbsOtherCo()
        {
            double delta = 0.005;
            Random random = new Random();
            try
            {
                for (int i = 0; i < matchesNum; i++)
                {
                    double x1 = ProbsMarathon[i].X1 + random.NextDouble() * (2 * delta) - delta;
                    double x2 = ProbsMarathon[i].X2 + random.NextDouble() * (2 * delta) - delta;
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
            List<int> outcomes = new List<int>();
            int betSize = RandomNum.Next(1, 10000); //randomize  the size of bet
            for (int i = 0; i < gennedMatchesNumber; i++)
            {
                int matchResult = RandomNum.Next(0, 2); // randomize match result  0 -> x1;  1 -> x; 2 -> x2;
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
            RTB_rez.Text = tree.GetOutput();
        }
    }
}
