using System;

namespace DecVarianceProject.Entities.TablesContents
{
    [Serializable]
    public class MatchDayResultsTableContent:ITablesContent
    {
        public int MatchNum { get; set; }
        public string MatchOutcome { get; set; }
    }
}
