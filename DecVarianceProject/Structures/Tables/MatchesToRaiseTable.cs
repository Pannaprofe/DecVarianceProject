using System;

namespace DecVarianceProject.Structures.Tables
{
    [Serializable]
    public class MatchesToRaiseTable:MatchDayResultsTable
    {
        public double BetSize { get; set; }
    }
}
