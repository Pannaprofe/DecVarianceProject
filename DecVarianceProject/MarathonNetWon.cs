using DecVarianceProject.Structures.Tables;
using System;
using System.Collections.Generic;
using DecVarianceProject.Structures;

namespace DecVarianceProject
{
    [Serializable]
    public class MarathonNetWon
    {
        public List<BetInfo> AllBets { get; set; }
        public double Ammount{ get; private set; }
        public List<MatchDayResultsTable> MatchDayResults { get; set; }
        public double MarathonEvBefore { get;  set; }
        public double MarathonEvAfter { get; private set; }
        public double Rake { get; set; }
        public double EstimateMarathonNetWon()
        {
            Ammount = 0;
            foreach (BetInfo bet in AllBets)
            {
                if (BetIsSuccessful(bet))
                {
                    Ammount -= bet.BetSize * (bet.Coef - 1);
                }
                else
                {
                    Ammount += bet.BetSize;
                }
            }
            return Ammount;
        }

        private bool BetIsSuccessful(BetInfo bet)
        {
            for (int i = 0; i < bet.MatchesAndOutcomes.Count; i++)
            {
                if (bet.MatchesAndOutcomes.Outcomes[i] != ConvertOutcomeStringToInt(MatchDayResults[bet.MatchesAndOutcomes.MatchList[i]].MatchOutcome))
                    return false;
            }
            return true;
        }

        private int ConvertOutcomeStringToInt(string str)
        {
            if (str=="P1")
            {
                return 1;
            }
            if (str == "P2")
            {
                return 2;
            }
            else
                return 0;
        }

        public double EstimateMarathonEvBefore()
        {
            MarathonEvBefore = 0;
            foreach (BetInfo bet in AllBets)
            {
                MarathonEvBefore += bet.BetSize * Rake;
            }
            return MarathonEvBefore;
        }

        public double EstimateMarathonEvAfter(List<BetInfo> raiseMatchesBets)
        {
            MarathonEvAfter = 0;
            foreach (BetInfo bet in raiseMatchesBets)
            {
                var betsize = -bet.BetSize;
                MarathonEvAfter += betsize * bet.Prob * (bet.Coef - 1) - (1 - bet.Prob) * betsize;
            }
            MarathonEvAfter += MarathonEvBefore;
            return MarathonEvAfter;
        }
    }
}
