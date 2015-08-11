using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DecVarianceProject.Structures;

namespace DecVarianceProject
{
    [Serializable]
    public class ProbsCoefsBetsCreator
    {
        private readonly Random _randomNum = new Random();
        private Singleton Instance;

        public ProbsCoefsBetsCreator()
        {
            Instance = Singleton.Instance;
            Instance.ProbsMarathon = new List<List<double>>();
            Instance.ProbsOtherCo = new List<List<double>>();
            Instance.CoefsMarathon = new List<List<double>>();
            Instance.CoefsOtherCo = new List<List<double>>();
            
            Instance.ClientsBets = new List<BetInfo>();
            Instance.AllBetsForTable = new List<AllBetsTableContent>();
            ObtainData();  //Generate Probs/Coefs
            CreateProbsAndCoefsStructure();   // for printing Probs and Coefs into Table
            Instance.Tree = new SubTree();
        }

        protected void ObtainData()
        {
            GenProbsMarathon();
            GenProbsOtherCo();
            Instance.CoefsMarathon = GetCoefs(Instance.ProbsMarathon);
            Instance.CoefsOtherCo = GetCoefs(Instance.ProbsOtherCo);
            GenAllBetsOfAllPlayers();
        }

        private void CreateProbsAndCoefsStructure()
        {
            Instance.GennedParams = new List<GennedParamsTableContent>();
            for (int i = 0; i < Instance.ProbsMarathon.Count;i++ )
            {
                var row = new GennedParamsTableContent()
                {
                    MatchNum = i,
                    ProbabilityP1 = Instance.ProbsMarathon[i][1],
                    ProbabilityP2 = Instance.ProbsMarathon[i][2],
                    ProbabilityX = Instance.ProbsMarathon[i][0],
                    CoefP1 = Instance.CoefsMarathon[i][1],
                    CoefP2 = Instance.CoefsMarathon[i][2],
                    CoefX = Instance.CoefsMarathon[i][0]
                };
                Instance.GennedParams.Add(row);
            }
        }
        // *********************BEGIN GENERATORS*********************************************
        private void GenAllBetsOfAllPlayers()
        {
            for (var i = 0; i < Instance.BetsNum; i++)
            {
                var onePlayerBet = GenerateBet(i);
                Instance.ClientsBets.Add(onePlayerBet);
            }
        }
        private void GenProbsMarathon()
        {
            double minProb = 0.2;
            Random random = new Random();
            for (int i = 0; i < Instance.MatchesNum; i++)
            {
                double x1 = Math.Round(random.NextDouble() * (1 - 2 * minProb) + minProb, 3);
                //random.NextDouble() * (maximum - minimum) + minimum;
                double x = Math.Round(random.NextDouble() * (1 - x1 - 2 * minProb) + minProb, 3);
                double x2 = Math.Round(1 - x1 - x,3);
                List<double> matchParams = new List<double>(){x,x1, x2};
                Instance.ProbsMarathon.Add(matchParams);
            }
        }
        private void GenProbsOtherCo()
        {
            double delta = 0;
            Random random = new Random();
            try
            {
                for (int i = 0; i < Instance.MatchesNum; i++)
                {
                    double x1 = Instance.ProbsMarathon[i][1] + Math.Round(random.NextDouble() * (2 * delta), 3) - delta;
                    double x2 = Instance.ProbsMarathon[i][2] + Math.Round(random.NextDouble() * (2 * delta), 3) - delta;
                    double x = Instance.ProbsMarathon[i][0] + random.NextDouble() * (2 * delta) - delta;

                    var matchParams = new List<double>(){x,x1, x2};
                    Instance.ProbsOtherCo.Add(matchParams);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }

        }
        private List<List<double>> GetCoefs(List<List<double>> probsList)
        {
            var coefList = new List<List<double>>();
            try
            {
                coefList.AddRange(from t in probsList let x1 = Math.Round((1 - Instance.Rake) / t[1], 3) let x2 = Math.Round((1 - Instance.Rake) / t[2], 3) let x = Math.Round((1 - Instance.Rake) / t[0], 3) select new List<double>(){x,x1, x2});
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
            if (gennedMatchesNumber > Instance.MatchesNum / 2)
            {
                rez = new List<int>(Instance.MatchesNum);
                for (int i = 0; i < Instance.MatchesNum; i++)
                {
                    rez.Add(i);
                }

                for (int i = 0; i < Instance.MatchesNum - gennedMatchesNumber; i++)
                {
                    int matchNum = -1;

                    while (!rez.Contains(matchNum))
                    {
                        matchNum = _randomNum.Next(0, Instance.MatchesNum - 1);
                    }
                    rez.Remove(matchNum);
                }
            }
            else
            {
                rez = new List<int>();
                for (int i = 0; i < gennedMatchesNumber; i++)
                {
                    int matchNum = _randomNum.Next(0, Instance.MatchesNum - 1); //randomize the choice of match 
                    while (rez.Contains(matchNum))
                    {
                        matchNum = _randomNum.Next(0, Instance.MatchesNum - 1); //randomize the choice of match
                    }
                    rez.Add(matchNum);
                }
            }
            return rez;
        }
        private BetInfo GenerateBet(int betNum)
        {
            var gennedMatchesNumber = _randomNum.Next(1, 10); // randomize the number of matches in express
            List<int> chosenMatches = GenListOfMatchesInTheBet(gennedMatchesNumber);
            List<int> outcomes = new List<int>(gennedMatchesNumber);


            for (int i = 0; i < gennedMatchesNumber; i++)
            {
                int matchResult = _randomNum.Next(0, 3); // randomize match result  0 -> x1;  1 -> x; 2 -> x2;
                outcomes.Add(matchResult);
            }
            double coef = 1;
            double prob = 1;
            for (int i = 0; i < chosenMatches.Count; i++)
            {
                var match = chosenMatches[i];
                switch (outcomes[i])
                {
                    case 0:
                        coef *= Instance.CoefsMarathon[chosenMatches[i]][1];
                        prob *= Instance.ProbsMarathon[chosenMatches[i]][1];
                        break;
                    case 1:
                        coef *= Instance.CoefsMarathon[chosenMatches[i]][0];
                        prob *= Instance.ProbsMarathon[chosenMatches[i]][0];
                        break;
                    case 2:
                        coef *= Instance.CoefsMarathon[chosenMatches[i]][2];
                        prob *= Instance.ProbsMarathon[chosenMatches[i]][2];
                        break;
                }
            }
            coef = Math.Round(coef, 3);
            prob = Math.Round(coef,3);
            var maxBet = (int)(Instance.MaxWinnings / (coef - 1));
            int betSize = _randomNum.Next(1, (maxBet > 0) ? maxBet : 1); //randomize  the size of bet
            chosenMatches.Sort();
            BetInfo betinfo = new BetInfo(chosenMatches, outcomes, betSize, coef,prob);
            var sb = new StringBuilder();
            for (int i = 0;i < chosenMatches.Count;i++)
            {
                sb.Append("{"+chosenMatches[i]+"-"+( (outcomes[i] == 0)?"X":"P"+outcomes[i]) +"}, ");
            }
            AllBetsTableContent row = new AllBetsTableContent(){
                BetNum = betNum,
                BetSize = betSize,
                Coef = coef,
                ChosenMatchesResults = sb.ToString()
            };
            Instance.AllBetsForTable.Add(row);
            return betinfo;
        }
        //**********************END GENERATORS***********************************************
    }
}
