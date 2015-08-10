using System;
using System.Collections.Generic;
using System.Linq;
using DecVarianceProject.Structures;

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
            foreach (BetInfo bet in Instance.AllBets)
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

        private void SplitOutcomesNew()
        {
            var outcomesFrequences = new List<OutcomesFrequences>();
        }

        private void SplitOutcomes()
        {
            Instance.BetsStructure = new List<StructureOfRaise>(Instance.CoefsOtherCo.Count);
            for (int i = 0; i < Instance.CoefsOtherCo.Count; i++)
            {
                Instance.BetsStructure.Add(new StructureOfRaise());
            }
            foreach (BetInfo bet in Instance.AllBets)
            {
                for (int i = 0; i < bet.MatchesAndOutcomes.Count; i++)
                {
                    Instance.BetsStructure[bet.MatchesAndOutcomes.MatchList[i]].MatchNum = bet.MatchesAndOutcomes.MatchList[i];
                    Instance.BetsStructure[bet.MatchesAndOutcomes.MatchList[i]].Outcome = bet.MatchesAndOutcomes.Outcomes[i];
                    switch (Instance.BetsStructure[bet.MatchesAndOutcomes.MatchList[i]].Outcome)
                    {
                        case 1:
                            Instance.BetsStructure[bet.MatchesAndOutcomes.MatchList[i]].SingleMatchCoef = Instance.CoefsOtherCo[i].P1;
                            Instance.BetsStructure[bet.MatchesAndOutcomes.MatchList[i]].SingleMatchProb = Instance.ProbsMarathon[i].P1;
                            break;
                        case 2:
                            Instance.BetsStructure[bet.MatchesAndOutcomes.MatchList[i]].SingleMatchCoef = Instance.CoefsOtherCo[i].P2;
                            Instance.BetsStructure[bet.MatchesAndOutcomes.MatchList[i]].SingleMatchProb = Instance.ProbsMarathon[i].P2;
                            break;
                        case 0:
                            Instance.BetsStructure[bet.MatchesAndOutcomes.MatchList[i]].SingleMatchCoef = Instance.CoefsOtherCo[i].X;
                            Instance.BetsStructure[bet.MatchesAndOutcomes.MatchList[i]].SingleMatchProb = Instance.ProbsMarathon[i].X;
                            break;
                    }
                    Instance.BetsStructure[bet.MatchesAndOutcomes.MatchList[i]].BetsAmmount += bet.BetSize;
                }
            }

            foreach (StructureOfRaise raise in Instance.BetsStructure)
            {
                raise.EvDiff = EstimateEvDifference(raise);
            }
            
        }

        private void SplitMoney()
        {
            List<StructureOfRaise> sortedBetsStructure = Instance.BetsStructure.OrderBy(o => o.EvDiff).ToList();
            var cuttedBetsStructure = sortedBetsStructure.Take(Instance.RaiseMatchesNum);
            var structureOfRaises = cuttedBetsStructure as StructureOfRaise[] ?? cuttedBetsStructure.ToArray();
            double reverseCoefsSum = structureOfRaises.Sum(structure => 1/structure.SingleMatchCoef);

            foreach (var structure in structureOfRaises)
            {
                structure.ToBet = Math.Round(Instance.RaiseSum / reverseCoefsSum / structure.SingleMatchCoef, 2);
            }
            Instance.BetsStructure = new List<StructureOfRaise>(structureOfRaises);
        }

        private double EstimateEvDifference(StructureOfRaise bet)
        {
            var maxLoss = -(bet.SingleMatchCoef - 1) * bet.BetsAmmount;
            var ev = bet.BetsAmmount * Instance.Rake;
            return maxLoss - ev;
        }

        public void ConvertStructureToTable()
        {
            Instance.MatchesToRaiseTable = new List<MatchesToRaiseTableContent>();
            foreach (var match in Instance.BetsStructure.Select(reBet => new MatchesToRaiseTableContent
            {
                MatchNum = reBet.MatchNum,
                MatchOutcome = ConvertOutcomeIntToString(reBet.Outcome),
                BetSize = reBet.ToBet
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
            foreach (StructureOfRaise reBet in Instance.BetsStructure)
            {
                var matchList = new List<int> {reBet.MatchNum};
                var outcomes = new List<int> {reBet.Outcome};
                var coef = reBet.SingleMatchCoef;
                var prob = reBet.SingleMatchProb;
                var betsize = -reBet.ToBet;    // Negative here
                BetInfo bet = new BetInfo(matchList,outcomes,betsize,coef,prob);
                Instance.MarathonBets.Add(bet);
            }
        }
    }

    internal class OutcomesFrequences
    {
        internal int P1Count { get; set; }
        internal int P2Count { get; set; }
        internal int XCount { get; set; }
    }
}
