using System;
using System.Data;
using System.Windows.Forms;
using DecVarianceProject.Properties;

namespace DecVarianceProject.Structures.DataGridViewsRepositoryFolder
{
    [Serializable]
    public class Test:DataGridViewsRepository
    {
        public override void ConfigureDgv()
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
                Dgv.DataSource = FillInTheTable(table, ListContent);
                BindSortingEventToATableHeader(Dgv);
            }
            catch
            {
                MessageBox.Show(Resources.Test_ConfigureDgv_The_Number_of_Columns_is_less_then_requested_in_DGV_Table__or_cell_type_missmatch_has_occured);
                throw;
            }
        }
    }
}
