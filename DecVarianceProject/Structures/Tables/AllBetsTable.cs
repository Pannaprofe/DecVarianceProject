using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecVarianceProject
{
    public class AllBetsTable:TablesContent
    {
        public int BetNum { get; set; }
        public double BetSize { get; set; }
        public double Coef { get; set; }
        public string ChosenMatchesResults { get; set; }

        /*When adding X more properties to a class u should subtract X from this number for the table to be shown correctly. 
         * Here we subtract 1 in order not to estimate "Count" property*/
        public AllBetsTable()
        {
            this.Count = this.GetType().GetProperties().Count() -1 ; 
        }
    }
}
