using System;

namespace DecVarianceProject.Entities.TablesContents
{
    [Serializable]
    public class MatchesToRaiseTableContent:MatchDayResultsTableContent
    {
        public double BetSize { get; set; }
    }
}
