using System;
using System.Data;

namespace DecVarianceProject.Entities.DataGridViewsTablesFolder
{
    [Serializable]
    public class MatchDayResultsTable:DataGridViewsRepository
    {
        
        public override void ConfigureDgv()
        {
            DataTable table = new DataTable();
            table.Columns.Add("MatchNum").DataType = typeof(int);
            table.Columns.Add("Outcome").DataType = typeof(string);
            Dgv.DataSource = FillInTheTable(table, ListContent);
            BindSortingEventToATableHeader(Dgv);
        }
    }
}
