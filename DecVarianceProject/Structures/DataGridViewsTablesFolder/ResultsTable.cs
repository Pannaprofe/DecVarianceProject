using System;
using System.Data;
using System.Windows.Forms;
using DecVarianceProject.Properties;

namespace DecVarianceProject
{
    [Serializable]
    public class ResultsTable:DataGridViewsRepository
    {
        public override void ConfigureDgv()
        {
            try
            {
                var table = new DataTable();
                table.Columns.Add("Node").DataType = typeof(Int32);
                table.Columns.Add("Probability").DataType = typeof(double);
                table.Columns.Add("Payments").DataType = typeof(double);
                table.Columns.Add("Winnings").DataType = typeof(double);
                table.Columns.Add("NetWon").DataType = typeof(double);
                table.Columns.Add("Path").DataType = typeof(string);
                Dgv.DataSource = FillInTheTable(table, ListContent);
                Dgv.ReadOnly = true;
                var nodeNumColumn = Dgv.Columns["Node"];
                if (nodeNumColumn != null)
                {
                    nodeNumColumn.Width = 50;
                    var probabilityColumn = Dgv.Columns["Probability"];
                    if (probabilityColumn != null)
                    {
                        probabilityColumn.Width = 60;
                        var patternWidth = Dgv.Width / 6;
                        var paymentsColumn = Dgv.Columns["Payments"];
                        if (paymentsColumn != null)
                        {
                            paymentsColumn.Width = patternWidth;
                            var winningsColumn = Dgv.Columns["Winnings"];
                            if (winningsColumn != null)
                            {
                                winningsColumn.Width = patternWidth;
                                var netWonColumn = Dgv.Columns["NetWon"];
                                if (netWonColumn != null)
                                {
                                    netWonColumn.Width = patternWidth;
                                    var pathColumn = Dgv.Columns["Path"];
                                    if (pathColumn != null)
                                        pathColumn.Width = Dgv.Width - (nodeNumColumn.Width + probabilityColumn.Width + paymentsColumn.Width + winningsColumn.Width + netWonColumn.Width);
                                }
                            }
                        }
                    }
                }
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
