using System;

namespace DecVarianceProject.Structures.Tables
{
    [Serializable]
    public class GennedParamsInTable:ITablesContent
    {
        public int MatchNum { get; set; }
        public double ProbabilityP1 { get; set; }
        public double ProbabilityX { get; set; }
        public double ProbabilityP2 { get; set; }

        public double CoefP1 { get; set; }
        public double CoefX { get; set; }
        public double CoefP2 { get; set; }
    }
}
