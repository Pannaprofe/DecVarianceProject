using System;

namespace DecVarianceProject.Structures.Tables
{
    [Serializable]
    public class AllBetsTable:ITablesContent
    {
        public int BetNum { get; set; }
        public double BetSize { get; set; }
        public double Coef { get; set; }
        public string ChosenMatchesResults { get; set; }
    }
}
