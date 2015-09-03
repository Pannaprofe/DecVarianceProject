using System.Collections.Generic;
using System.Linq;
using DecVarianceProject.Entities.DataGridViewsTablesFolder;
using DecVarianceProject.Entities.Structures;
using DecVarianceProject.Entities.TablesContents;

namespace DecVarianceProject.AppLogic
{
    public class Simulation
    {
        private Singleton _instance;

        public void Exexute()
        {
            _instance = Singleton.Instance;
            _instance.Creator = new ProbsCoefsBetsCreator();
            _instance.BetSplitter = new BetSplitter();
            var resultsTableList = _instance.AllResultsNoTableList.Select(elem => new ResultsInTableContent()
            {
                NetWon = elem.NetWon,
                NodePathString = elem.NodePathString,
                Node = elem.Node,
                Payments = elem.Payments,
                Probability = elem.Probability,
                Winnings = elem.Winnings
            }).ToList();

            var repository = new List<DataGridViewsRepository>
            {
                new BetsTable() {Dgv = _instance.DgvDictionary["Bets"], ListContent = new List<ITablesContent>(_instance.AllBetsForTableList)},
                new ResultsTable()
                {
                    Dgv = _instance.DgvDictionary["Results"],
                    ListContent = new List<ITablesContent>(resultsTableList)
                },
                new ProbsCoefsTable()
                {
                    Dgv = _instance.DgvDictionary["ProbsCoefs"],
                    ListContent = new List<ITablesContent>(_instance.GennedParamsList)
                },
                new MatchesToRaiseTable()
                {
                    ListContent = new List<ITablesContent>(_instance.MatchesToRaiseTableList),
                    Dgv = _instance.DgvDictionary["MatchesToRaise"]
                }
            };
            foreach (var elem in repository)
            {
                elem.ConfigureDgv();
            }
        }
    }
}
