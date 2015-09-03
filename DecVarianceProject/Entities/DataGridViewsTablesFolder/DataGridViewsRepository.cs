using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DecVarianceProject.Entities.TablesContents;

namespace DecVarianceProject.Entities.DataGridViewsTablesFolder
{
    [Serializable]
    public abstract class DataGridViewsRepository:IDataGridViewRepository
    {
        public List<ITablesContent> ListContent { get; set; }
        public DataGridView Dgv { get; set; }
        public abstract void ConfigureDgv();
        public DataTable FillInTheTable(DataTable table, List<ITablesContent> list)
        {
            foreach (var row in list)
            {
                var properties = row.GetType().GetProperties();
                var propertiesForTableCount = properties.Count();
                var rowAsTheList = new object[propertiesForTableCount];
                for (var i = 0; i < propertiesForTableCount; i++)
                {
                    rowAsTheList[i] = Convert.ToString(properties[i].GetValue(row, null));
                }
                table.Rows.Add(rowAsTheList);
            }
            return table;
        }
        public void BindSortingEventToATableHeader(DataGridView dgv)
        {
            var sortColumns = new List<string>();
            dgv.ColumnHeaderMouseClick += (o, e) =>
            {
                var grid = (o as DataGridView);
                if (grid != null)
                {
                    var colName = grid.Columns[e.ColumnIndex].DataPropertyName;

                    sortColumns.Remove(colName);
                    sortColumns.Add(colName);
                }
                var sortExpr = sortColumns.Aggregate("", (current, c) => c + "," + current);

                if (grid == null) return;
                var dataTable = grid.DataSource as DataTable;
                if (dataTable != null)
                    dataTable.DefaultView.Sort = sortExpr.Trim(',');
            };
        }
    }
}
