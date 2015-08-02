using System;
using System.Data;

namespace DecVarianceProject.Structures.DataGridViewsRepositoryFolder
{
    [Serializable]
    public class MatchDayResults:DataGridViewsRepository
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
