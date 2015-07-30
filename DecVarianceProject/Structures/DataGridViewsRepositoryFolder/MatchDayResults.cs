using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecVarianceProject
{
    [Serializable]
    public class MatchDayResults:DataGridViewsRepository
    {
        
        public override void ConfigureDGV()
        {
            DataTable table = new DataTable();
            table.Columns.Add("MatchNum").DataType = typeof(Int32);
            table.Columns.Add("Outcome").DataType = typeof(string);
            DGV.DataSource = FillInTheTable(table, ListContent);
            BindSortingEventToATableHeader(DGV);
        }
    }
}
