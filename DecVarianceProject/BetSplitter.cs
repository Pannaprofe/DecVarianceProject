using System;
using System.Collections.Generic;
using System.Linq;
using DecVarianceProject.Structures;
using DecVarianceProject.Structures.TablesContents;

namespace DecVarianceProject
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
            foreach (var bet in _instance.ClientsBets)
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

            _instance.LossToAllBetsSumRatio = 0.5;
            var temp = _instance.AllResultsNoTable.Where(row => row.NetWon < -_instance.LossToAllBetsSumRatio*_instance.AllBetsSum).ToList();
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

            _instance.BetsStructure = new List<StructureOfRaise>();

            for (int i = 0; i < outcomesFrequences.Count;i++ )
            {
                var freq = outcomesFrequences[i];
                var sum = freq[1] + freq[2] + freq[0];
                const double ratio = 0.7;
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
                    SingleMatchCoef = _instance.CoefsOtherCo[i][outcome],
                    SingleMatchProb = _instance.ProbsMarathon[i][outcome]
                };
                _instance.BetsStructure.Add(raise);
            }

        }

        private void SplitMoney()
        {

            var reverseCoefsSum = _instance.BetsStructure.Sum(structure => 1 / structure.SingleMatchCoef);

            foreach (var structure in _instance.BetsStructure)
            {
                structure.ToBet = Math.Round(_instance.RaiseSum / reverseCoefsSum / structure.SingleMatchCoef, 2);
            }
            _instance.BetsStructure = new List<StructureOfRaise>(_instance.BetsStructure);
        }

        public void ConvertStructureToTable()
        {
            _instance.MatchesToRaiseTable = new List<MatchesToRaiseTableContent>();
            foreach (var match in _instance.BetsStructure.Select(raise => new MatchesToRaiseTableContent
            {
                MatchNum = raise.MatchNum,
                MatchOutcome = ConvertOutcomeIntToString(raise.Outcome),
                BetSize = raise.ToBet
            }))
            {
                _instance.MatchesToRaiseTable.Add(match);
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
            _instance.MarathonBets = new List<BetInfo>();
            foreach (var bet in from raise in _instance.BetsStructure let matchList = new List<int> {raise.MatchNum} 
                                let outcomes = new List<int> {raise.Outcome} let coef = raise.SingleMatchCoef let prob = raise.SingleMatchProb 
                                let betsize = -raise.ToBet select new BetInfo(matchList,outcomes,betsize,coef,prob))
            {
                _instance.MarathonBets.Add(bet);
            }
        }
    }
}
