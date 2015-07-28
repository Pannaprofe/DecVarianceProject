using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecVarianceProject
{
    public class BetInfo
    {
        public Matches MatchesAndOutcomes { get; set; }
        public double BetSize { get; set; }
        public double Coef { get; set; }

        public BetInfo(List<int> matchList, List<int> outcomes, double betSize, double coef)
        {
            MatchesAndOutcomes = new Matches();
            this.MatchesAndOutcomes.MatchList = matchList;
            this.MatchesAndOutcomes.Outcomes = outcomes;
            this.BetSize = betSize;
            this.Coef = coef;
        }
    }
}
