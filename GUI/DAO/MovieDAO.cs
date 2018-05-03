using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DAO
{
    public class MovieDAO
    {
        public static DataTable GetListMovie(DateTime date)
        {
            return DataProvider.ExecuteQuery("select * from Phim where @Date <= NgayKetThuc",new object[] { date });
        }
    }
}
