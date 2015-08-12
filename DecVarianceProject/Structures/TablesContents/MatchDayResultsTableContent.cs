using System;

namespace DecVarianceProject.Structures.TablesContents
{
    [Serializable]
    public class MatchDayResultsTableContent:ITablesContent
    {
        public int MatchNum { get; set; }
        public string MatchOutcome { get; set; }
    }
}
