using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecVarianceProject
{
    public class GennedParamsInTable:TablesContent
    {
        public int MatchNum { get; set; }
        public double ProbabilityP1 { get; set; }
        public double ProbabilityX { get; set; }
        public double ProbabilityP2 { get; set; }

        public double CoefP1 { get; set; }
        public double CoefX { get; set; }
        public double CoefP2 { get; set; }

        /*When adding X more properties to a class u should subtract X from this number for the table to be shown correctly. 
         * Here we subtract 1 in order not to estimate "Count" property*/
        public GennedParamsInTable()
        {
            this.Count = this.GetType().GetProperties().Count() - 1;
        }
    }
}
