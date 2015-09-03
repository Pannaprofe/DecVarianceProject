using System;
using System.Collections.Generic;
using DecVarianceProject.Entities.Structures;

namespace DecVarianceProject.AppLogic
{
    [Serializable]
    public class MarathonNetWon
    {
        private readonly Singleton _instance = Singleton.Instance;
        public double Ammount{ get; private set; }
        public List<BetInfo> Bets { get; set; }

        public double EstimateMarathonNetWon()
        {
            Ammount = 0;
            foreach (var bet in Bets)
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
            for (var i = 0; i < bet.MatchesAndOutcomes.Count; i++)
            {
                if (bet.MatchesAndOutcomes.Outcomes[i] != ConvertOutcomeStringToInt(_instance.MatchDayResultsList[bet.MatchesAndOutcomes.MatchList[i]].MatchOutcome))
                    return false;
            }
            return true;
        }

        private static int ConvertOutcomeStringToInt(string str)
        {
            switch (str)
            {
                case "P1":
                    return 1;
                case "P2":
                    return 2;
                default:
                    return 0;
            }
        }

        public double EstimateMarathonEvBefore()
        {
            _instance.EvBefore = 0;
            foreach (var bet in Bets)
            {
                _instance.EvBefore += bet.BetSize * _instance.Rake;
            }
            return _instance.EvBefore;
        }

        public double EstimateMarathonEvAfter(List<BetInfo> raiseMatchesBets)
        {
            _instance.EvAfter = 0;
            foreach (var bet in raiseMatchesBets)
            {
                var betsize = -bet.BetSize;
                _instance.EvAfter += betsize * bet.Prob * (bet.Coef - 1) - (1 - bet.Prob) * betsize;
            }
            _instance.EvAfter += _instance.EvBefore;
            return _instance.EvAfter;
        }
    }
}
