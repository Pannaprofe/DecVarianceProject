using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecVarianceProject.Structures.Tables;

namespace DecVarianceProject
{
    [Serializable]
    public class TestTable:ITablesContent
    {
        public int IdModel { get; set; }
        public int IdMatchDay { get; set; }
        public double BetsSumm { get; set; }
        public double RaiseSumm { get; set; }
        public double NetWonBefore { get; set; }
        public double NetWonAfter { get; set; }
        public double EVDifference { get; set; }
    }
}
