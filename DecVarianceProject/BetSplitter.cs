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
        private Singleton Instance;


        public BetSplitter()
        {
            Instance = Singleton.Instance;
            EstimateBetsSumm();
            Split();
            ConvertStructureToTable();
        }

        private void EstimateBetsSumm()
        {
            foreach (BetInfo bet in Instance.ClientsBets)
            {
                Instance.RaiseSum += bet.BetSize;
            }
            Instance.AllBetsSum = Instance.RaiseSum;
            Instance.RaiseSum *= Instance.RaiseSumPercent;
        }
        public void Split()
        {
            SplitOutcomes();
            SplitMoney();
        }

        private void SplitOutcomes()
        {
            var tmp = Enumerable.Range(0, 3).Select(n => 0).ToList();
            var outcomesFrequences = Enumerable.Range(0, Instance.MatchesNum).Select(n => tmp).ToList();

            var temp = new List<ResultsNotForTableContent>();
            Instance.LossToAllBetsSumRatio = 0.5;
            foreach (var row in Instance.AllResultsNoTable)
            {
                if (row.NetWon<-Instance.LossToAllBetsSumRatio*Instance.AllBetsSum)
                {
                    temp.Add(row);
                }
            }
            for (int i = 0; i<Instance.MatchesNum;i++)
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

                    }
                }
            }

            Instance.BetsStructure = new List<StructureOfRaise>();

            for (int i = 0; i < outcomesFrequences.Count;i++ )
            {
                var freq = outcomesFrequences[i];
                var sum = freq[1] + freq[2] + freq[0];
                var ratio = 0.5;
                var max = freq[1];
                var outcome = 1;
                for (int j = 0; j < freq.Count;j++ )
                {
                    if (freq[j]>max)
                    {
                        max = freq[j];
                        outcome = j;
                    }
                }
                if (max >= sum * ratio)
                {
                    var raise = new StructureOfRaise()
                    {
                        MatchNum = i,
                        Outcome = outcome,
                        SingleMatchCoef = Instance.CoefsOtherCo[i][outcome],
                        SingleMatchProb = Instance.ProbsMarathon[i][outcome]
                    };
                    Instance.BetsStructure.Add(raise);
                }
            }

        }

        private void SplitMoney()
        {

            double reverseCoefsSum = Instance.BetsStructure.Sum(structure => 1 / structure.SingleMatchCoef);

            foreach (var structure in Instance.BetsStructure)
            {
                structure.ToBet = Math.Round(Instance.RaiseSum / reverseCoefsSum / structure.SingleMatchCoef, 2);
            }
            Instance.BetsStructure = new List<StructureOfRaise>(Instance.BetsStructure);
        }

        public void ConvertStructureToTable()
        {
            Instance.MatchesToRaiseTable = new List<MatchesToRaiseTableContent>();
            foreach (var match in Instance.BetsStructure.Select(raise => new MatchesToRaiseTableContent
            {
                MatchNum = raise.MatchNum,
                MatchOutcome = ConvertOutcomeIntToString(raise.Outcome),
                BetSize = raise.ToBet
            }))
            {
                Instance.MatchesToRaiseTable.Add(match);
            }
        }

        private string ConvertOutcomeIntToString(int outcome)
        {
            if (outcome == 1)
            {
                return "P1";
            }
            if (outcome == 2)
            {
                return "P2";
            }
            else
                return "X";
        }

        public void GenListOfMarathonBets()
        {
            Instance.MarathonBets = new List<BetInfo>();
            foreach (StructureOfRaise raise in Instance.BetsStructure)
            {
                var matchList = new List<int> {raise.MatchNum};
                var outcomes = new List<int> {raise.Outcome};
                var coef = raise.SingleMatchCoef;
                var prob = raise.SingleMatchProb;
                var betsize = -raise.ToBet;    // Negative here
                BetInfo bet = new BetInfo(matchList,outcomes,betsize,coef,prob);
                Instance.MarathonBets.Add(bet);
            }
        }
    }
}
