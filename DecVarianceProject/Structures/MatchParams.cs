using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecVarianceProject
{
    [Serializable]
    public class MatchParams
    {
        public double P1 { get; set; }
        public double P2 { get; set; }
        public double X { get; set; }

        public MatchParams(double x1, double x2, double x)
        {
            this.P1 = x1;
            this.P2 = x2;
            this.X = x;
        }
    }
}
