using GUI.DTO;
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
        public static Cinema GetCinema(string cinemaName)
        {
            string query = "select * from dbo.PhongChieu where TenPhong = '" + cinemaName + "'";
            DataTable data = DataProvider.ExecuteQuery(query);
            return new Cinema(data.Rows[0]);
        }
    }
}
