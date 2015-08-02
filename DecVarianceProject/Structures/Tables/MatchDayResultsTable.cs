using System;

namespace DecVarianceProject.Structures.Tables
{
    [Serializable]
    public class MatchDayResultsTable:ITablesContent
    {
        public int MatchNum { get; set; }
        public string MatchOutcome { get; set; }
    }
}
