using System;
using System.Data;
using System.Windows.Forms;
using DecVarianceProject.Properties;

namespace DecVarianceProject.Entities.DataGridViewsTablesFolder
{
    [Serializable]
    public class ResultsTable:DataGridViewsRepository
    {
        public override void ConfigureDgv()
        {
            try
            {
                var table = new DataTable();
                table.Columns.Add("Node").DataType = typeof(int);
                table.Columns.Add("Probability").DataType = typeof(double);
                table.Columns.Add("Payments").DataType = typeof(double);
                table.Columns.Add("Winnings").DataType = typeof(double);
                table.Columns.Add("NetWon").DataType = typeof(double);
                table.Columns.Add("Path").DataType = typeof(string);
                Dgv.DataSource = FillInTheTable(table, ListContent);
                Dgv.ReadOnly = true;
                var nodeNumColumn = Dgv.Columns["Node"];
                nodeNumColumn.Width = 50;
                var probabilityColumn = Dgv.Columns["Probability"];
                  
                probabilityColumn.Width = 60;
                var patternWidth = Dgv.Width / 6;
                var paymentsColumn = Dgv.Columns["Payments"];
                paymentsColumn.Width = patternWidth;
                var winningsColumn = Dgv.Columns["Winnings"];
                winningsColumn.Width = patternWidth;
                var netWonColumn = Dgv.Columns["NetWon"];
                netWonColumn.Width = patternWidth;
                var pathColumn = Dgv.Columns["Path"];
                pathColumn.Width = Dgv.Width - (nodeNumColumn.Width + probabilityColumn.Width + paymentsColumn.Width + winningsColumn.Width + netWonColumn.Width);

                BindSortingEventToATableHeader(Dgv);
            }
            catch
            {
                MessageBox.Show(Resources.Results_ConfigureDgv_The_Number_of_Columns_is_less_then_requested_in_DGV_Table__or_cell_type_missmatch_has_occured);
                throw;
            }
        }
    }
}
