using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecVarianceProject
{
    public class Results:DataGridViewsRepository
    {
        public override void ConfigureDGV()
        {
            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("Node").DataType = typeof(Int32);
                table.Columns.Add("Probability").DataType = typeof(double);
                table.Columns.Add("Payments").DataType = typeof(double);
                table.Columns.Add("Winnings").DataType = typeof(double);
                table.Columns.Add("NetWon").DataType = typeof(double);
                table.Columns.Add("Path").DataType = typeof(string);
                DGV.DataSource = FillInTheTable(table, ListContent);
                DGV.ReadOnly = true;
                DataGridViewColumn nodeNumColumn = DGV.Columns["Node"];
                nodeNumColumn.Width = 50;
                DataGridViewColumn probabilityColumn = DGV.Columns["Probability"];
                probabilityColumn.Width = 60;
                int patternWidth = (int)DGV.Width / 6;
                DataGridViewColumn paymentsColumn = DGV.Columns["Payments"];
                paymentsColumn.Width = patternWidth;
                DataGridViewColumn winningsColumn = DGV.Columns["Winnings"];
                winningsColumn.Width = patternWidth;
                DataGridViewColumn netWonColumn = DGV.Columns["NetWon"];
                netWonColumn.Width = patternWidth;
                DataGridViewColumn pathColumn = DGV.Columns["Path"];
                pathColumn.Width = DGV.Width - (nodeNumColumn.Width + probabilityColumn.Width + paymentsColumn.Width + winningsColumn.Width + netWonColumn.Width);
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
