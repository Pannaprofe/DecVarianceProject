using System;
using DecVarianceProject.Structures.TablesContents;

namespace DecVarianceProject
{
    [Serializable]
    public class TestTableContent:ITablesContent
    {
        public int IdModel { get; set; }
        public int IdMatchDay { get; set; }
        public double BetsSumm { get; set; }
        public double RaiseSumm { get; set; }
        public double NetWonBefore { get; set; }
        public double NetWonAfter { get; set; }
        public double NetWonDifference { get; set; }
    }
}
