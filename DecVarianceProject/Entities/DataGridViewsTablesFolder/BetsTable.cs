﻿using System;
using System.Data;
using System.Windows.Forms;
using DecVarianceProject.Properties;

namespace DecVarianceProject.Entities.DataGridViewsTablesFolder
{
    [Serializable]
    public class BetsTable:DataGridViewsRepository
    {
        public override void ConfigureDgv()
        {
            try
            {
                var table = new DataTable();
                table.Columns.Add("BetNum").DataType = typeof(int);
                table.Columns.Add("BetSize").DataType = typeof(int);
                table.Columns.Add("Coef").DataType = typeof(double);
                table.Columns.Add("MatchResults").DataType = typeof(string);
                Dgv.DataSource = FillInTheTable(table, ListContent);
                Dgv.ReadOnly = true;
                var betNumColumn = Dgv.Columns["BetNum"];
                betNumColumn.Width = 50;
                var betSizeColumn = Dgv.Columns["BetSize"];
                betSizeColumn.Width = 60;
                var coefColumn = Dgv.Columns["Coef"];
                coefColumn.Width = 70;
                var chosenMatchesResultsColumn = Dgv.Columns["MatchResults"];
                chosenMatchesResultsColumn.Width = Dgv.Width - (betSizeColumn.Width + coefColumn.Width + betNumColumn.Width);

                BindSortingEventToATableHeader(Dgv);
            }
            catch
            {
                MessageBox.Show(Resources.Bets_ConfigureDGV_The_Number_of_Columns_is_less_then_requested_in_DGV_Table__or_cell_type_missmatch_has_occured);
                throw;
            }
        }
    }
}
