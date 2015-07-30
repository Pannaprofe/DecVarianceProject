using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecVarianceProject.Structures.Tables
{
    [Serializable]
    public class MatchDayResultsTable:TablesContent
    {
        public int MatchNum { get; set; }
        public string MatchOutcome { get; set; }
    }
}
