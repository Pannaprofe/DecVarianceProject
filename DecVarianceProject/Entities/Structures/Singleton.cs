using System.Collections.Generic;
using System.Windows.Forms;
using DecVarianceProject.AppLogic;
using DecVarianceProject.Entities.DataGridViewsTablesFolder;
using DecVarianceProject.Entities.TablesContents;

namespace DecVarianceProject.Entities.Structures
{
    public class Singleton
    {
        private static Singleton _instance;

        private Singleton()
        {
            //ProbsMarathonList = new List<List<double>>();
            //ProbsOtherCoList = new List<List<double>>();
            //CoefsMarathonList = new List<List<double>>();
            //CoefsOtherCoList = new List<List<double>>();
            //GennedParamsList = new List<GennedParamsTableContent>();
            //ClientsBetsList = new List<BetInfo>();
            //MarathonBetsList = new List<BetInfo>();
            //AllBetsForTableList = new List<AllBetsTableContent>();
            //AllResultsInTableList = new List<ResultsInTableContent>();
            //MatchesToRaiseTableList = new List<MatchesToRaiseTableContent>();
            //BetsStructureList = new List<StructureOfRaise>();
           // MatchDayResultsList = new List<MatchDayResultsTableContent>();
            AllResultsNoTableList = new List<ResultsNotForTableContent>();
            DgvDictionary = new Dictionary<string, DataGridView>();

        }

        public static Singleton Instance
        {
            get { return _instance ?? (_instance = new Singleton()); }
        }

        //--------Variables----------------
        public List<List<double>> ProbsMarathonList { get; set; }
        public List<List<double>> ProbsOtherCoList { get; set; }
        public List<List<double>> CoefsMarathonList { get; set; }
        public List<List<double>> CoefsOtherCoList { get; set; }
        public List<GennedParamsTableContent> GennedParamsList { get;  set; }
        public List<BetInfo> ClientsBetsList { get; set; }
        public List<BetInfo> MarathonBetsList { get; set; }
        public List<AllBetsTableContent> AllBetsForTableList { get; set; }
        public List<ResultsInTableContent> AllResultsInTableList { get; set; }
        public List<MatchesToRaiseTableContent> MatchesToRaiseTableList { get;  set; }
        public List<StructureOfRaise> BetsStructureList { get;  set; }
        public List<MatchDayResultsTableContent> MatchDayResultsList { get; set; }
        public List<ResultsNotForTableContent> AllResultsNoTableList { get; set; }
        public Dictionary< string,DataGridView> DgvDictionary { get; set; }
        
        
        public MatchDayResultsTable MatchDayResultsTable { get; set; }
        public SubTree Tree { get; set; }
        public ProbsCoefsBetsCreator Creator { get; set; }
        public BetSplitter BetSplitter { get; set; }
        public MatchDayResults MatchDayResults { get; set; }

        public double Rake { get; set; }
        public int MatchesNum { get;set; }
        public int BetsNum { get;  set; }
        public int MaxWinnings { get; set; }
        public double RaiseSumPercent { get; set; }
        public double RaiseSum { get; set; }
        public double AllBetsSum { get; set; }

        public double EvBefore { get; set; }
        public double EvAfter { get; set; }
        public double NetWonBefore { get; set; }
        public double NetWonAfter { get; set; }

        public double OutcomesFrequencesRatio { get { return 0.7; } }
        public double LossToAllBetsSumRatio { get { return 0.5; } }

    }
}
