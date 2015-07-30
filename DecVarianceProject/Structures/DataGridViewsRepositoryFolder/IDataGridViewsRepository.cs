using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecVarianceProject
{
    interface IDataGridViewRepository
    {
        void ConfigureDGV();
        DataTable FillInTheTable(DataTable table, List<TablesContent> list);
        void BindSortingEventToATableHeader(DataGridView dgv);
    }
}
