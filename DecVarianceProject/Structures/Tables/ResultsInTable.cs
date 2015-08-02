using System;

namespace DecVarianceProject.Structures.Tables
{
    [Serializable]
    public class ResultsInTable:ITablesContent
    {
        public int Node { get; set; }
        public double Probability { get; set; }
        public double Payments { get; set; }
        public double Winnings { get; set; }
        public double NetWon { get; set; }
        public string NodePath { get; set; }
    }
}
