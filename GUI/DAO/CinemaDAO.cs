using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DAO
{
    public class CinemaDAO
    {
        public static DataTable GetCinema(string cinemaName)
        {
            string query = "select * from dbo.PhongChieu where TenPhong = '" + cinemaName + "'";
            return DataProvider.ExecuteQuery(query);
        }
    }
}
