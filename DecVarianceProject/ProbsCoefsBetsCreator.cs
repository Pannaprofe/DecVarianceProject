using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecVarianceProject
{
    public class ProbsCoefsBetsCreator
    {
        public List<MatchParams> ProbsMarathon{get;private set;}
        public List<MatchParams> ProbsOtherCo { get; private set; }
        public List<MatchParams> CoefsMarathon { get; private set; }
        public List<MatchParams> CoefsOtherCo { get; private set; }
        public List<GennedParamsInTable> GennedParams { get; private set; }
        public List<BetInfo> AllBets { get; private set; }
        public List<AllBetsTable> AllBetsForTable { get; private set; }  
        public SubTree Tree { get; private set; }

        public double Rake { get; private set; }

        public int MatchesNum { get; private set; }
        public int NumberOfBets { get; private set; }
        public int MaxWinnings { get; private set; }

        private Random RandomNum = new Random();  

        public ProbsCoefsBetsCreator(int MatchesNum, double rake, int numberOfBets, int maxWinnings)
        {
            ProbsMarathon = new List<MatchParams>();
            ProbsOtherCo = new List<MatchParams>();
            CoefsMarathon = new List<MatchParams>();
            CoefsOtherCo = new List<MatchParams>();
            
            this.MatchesNum = MatchesNum;
            this.NumberOfBets = numberOfBets;
            this.MaxWinnings = maxWinnings;
            this.Rake = rake;
            AllBets = new List<BetInfo>();
            AllBetsForTable = new List<AllBetsTable>();
            ObtainData();  //Generate Probs/Coefs
            CreateProbsAndCoefsStructure();   // for printing Probs and Coefs into Table
            Tree = new SubTree(ProbsMarathon, CoefsMarathon, AllBets);
        }

        protected void ObtainData()
        {
            GenProbsMarathon();
            GenProbsOtherCo();
            CoefsMarathon = GetCoefs(ProbsMarathon);
            CoefsOtherCo = GetCoefs(ProbsOtherCo);
            GenAllBetsOfAllPlayers();
        }

        private void CreateProbsAndCoefsStructure()
        {
            GennedParams = new List<GennedParamsInTable>();
            for (int i = 0; i < ProbsMarathon.Count;i++ )
            {
                var row = new GennedParamsInTable()
                {
                    MatchNum = i,
                    ProbabilityP1 = ProbsMarathon[i].P1,
                    ProbabilityP2 = ProbsMarathon[i].P2,
                    ProbabilityX = ProbsMarathon[i].X,
                    CoefP1 = CoefsMarathon[i].P1,
                    CoefP2 = CoefsMarathon[i].P2,
                    CoefX = CoefsMarathon[i].X
                };
                GennedParams.Add(row);
            }
        }
        // *********************BEGIN GENERATORS*********************************************
        private void GenAllBetsOfAllPlayers()
        {
            BetInfo OnePlayerBet;
            for (int i = 0; i < NumberOfBets; i++)
            {
                OnePlayerBet = GenerateBet(i);
                AllBets.Add(OnePlayerBet);
            }
        }
        private void GenProbsMarathon()
        {
            double minProb = 0.2;
            Random random = new Random();
            for (int i = 0; i < MatchesNum; i++)
            {
                double x1 = Math.Round(random.NextDouble() * (1 - 2 * minProb) + minProb, 3);
                //random.NextDouble() * (maximum - minimum) + minimum;
                double x = Math.Round(random.NextDouble() * (1 - x1 - 2 * minProb) + minProb, 3);
                double x2 = Math.Round(1 - x1 - x,3);
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
                for (int i = 0; i < MatchesNum; i++)
                {
                    double x1 = ProbsMarathon[i].P1 + Math.Round(random.NextDouble() * (2 * delta), 3) - delta;
                    double x2 = ProbsMarathon[i].P2 + Math.Round(random.NextDouble() * (2 * delta), 3) - delta;
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
                    double x1 = Math.Round((1 - Rake) / probsList[i].P1, 3);
                    double x2 = Math.Round((1 - Rake) / probsList[i].P2, 3);
                    double x = Math.Round((1 - Rake) / probsList[i].X, 3);

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
            if (gennedMatchesNumber > MatchesNum / 2)
            {
                rez = new List<int>(MatchesNum);
                for (int i = 0; i < MatchesNum; i++)
                {
                    rez.Add(i);
                }

                for (int i = 0; i < MatchesNum - gennedMatchesNumber; i++)
                {
                    int matchNum = -1;

                    while (!rez.Contains(matchNum))
                    {
                        matchNum = RandomNum.Next(0, MatchesNum - 1);
                    }
                    rez.Remove(matchNum);
                }
            }
            else
            {
                rez = new List<int>();
                for (int i = 0; i < gennedMatchesNumber; i++)
                {
                    int matchNum = RandomNum.Next(0, MatchesNum - 1); //randomize the choice of match 
                    while (rez.Contains(matchNum))
                    {
                        matchNum = RandomNum.Next(0, MatchesNum - 1); //randomize the choice of match
                    }
                    rez.Add(matchNum);
                }
            }
            return rez;
        }
        private BetInfo GenerateBet(int betNum)
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
                        coef *= CoefsMarathon[chosenMatches[i]].P1;

                        break;
                    case 1:
                        coef *= CoefsMarathon[chosenMatches[i]].X;
                        break;
                    case 2:
                        coef *= CoefsMarathon[chosenMatches[i]].P2;
                        break;
                }
            }
            coef = Math.Round(coef, 3);
            var maxBet = (int)(MaxWinnings / (coef - 1));
            int betSize = RandomNum.Next(1, (maxBet > 0) ? maxBet : 1); //randomize  the size of bet
            chosenMatches.Sort();
            BetInfo betinfo = new BetInfo(chosenMatches, outcomes, betSize, coef);
            var sb = new StringBuilder();
            for (int i = 0;i < chosenMatches.Count;i++)
            {
                sb.Append("{"+chosenMatches[i]+"-"+( (outcomes[i] == 0)?"X":"P"+outcomes[i]) +"}, ");
            }
            AllBetsTable row = new AllBetsTable(){
                BetNum = betNum,
                BetSize = betSize,
                Coef = coef,
                ChosenMatchesResults = sb.ToString()
            };
            AllBetsForTable.Add(row);
            coef = 1;
            return betinfo;
        }
        //**********************END GENERATORS***********************************************
    }
}
