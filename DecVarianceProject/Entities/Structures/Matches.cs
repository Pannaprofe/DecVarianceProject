using System;
using System.Collections.Generic;

namespace DecVarianceProject.Entities.Structures
{
    [Serializable]
    public class Matches
    {
        public List<int> MatchList { get; set; }
        public List<int> Outcomes { get; set; }
        public int Count { get { return MatchList.Count; } }
    }
}
