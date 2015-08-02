using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DecVarianceProject.Structures.Tables;

namespace DecVarianceProject.Structures.DataGridViewsRepositoryFolder
{
    interface IDataGridViewRepository
    {
        void ConfigureDgv();
        DataTable FillInTheTable(DataTable table, List<ITablesContent> list);
        void BindSortingEventToATableHeader(DataGridView dgv);
    }
}
