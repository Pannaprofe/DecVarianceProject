using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecVarianceProject.Structures.Tables
{
    [Serializable]
    public class MatchesToRaiseTable:MatchDayResultsTable
    {
        public double BetSize { get; set; }
    }
}
