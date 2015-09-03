using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DecVarianceProject.Entities.DataGridViewsTablesFolder;
using DecVarianceProject.Entities.Structures;
using DecVarianceProject.Entities.TablesContents;
using DecVarianceProject.Forms;

namespace DecVarianceProject.AppLogic
{
    public class MatchDayResults
    {
        public DataGridView DgView { get; set; } 
        private readonly Singleton _instance;

        public MatchDayResults(DataGridView dgv)
        {
            DgView = dgv;
            _instance = Singleton.Instance;
        }

        public void Generate(bool isAutomatic)
        {
            var dialog = new MatchDayResultsDialog(isAutomatic);
            if (!isAutomatic)
            {
                var dr = dialog.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    var matchday = new MatchDayResultsTable() { ListContent = new List<ITablesContent>(_instance.MatchDayResultsList), Dgv = DgView };
                    matchday.ConfigureDgv();
                }
            }
            var matchday1 = new MatchDayResultsTable() { ListContent = new List<ITablesContent>(_instance.MatchDayResultsList), Dgv = DgView };
            matchday1.ConfigureDgv();

            //Estimate Marathon NetWon before raising
            var netWon = new MarathonNetWon() { Bets = _instance.ClientsBetsList };
            _instance.NetWonBefore = Math.Round(netWon.EstimateMarathonNetWon(), 2);
            
            _instance.EvBefore = Math.Round(netWon.EstimateMarathonEvBefore(), 2);

            //----------------------------------------
            //Estimate Marathon NetWon after raising
            var bets = _instance.ClientsBetsList;
            _instance.BetSplitter.GenListOfMarathonBets();    // Result => Instance.MarathonBets
            netWon = new MarathonNetWon() { Bets = _instance.MarathonBetsList };
            _instance.NetWonAfter = Math.Round(netWon.EstimateMarathonNetWon() + _instance.NetWonBefore, 2);
            _instance.EvAfter = Math.Round(netWon.EstimateMarathonEvAfter(_instance.MarathonBetsList), 2);
            _instance.ClientsBetsList = new List<BetInfo>(bets);
            //-----------------------------------------

        }
    }
}
