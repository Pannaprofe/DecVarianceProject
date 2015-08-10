using System;

namespace DecVarianceProject
{
    [Serializable]
    public class AllBetsTableContent:ITablesContent
    {
        public int BetNum { get; set; }
        public double BetSize { get; set; }
        public double Coef { get; set; }
        public string ChosenMatchesResults { get; set; }
    }
}
