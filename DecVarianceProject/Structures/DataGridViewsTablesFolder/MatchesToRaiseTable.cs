using System;
using System.Data;

namespace DecVarianceProject.Structures.DataGridViewsTablesFolder
{
    [Serializable]
    public class MatchesToRaiseTable: DataGridViewsRepository
    {
        
        public override void ConfigureDgv()
        {
            DataTable table = new DataTable();
            table.Columns.Add("BetSize").DataType = typeof(double);
            table.Columns.Add("MatchNum").DataType = typeof(Int32);
            table.Columns.Add("Outcome").DataType = typeof(string);
            Dgv.DataSource = FillInTheTable(table, ListContent);
            BindSortingEventToATableHeader(Dgv);
        }
    }
}
