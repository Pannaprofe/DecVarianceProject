using System;
using System.Data;
using System.Windows.Forms;
using DecVarianceProject.Properties;

namespace DecVarianceProject.Entities.DataGridViewsTablesFolder
{
    [Serializable]
    public class ProbsCoefsTable: DataGridViewsRepository
    {
        public override void ConfigureDgv()
        {
            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("MatchNum").DataType = typeof(int);
                table.Columns.Add("ProbabilityP1").DataType = typeof(double);
                table.Columns.Add("ProbabilityX").DataType = typeof(double);
                table.Columns.Add("ProbabilityP2").DataType = typeof(double);
                table.Columns.Add("CoefP1").DataType = typeof(double);
                table.Columns.Add("CoefX").DataType = typeof(double);
                table.Columns.Add("CoefP2").DataType = typeof(double);
                Dgv.DataSource = FillInTheTable(table, ListContent);
                Dgv.ReadOnly = true;
                DataGridViewColumn matchNumColumn = Dgv.Columns["MatchNum"];
                if (matchNumColumn != null)
                {
                    matchNumColumn.Width = 40;

                    var patternWidth = (Dgv.Width - matchNumColumn.Width) / 6;
                    var probP1Column = Dgv.Columns["ProbabilityP1"];
                    if (probP1Column != null) probP1Column.Width = patternWidth;
                    var probXColumn = Dgv.Columns["ProbabilityX"];
                    if (probXColumn != null) probXColumn.Width = patternWidth;
                    var probP2Column = Dgv.Columns["ProbabilityP2"];
                    if (probP2Column != null) probP2Column.Width = patternWidth;
                    var coefP1Column = Dgv.Columns["CoefP1"];
                    if (coefP1Column != null) coefP1Column.Width = patternWidth;
                    var coefXColumn = Dgv.Columns["CoefX"];
                    if (coefXColumn != null) coefXColumn.Width = patternWidth;
                    var coefP2Column = Dgv.Columns["CoefP2"];
                    if (coefP2Column != null) coefP2Column.Width = patternWidth;
                }
                BindSortingEventToATableHeader(Dgv);
            }
            catch
            {
                MessageBox.Show(Resources.ProbsCoefs_ConfigureDgv_The_Number_of_Columns_is_less_then_requested_in_DGV_Table_or_cell_type_missmatch_has_occured);
                throw;
            }
        }
    }
}
