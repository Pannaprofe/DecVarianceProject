using DecVarianceProject.Structures.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using DecVarianceProject.Structures;

namespace DecVarianceProject
{
    [Serializable]
    public class BetSplitter
    {
        public double ReBetSum { get; private set; }
        public int ReBetMatchesNum { get; private set; }
        public double Rake { get; private set; }
        public List<BetInfo> AllBets { get; private set; }
        public double AllBetsSum { get; private set; }
        public List<BetInfo> MarathonBets { get; private set; }
        public List<MatchesToRaiseTable> MatchesToRaiseTable { get; private set; }

        public List<StructureOfRaise> BetsStructure { get; private set; }

        public List<MatchParams> CoefsOtherCo { get; set; }
        public List<MatchParams> Probs { get; set; }

        public BetSplitter(List<BetInfo> allBets, double percent,int rebetMatchesNum, double rake, List<MatchParams> coefsOtherCo, List<MatchParams> probs)
        {
            EstimateBetsSumm(allBets,percent);
            ReBetMatchesNum = rebetMatchesNum;
            Rake = rake;
            AllBets = allBets;
            CoefsOtherCo = coefsOtherCo;
            Probs = probs;
            Split();
            ConvertStructureToTable();
        }

        private void EstimateBetsSumm(List<BetInfo> allBets, double percent)
        {
            foreach (BetInfo bet in allBets)
            {
                ReBetSum += bet.BetSize;
            }
            AllBetsSum = ReBetSum;
            ReBetSum *= percent;
        }
        public void Split()
        {
            SplitOutcomes();
            SplitMoney();
        }

        private void SplitOutcomes()
        {
            BetsStructure = new List<StructureOfRaise>(CoefsOtherCo.Count);
            for (int i = 0; i < CoefsOtherCo.Count;i++ )
            {
                BetsStructure.Add(new StructureOfRaise());
            }
            foreach (BetInfo bet in AllBets)
            {
                for (int i = 0; i < bet.MatchesAndOutcomes.Count; i++)
                {
                    BetsStructure[bet.MatchesAndOutcomes.MatchList[i]].MatchNum = bet.MatchesAndOutcomes.MatchList[i];
                    BetsStructure[bet.MatchesAndOutcomes.MatchList[i]].Outcome = bet.MatchesAndOutcomes.Outcomes[i];
                    switch (BetsStructure[bet.MatchesAndOutcomes.MatchList[i]].Outcome)
                    {
                        case 1:
                            BetsStructure[bet.MatchesAndOutcomes.MatchList[i]].SingleMatchCoef = CoefsOtherCo[i].P1;
                            BetsStructure[bet.MatchesAndOutcomes.MatchList[i]].SingleMatchProb = Probs[i].P1;
                            break;
                        case 2:
                            BetsStructure[bet.MatchesAndOutcomes.MatchList[i]].SingleMatchCoef = CoefsOtherCo[i].P2;
                            BetsStructure[bet.MatchesAndOutcomes.MatchList[i]].SingleMatchProb = Probs[i].P2;
                            break;
                        case 0:
                            BetsStructure[bet.MatchesAndOutcomes.MatchList[i]].SingleMatchCoef = CoefsOtherCo[i].X;
                            BetsStructure[bet.MatchesAndOutcomes.MatchList[i]].SingleMatchProb = Probs[i].X;
                            break;
                    }
                    BetsStructure[bet.MatchesAndOutcomes.MatchList[i]].BetsAmmount += bet.BetSize;
                }
            }

            foreach (StructureOfRaise reBet in BetsStructure)
            {
                reBet.EvDiff = EstimateEvDifference(reBet);
            }
            
        }

        private void SplitMoney()
        {
            List<StructureOfRaise> sortedBetsStructure = BetsStructure.OrderBy(o => o.EvDiff).ToList();
            var cuttedBetsStructure = sortedBetsStructure.Take(ReBetMatchesNum);
            var structureOfRaises = cuttedBetsStructure as StructureOfRaise[] ?? cuttedBetsStructure.ToArray();
            double reverseCoefsSum = structureOfRaises.Sum(structure => 1/structure.SingleMatchCoef);

            foreach (var structure in structureOfRaises)
            {
                structure.ToBet = Math.Round(ReBetSum / reverseCoefsSum/structure.SingleMatchCoef,2);
            }
            BetsStructure = new List<StructureOfRaise>(structureOfRaises);
        }

        private double EstimateEvDifference(StructureOfRaise bet)
        {
            var maxLoss = -(bet.SingleMatchCoef - 1) * bet.BetsAmmount;
            var ev = bet.BetsAmmount * Rake;
            return maxLoss - ev;
        }

        public void ConvertStructureToTable()
        {
            MatchesToRaiseTable = new List<MatchesToRaiseTable>();
            foreach (var match in BetsStructure.Select(reBet => new MatchesToRaiseTable
            {
                MatchNum = reBet.MatchNum,
                MatchOutcome = ConvertOutcomeIntToString(reBet.Outcome),
                BetSize = reBet.ToBet
            }))
            {
                MatchesToRaiseTable.Add(match);
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
            MarathonBets = new List<BetInfo>();
            foreach (StructureOfRaise reBet in BetsStructure)
            {
                var matchList = new List<int> {reBet.MatchNum};
                var outcomes = new List<int> {reBet.Outcome};
                var coef = reBet.SingleMatchCoef;
                var prob = reBet.SingleMatchProb;
                var betsize = -reBet.ToBet;    // Negative here
                BetInfo bet = new BetInfo(matchList,outcomes,betsize,coef,prob);
                MarathonBets.Add(bet);
            }
        }
    }
}
