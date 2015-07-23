using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecVarianceProject
{
    public class ProbsCoefs: DataGridViewsRepository
    {
        public override void ConfigureDGV()
        {
            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("MatchNum").DataType = typeof(Int32);
                table.Columns.Add("ProbabilityP1").DataType = typeof(double);
                table.Columns.Add("ProbabilityX").DataType = typeof(double);
                table.Columns.Add("ProbabilityP2").DataType = typeof(double);
                table.Columns.Add("CoefP1").DataType = typeof(double);
                table.Columns.Add("CoefX").DataType = typeof(double);
                table.Columns.Add("CoefP2").DataType = typeof(double);
                DGV.DataSource = FillInTheTable(table, ListContent);
                DGV.ReadOnly = true;
                DataGridViewColumn matchNumColumn = DGV.Columns["MatchNum"];
                matchNumColumn.Width = 40;

                int patternWidth = (int)(DGV.Width - matchNumColumn.Width) / 6;
                DataGridViewColumn probP1Column = DGV.Columns["ProbabilityP1"];
                probP1Column.Width = patternWidth;
                DataGridViewColumn probXColumn = DGV.Columns["ProbabilityX"];
                probXColumn.Width = patternWidth;
                DataGridViewColumn probP2Column = DGV.Columns["ProbabilityP2"];
                probP2Column.Width = patternWidth;
                DataGridViewColumn coefP1Column = DGV.Columns["CoefP1"];
                coefP1Column.Width = patternWidth;
                DataGridViewColumn coefXColumn = DGV.Columns["CoefX"];
                coefXColumn.Width = patternWidth;
                DataGridViewColumn coefP2Column = DGV.Columns["CoefP2"];
                coefP2Column.Width = patternWidth;
                BindSortingEventToATableHeader(DGV);
            }
            catch
            {
                MessageBox.Show("The Number of Columns is less then requested in DGV Table or cell type missmatch has occured");
                throw;
            }
        }
    }
}
