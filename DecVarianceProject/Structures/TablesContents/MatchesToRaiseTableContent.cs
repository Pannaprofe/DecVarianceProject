using System;

namespace DecVarianceProject.Structures.TablesContents
{
    [Serializable]
    public class MatchesToRaiseTableContent:MatchDayResultsTableContent
    {
        public double BetSize { get; set; }
    }
}
