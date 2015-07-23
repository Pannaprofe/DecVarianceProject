using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecVarianceProject
{
    public class Bets:DataGridViewsRepository
    {
        public override void ConfigureDGV()
        {
            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("BetNum").DataType = typeof(Int32);
                table.Columns.Add("BetSize").DataType = typeof(Int32);
                table.Columns.Add("Coef").DataType = typeof(double);
                table.Columns.Add("MatchResults").DataType = typeof(string);
                DGV.DataSource = FillInTheTable(table, ListContent);
                DGV.ReadOnly = true;
                DataGridViewColumn betNumColumn = DGV.Columns["BetNum"];
                betNumColumn.Width = 50;
                DataGridViewColumn betSizeColumn = DGV.Columns["BetSize"];
                betSizeColumn.Width = 60;
                DataGridViewColumn coefColumn = DGV.Columns["Coef"];
                coefColumn.Width = 70;
                DataGridViewColumn chosenMatchesResultsColumn = DGV.Columns["MatchResults"];
                chosenMatchesResultsColumn.Width = DGV.Width - (betSizeColumn.Width + coefColumn.Width + betNumColumn.Width);
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
