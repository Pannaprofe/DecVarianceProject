using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecVarianceProject
{
    [Serializable]
    public class TestTable:TablesContent
    {
        public int IdModel { get; set; }
        public int IdMatchDay { get; set; }
        public double BetsSumm { get; set; }
        public double RaiseSumm { get; set; }
        public double NetWonBefore { get; set; }
        public double NetWonAfter { get; set; }
    }
}
