using System;
using System.Collections.Generic;
using DecVarianceProject.Structures;

namespace DecVarianceProject
{
    [Serializable]
    public class MarathonNetWon
    {
        private Singleton Instance = Singleton.Instance;
        public double Ammount{ get; private set; }

        public double EstimateMarathonNetWon()
        {
            Ammount = 0;
            foreach (BetInfo bet in Instance.AllBets)
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
                if (bet.MatchesAndOutcomes.Outcomes[i] != ConvertOutcomeStringToInt(Instance.MatchDayResults[bet.MatchesAndOutcomes.MatchList[i]].MatchOutcome))
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
            Instance.EvBefore = 0;
            foreach (BetInfo bet in Instance.AllBets)
            {
                Instance.EvBefore += bet.BetSize * Instance.Rake;
            }
            return Instance.EvBefore;
        }

        public double EstimateMarathonEvAfter(List<BetInfo> raiseMatchesBets)
        {
            Instance.EvAfter = 0;
            foreach (BetInfo bet in raiseMatchesBets)
            {
                var betsize = -bet.BetSize;
                Instance.EvAfter += betsize * bet.Prob * (bet.Coef - 1) - (1 - bet.Prob) * betsize;
            }
            Instance.EvAfter += Instance.EvBefore;
            return Instance.EvAfter;
        }
    }
}
