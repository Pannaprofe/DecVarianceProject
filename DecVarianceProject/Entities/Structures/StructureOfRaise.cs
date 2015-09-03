using System;

namespace DecVarianceProject.Entities.Structures
{
    [Serializable]
    public class StructureOfRaise
    {
        public int MatchNum { get; set; }
        public int Outcome { get; set; }

        public double SingleMatchCoef { get; set; }
        public double SingleMatchProb { get; set; }
        public double ToBet { get; set; }
    }
}
