using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DecVarianceProject.Entities.TablesContents;

namespace DecVarianceProject.Entities.DataGridViewsTablesFolder
{
    interface IDataGridViewRepository
    {
        void ConfigureDgv();
        DataTable FillInTheTable(DataTable table, List<ITablesContent> list);
        void BindSortingEventToATableHeader(DataGridView dgv);
    }
}
