using System;

namespace DecVarianceProject
{
    [Serializable]
    public class MatchesToRaiseTableContent:MatchDayResultsTableContent
    {
        public double BetSize { get; set; }
    }
}
