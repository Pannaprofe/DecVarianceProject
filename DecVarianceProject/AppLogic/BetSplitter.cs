using System;
using System.Collections.Generic;
using System.Linq;
using DecVarianceProject.Entities.Structures;
using DecVarianceProject.Entities.TablesContents;

namespace DecVarianceProject.AppLogic
{
    [Serializable]
    public class BetSplitter 
    {
        private readonly Singleton _instance;


        public BetSplitter()
        {
            _instance = Singleton.Instance;
            EstimateBetsSumm();
            Split();
            ConvertStructureToTable();
        }

        private void EstimateBetsSumm()
        {
            foreach (var bet in _instance.ClientsBetsList)
            {
                _instance.RaiseSum += bet.BetSize;
            }
            _instance.AllBetsSum = _instance.RaiseSum;
            _instance.RaiseSum *= _instance.RaiseSumPercent;
        }
        public void Split()
        {
            SplitOutcomes();
            SplitMoney();
        }

        private void SplitOutcomes()
        {
            var outcomesFrequences = Enumerable.Range(0, _instance.MatchesNum).Select(n => Enumerable.Range(0, 3).Select(k => 0).ToList()).ToList();
            var temp = _instance.AllResultsNoTableList.Where(row => row.NetWon < -_instance.LossToAllBetsSumRatio*_instance.AllBetsSum).ToList();
            for (var i = 0; i<_instance.MatchesNum;i++)
            {
                foreach (var row in temp)
                {
                    try
                    {
                        switch (row.NodePathList[i])
                        {
                            case 1:
                                outcomesFrequences[i][1]++;
                                break;
                            case 2:
                                outcomesFrequences[i][2]++;
                                break;
                            case 0:
                                outcomesFrequences[i][0]++;
                                break;
                        }
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }

            _instance.BetsStructureList = new List<StructureOfRaise>();

            for (var i = 0; i < outcomesFrequences.Count;i++ )
            {
                var freq = outcomesFrequences[i];
                var sum = freq[1] + freq[2] + freq[0];
                var ratio = _instance.OutcomesFrequencesRatio;
                var max = freq[1];
                var outcome = 1;
                for (var j = 0; j < freq.Count;j++ )
                {
                    if (freq[j] <= max) continue;
                    max = freq[j];
                    outcome = j;
                }
                if (!(max >= sum*ratio)) continue;
                var raise = new StructureOfRaise()
                {
                    MatchNum = i,
                    Outcome = outcome,
                    SingleMatchCoef = _instance.CoefsOtherCoList[i][outcome],
                    SingleMatchProb = _instance.ProbsMarathonList[i][outcome]
                };
                _instance.BetsStructureList.Add(raise);
            }

        }

        private void SplitMoney()
        {

            var reverseCoefsSum = _instance.BetsStructureList.Sum(structure => 1 / structure.SingleMatchCoef);

            foreach (var structure in _instance.BetsStructureList)
            {
                structure.ToBet = Math.Round(_instance.RaiseSum / reverseCoefsSum / structure.SingleMatchCoef, 2);
            }
            _instance.BetsStructureList = new List<StructureOfRaise>(_instance.BetsStructureList);
        }

        public void ConvertStructureToTable()
        {
            _instance.MatchesToRaiseTableList = new List<MatchesToRaiseTableContent>();
            foreach (var match in _instance.BetsStructureList.Select(raise => new MatchesToRaiseTableContent
            {
                MatchNum = raise.MatchNum,
                MatchOutcome = ConvertOutcomeIntToString(raise.Outcome),
                BetSize = raise.ToBet
            }))
            {
                _instance.MatchesToRaiseTableList.Add(match);
            }
        }

        private static string ConvertOutcomeIntToString(int outcome)
        {
            switch (outcome)
            {
                case 1:
                    return "P1";
                case 2:
                    return "P2";
                default:
                    return "X";
            }
        }

        public void GenListOfMarathonBets()
        {
            _instance.MarathonBetsList = new List<BetInfo>();
            foreach (var bet in from raise in _instance.BetsStructureList let matchList = new List<int> {raise.MatchNum} 
                                let outcomes = new List<int> {raise.Outcome} let coef = raise.SingleMatchCoef let prob = raise.SingleMatchProb 
                                let betsize = -raise.ToBet select new BetInfo(matchList,outcomes,betsize,coef,prob))
            {
                _instance.MarathonBetsList.Add(bet);
            }
        }
    }
}
