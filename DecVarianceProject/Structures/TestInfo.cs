using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecVarianceProject.Structures
{
    [Serializable]
    public class TestInfo
    {
        public List<EvAndVariance> EvAndVariances { get; set; }
        public double AvgEvDiff { get; set; }
        public double AvgVarianceDiff { get; set; }
    }
}
