using System;

namespace DecVarianceProject.Structures
{
    [Serializable]
    public class MatchParams
    {
        public double P1 { get; set; }
        public double P2 { get; set; }
        public double X { get; set; }

        public MatchParams(double x1, double x2, double x)
        {
            P1 = x1;
            P2 = x2;
            X = x;
        }
    }
}
