using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecVarianceProject
{
    [Serializable]
    public class Test:DataGridViewsRepository
    {
        public override void ConfigureDGV()
        {
            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("id Model").DataType = typeof(int);
                table.Columns.Add("id MatchDay").DataType = typeof(int);
                table.Columns.Add("Bets Summ").DataType = typeof(double);
                table.Columns.Add("Raise Summ").DataType = typeof(double);
                table.Columns.Add("NetWon Before").DataType = typeof(double);
                table.Columns.Add("NetWon After").DataType = typeof(double);
                DGV.DataSource = FillInTheTable(table, ListContent);
                BindSortingEventToATableHeader(DGV);
            }
            catch
            {
                MessageBox.Show("The Number of Columns is less then requested in DGV Table  or cell type missmatch has occured");
                throw;
            }
        }
    }
}
