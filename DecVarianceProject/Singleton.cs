using System.Collections.Generic;
using DecVarianceProject.Structures;
using DecVarianceProject.Structures.TablesContents;
using DecVarianceProject.Structures.DataGridViewsTablesFolder;

namespace DecVarianceProject
{
    public class Singleton
    {
        private static Singleton _instance;

        private Singleton() { }

        public static Singleton Instance
        {
            get { return _instance ?? (_instance = new Singleton()); }
        }

        //--------Variables----------------
        public List<List<double>> ProbsMarathon { get; set; }
        public List<List<double>> ProbsOtherCo { get; set; }
        public List<List<double>> CoefsMarathon { get; set; }
        public List<List<double>> CoefsOtherCo { get; set; }
        public List<GennedParamsTableContent> GennedParams { get;  set; }
        public List<BetInfo> ClientsBets { get; set; }
        public List<BetInfo> MarathonBets { get; set; }
        public List<AllBetsTableContent> AllBetsForTable { get; set; }
        public List<ResultsInTableContent> AllResultsInTable { get; set; }
        public List<MatchesToRaiseTableContent> MatchesToRaiseTable { get;  set; }
        public List<StructureOfRaise> BetsStructure { get;  set; }
        public List<MatchDayResultsTableContent> MatchDayResults { get; set; }
        public List<ResultsNotForTableContent> AllResultsNoTable { get; set; }
        
        
        public MatchDayResultsTable MatchDayResultsTable { get; set; }
        public SubTree Tree { get; set; }
        public double Rake { get; set; }
        public double LossToAllBetsSumRatio { get; set; }
        public int MatchesNum { get;set; }
        public int BetsNum { get;  set; }
        public int MaxWinnings { get; set; }
        public double EvBefore { get; set; }
        public double EvAfter { get; set; }
        public ProbsCoefsBetsCreator Creator { get; set; }
        public double RaiseSumPercent { get; set; }
        public double RaiseSum { get; set; }
        public double AllBetsSum { get; set; }
        public double NetWonBefore { get; set; }
        public double NetWonAfter { get; set; }
        public BetSplitter BetSplitter { get; set; }

    }
}
