using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DAO
{
    public class ScreenTypeDAO
    {
        public static DataTable GetListScreenType()
        {
            return DataProvider.ExecuteQuery("SELECT id , TenMH FROM dbo.LoaiManHinh");
        }
    }
}
