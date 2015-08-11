using System;
using System.Collections.Generic;

namespace DecVarianceProject
{
    [Serializable]
    public class ResultsInTableContent : ITablesContent
    {
        public int Node { get; set; }
        public double Probability { get; set; }
        public double Payments { get; set; }
        public double Winnings { get; set; }
        public double NetWon { get; set; }
        public string NodePathString { get; set; }
    }
}
