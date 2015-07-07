using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecVarianceProject
{
    public class ResultsInTable:TablesContent
    {
        public int Node { get; set; }
        public double Probability { get; set; }
        public double Payments { get; set; }
        public double Winnings { get; set; }
        public double NetWon { get; set; }
        public string NodePath { get; set; }

        /*When adding X more properties to a class u should subtract X from this number for the table to be shown correctly. 
         * Here we subtract 1 in order not to estimate "Count" property*/
        public ResultsInTable()
        {
            this.Count = this.GetType().GetProperties().Count() - 1;
        }
    }
}
