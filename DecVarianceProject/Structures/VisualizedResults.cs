using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecVarianceProject
{
    public class VisualizedResults
    {
        public int NodeNumber;
        public List<int> Path;
        public double Probability;
        public double Payments;
        public double Winnings;

        public VisualizedResults(int nodeNumber, List<int> path, double probability, double payments, double winnings)
        {
            this.NodeNumber = nodeNumber;
            this.Path = new List<int>(path);
            this.Probability = probability;
            this.Payments = payments;
            this.Winnings = winnings;
        }
    }
}
