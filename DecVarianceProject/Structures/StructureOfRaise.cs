using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecVarianceProject
{
    [Serializable]
    public class StructureOfRaise
    {
        public int MatchNum { get; set; }
        public int Outcome { get; set; }

        public double SingleMatchCoef { get; set; }
        public double BetsAmmount { get; set; }
        public double ToBet { get; set; }
        public double EvDiff { get; set; }
    }
}
