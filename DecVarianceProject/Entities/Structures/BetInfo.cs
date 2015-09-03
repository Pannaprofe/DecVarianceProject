using System;
using System.Collections.Generic;
using DecVarianceProject.Entities;

namespace DecVarianceProject.Entities.Structures
{
    [Serializable]
    public class BetInfo
    {
        public Matches MatchesAndOutcomes { get; set; }
        public double BetSize { get; set; }
        public double Coef { get; set; }
        public double Prob { get; set; }

        public BetInfo(List<int> matchList, List<int> outcomes, double betSize, double coef, double prob)
        {
            MatchesAndOutcomes = new Matches
            {
                MatchList = matchList,
                Outcomes = outcomes
            };
            BetSize = betSize;
            Coef = coef;
            Prob = prob;
        }
    }
}
