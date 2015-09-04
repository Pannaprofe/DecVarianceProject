using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DecVarianceProject.Entities.Structures;
using DecVarianceProject.Entities.TablesContents;

namespace DecVarianceProject.AppLogic
{
    [Serializable]
    public class ProbsCoefsBetsCreator
    {
        private readonly Random _randomNum = new Random();
        private readonly Singleton _instance;

        public ProbsCoefsBetsCreator()
        {
            _instance = Singleton.Instance;
            _instance.ProbsMarathonList = new List<List<double>>();
            _instance.ProbsOtherCoList = new List<List<double>>();
            _instance.CoefsMarathonList = new List<List<double>>();
            _instance.CoefsOtherCoList = new List<List<double>>();
            
            _instance.ClientsBetsList = new List<BetInfo>();
            _instance.AllBetsForTableList = new List<AllBetsTableContent>();
            ObtainData();  //Generate Probs/Coefs
            CreateProbsAndCoefsStructure();   // for printing Probs and Coefs into Table

        }

        protected void ObtainData()
        {
            GenProbsMarathon();
            GenProbsOtherCo();
            _instance.CoefsMarathonList = GetCoefs(_instance.ProbsMarathonList);
            _instance.CoefsOtherCoList = GetCoefs(_instance.ProbsOtherCoList);
            GenAllBetsOfAllPlayers();
        }

        private void CreateProbsAndCoefsStructure()
        {
            _instance.GennedParamsList = new List<GennedParamsTableContent>();
            for (var i = 0; i < _instance.ProbsMarathonList.Count;i++ )
            {
                var row = new GennedParamsTableContent()
                {
                    MatchNum = i,
                    ProbabilityP1 = _instance.ProbsMarathonList[i][1],
                    ProbabilityP2 = _instance.ProbsMarathonList[i][2],
                    ProbabilityX = _instance.ProbsMarathonList[i][0],
                    CoefP1 = _instance.CoefsMarathonList[i][1],
                    CoefP2 = _instance.CoefsMarathonList[i][2],
                    CoefX = _instance.CoefsMarathonList[i][0]
                };
                _instance.GennedParamsList.Add(row);
            }
        }
        // *********************BEGIN GENERATORS*********************************************
        private void GenAllBetsOfAllPlayers()
        {
            for (var i = 0; i < _instance.BetsNum; i++)
            {
                var onePlayerBet = GenerateBet(i);
                _instance.ClientsBetsList.Add(onePlayerBet);
            }
        }
        private void GenProbsMarathon()
        {
            const double minProb = 0.2;
            var random = new Random();
            for (var i = 0; i < _instance.MatchesNum; i++)
            {
                var x1 = Math.Round(random.NextDouble() * (1 - 2 * minProb) + minProb, 3);
                //random.NextDouble() * (maximum - minimum) + minimum;
                var x = Math.Round(random.NextDouble() * (1 - x1 - 2 * minProb) + minProb, 3);
                var x2 = Math.Round(1 - x1 - x,3);
                var matchParams = new List<double>(){x,x1, x2};
                _instance.ProbsMarathonList.Add(matchParams);
            }
        }
        private void GenProbsOtherCo()
        {
            const double delta = 0;
            var random = new Random();
            try
            {
                for (var i = 0; i < _instance.MatchesNum; i++)
                {
                    var x1 = _instance.ProbsMarathonList[i][1] + Math.Round(random.NextDouble() * (2 * delta), 3) - delta;
                    var x2 = _instance.ProbsMarathonList[i][2] + Math.Round(random.NextDouble() * (2 * delta), 3) - delta;
                    var x = _instance.ProbsMarathonList[i][0] + random.NextDouble() * (2 * delta) - delta;

                    var matchParams = new List<double>(){x,x1, x2};
                    _instance.ProbsOtherCoList.Add(matchParams);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }

        }
        private List<List<double>> GetCoefs(IEnumerable<List<double>> probsList)
        {
            var coefList = new List<List<double>>();
            try
            {
                coefList.AddRange(from t in probsList let x1 = Math.Round((1 - _instance.Rake) / t[1], 3) let x2 = Math.Round((1 - _instance.Rake) / t[2], 3) let x = Math.Round((1 - _instance.Rake) / t[0], 3) select new List<double>(){x,x1, x2});
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
            if (gennedMatchesNumber > _instance.MatchesNum / 2)
            {
                rez = new List<int>(_instance.MatchesNum);
                for (var i = 0; i < _instance.MatchesNum; i++)
                {
                    rez.Add(i);
                }

                for (var i = 0; i < _instance.MatchesNum - gennedMatchesNumber; i++)
                {
                    var matchNum = -1;

                    while (!rez.Contains(matchNum))
                    {
                        matchNum = _randomNum.Next(0, _instance.MatchesNum - 1);
                    }
                    rez.Remove(matchNum);
                }
            }
            else
            {
                rez = new List<int>();
                for (var i = 0; i < gennedMatchesNumber; i++)
                {
                    var matchNum = _randomNum.Next(0, _instance.MatchesNum - 1); //randomize the choice of match 
                    while (rez.Contains(matchNum))
                    {
                        matchNum = _randomNum.Next(0, _instance.MatchesNum - 1); //randomize the choice of match
                    }
                    rez.Add(matchNum);
                }
            }
            return rez;
        }
        private BetInfo GenerateBet(int betNum)
        {
            var gennedMatchesNumber = _randomNum.Next(1, 10); // randomize the number of matches in express
            var chosenMatches = GenListOfMatchesInTheBet(gennedMatchesNumber);
            var outcomes = new List<int>(gennedMatchesNumber);


            for (var i = 0; i < gennedMatchesNumber; i++)
            {
                var matchResult = _randomNum.Next(0, 3); // randomize match result  0 -> x1;  1 -> x; 2 -> x2;
                outcomes.Add(matchResult);
            }
            double coef = 1;
            double prob = 1;
            for (var i = 0; i < chosenMatches.Count; i++)
            {
                switch (outcomes[i])
                {
                    case 0:
                        coef *= _instance.CoefsMarathonList[chosenMatches[i]][1];
                        prob *= _instance.ProbsMarathonList[chosenMatches[i]][1];
                        break;
                    case 1:
                        coef *= _instance.CoefsMarathonList[chosenMatches[i]][0];
                        prob *= _instance.ProbsMarathonList[chosenMatches[i]][0];
                        break;
                    case 2:
                        coef *= _instance.CoefsMarathonList[chosenMatches[i]][2];
                        prob *= _instance.ProbsMarathonList[chosenMatches[i]][2];
                        break;
                }
            }
            coef = Math.Round(coef, 3);
            prob = Math.Round(coef,3);
            var maxBet = (int)(_instance.MaxWinnings / (coef - 1));
            var betSize = _randomNum.Next(1, (maxBet > 0) ? maxBet : 1); //randomize  the size of bet
            chosenMatches.Sort();
            var betinfo = new BetInfo(chosenMatches, outcomes, betSize, coef,prob);
            var sb = new StringBuilder();
            for (var i = 0;i < chosenMatches.Count;i++)
            {
                sb.Append("{"+chosenMatches[i]+"-"+( (outcomes[i] == 0)?"X":"P"+outcomes[i]) +"}, ");
            }
            var row = new AllBetsTableContent(){
                BetNum = betNum,
                BetSize = betSize,
                Coef = coef,
                ChosenMatchesResults = sb.ToString()
            };
            _instance.AllBetsForTableList.Add(row);
            return betinfo;
        }
        //**********************END GENERATORS***********************************************
    }
}
