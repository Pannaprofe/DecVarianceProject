using System;
using System.Collections.Generic;

namespace DecVarianceProject.Entities.Structures
{
    [Serializable]
    public class TestInfo
    {
        public List<EvAndVariance> EvAndVariances { get; set; }
        public double AvgEvDiff { get; set; }
        public double AvgVarianceDiff { get; set; }
    }
}
