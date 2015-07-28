using DecVarianceProject.Structures.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecVarianceProject
{
    public class BetSplitter
    {
        public double ReBetSum { get; private set; }
        public int ReBetMatchesNum { get; private set; }
        public double Rake { get; private set; }
        public List<BetInfo> AllBets { get; private set; }
        public double AllBetsSum { get; private set; }
        public List<BetInfo> MarathonBets { get; private set; }
        public List<MatchesToRaiseTable> matchesToRaiseTable { get; private set; }

        public List<StructureOfReBet> BetsStructure { get; private set; }

        public List<MatchParams> CoefsOtherCo { get; set; }

        public BetSplitter(List<BetInfo> allBets, double percent,int rebetMatchesNum, double rake, List<MatchParams> coefsOtherCo)
        {
            EstimateBetsSumm(allBets,percent);
            this.ReBetMatchesNum = rebetMatchesNum;
            this.Rake = rake;
            this.AllBets = allBets;
            this.CoefsOtherCo = coefsOtherCo;
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
            BetsStructure = new List<StructureOfReBet>(CoefsOtherCo.Count);
            for (int i = 0; i < CoefsOtherCo.Count;i++ )
            {
                BetsStructure.Add(new StructureOfReBet());
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
                                break;
                            case 2:
                                BetsStructure[bet.MatchesAndOutcomes.MatchList[i]].SingleMatchCoef = CoefsOtherCo[i].P2;
                                break;
                            case 0:
                                BetsStructure[bet.MatchesAndOutcomes.MatchList[i]].SingleMatchCoef = CoefsOtherCo[i].X;
                                break;
                        }
                        BetsStructure[bet.MatchesAndOutcomes.MatchList[i]].BetsAmmount += bet.BetSize;
                    }
                }

            foreach (StructureOfReBet reBet in BetsStructure)
            {
                reBet.EvDiff = EstimateEVDifference(reBet);
            }
            
        }

        private void SplitMoney()
        {
            List<StructureOfReBet> sortedBetsStructure = BetsStructure.OrderBy(o => o.EvDiff).ToList();
            var cuttedBetsStructure = sortedBetsStructure.Take(ReBetMatchesNum);
            double reverseCoefsSum = 0;
            foreach (StructureOfReBet structure in cuttedBetsStructure)
            {
                reverseCoefsSum += 1 / structure.SingleMatchCoef;
            }

            foreach (StructureOfReBet structure in cuttedBetsStructure)
            {
                structure.ToBet = Math.Round(ReBetSum / reverseCoefsSum/structure.SingleMatchCoef,2);
            }
            BetsStructure = new List<StructureOfReBet>(cuttedBetsStructure);
        }

        private double EstimateEVDifference(StructureOfReBet bet)
        {
            var MaxLoss = -(bet.SingleMatchCoef - 1) * bet.BetsAmmount;
            var EV = bet.BetsAmmount * Rake;
            return MaxLoss - EV;
        }

        public void ConvertStructureToTable()
        {
            matchesToRaiseTable = new List<MatchesToRaiseTable>();
            foreach (StructureOfReBet reBet in BetsStructure)
            {
                MatchesToRaiseTable match = new MatchesToRaiseTable();
                match.MatchNum = reBet.MatchNum;
                match.MatchOutcome = ConvertOutcomeIntToString(reBet.Outcome);
                match.BetSize = reBet.ToBet;
                matchesToRaiseTable.Add(match);
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
            foreach (StructureOfReBet reBet in BetsStructure)
            {
                var matchList = new List<int>();
                matchList.Add(reBet.MatchNum);
                var outcomes = new List<int>();
                outcomes.Add(reBet.Outcome);
                var coef = reBet.SingleMatchCoef;
                var betsize = -reBet.ToBet;    // Negative here
                BetInfo bet = new BetInfo(matchList,outcomes,betsize,coef);
                MarathonBets.Add(bet);
            }
        }
    }
}
