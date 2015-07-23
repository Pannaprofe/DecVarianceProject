using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecVarianceProject
{
    public abstract class DataGridViewsRepository:IDataGridViewRepository
    {
        public List<TablesContent> ListContent { get; set; }
        public DataGridView DGV { get; set; }
        public abstract void ConfigureDGV();
        public DataTable FillInTheTable(DataTable table, List<TablesContent> list)
        {
            foreach (var row in list)
            {
                var properties = row.GetType().GetProperties();
                var propertiesForTableCount = properties.Count();
                string[] rowAsTheList = new string[propertiesForTableCount];
                for (int i = 0; i < propertiesForTableCount; i++)
                {
                    rowAsTheList[i] = Convert.ToString(properties[i].GetValue(row, null));
                }
                table.Rows.Add(rowAsTheList);
            }
            return table;
        }
        public void BindSortingEventToATableHeader(DataGridView dgv)
        {
            List<string> sortColumns = new List<string>();
            dgv.ColumnHeaderMouseClick += (o, e) =>
            {
                DataGridView grid = (o as DataGridView);
                string colName = grid.Columns[e.ColumnIndex].DataPropertyName;

                sortColumns.Remove(colName);
                sortColumns.Add(colName);
                string sortExpr = "";
                foreach (string c in sortColumns)
                    sortExpr = c + "," + sortExpr;

                (grid.DataSource as DataTable).DefaultView.Sort = sortExpr.Trim(',');
            };
        }
    }
}
