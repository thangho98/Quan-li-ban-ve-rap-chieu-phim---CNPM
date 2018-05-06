using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DAO
{
    public class ShowTimesDAO
    {
        public static DataTable GetListShowTimeByFormatMovie(string formatMovieID)
        {
            string query = "select l.id, pc.TenPhong, p.TenPhim, l.ThoiGianChieu, d.id as idDinhDang, l.GiaVe "
                    + "from Phim p ,DinhDangPhim d, LichChieu l, PhongChieu pc "
                    + "where p.id = d.idPhim and d.id = l.idDinhDang and l.idPhong = pc.id "
                    + "and d.id = '" + formatMovieID + "' "
                    + "order by l.ThoiGianChieu";
            return DataProvider.ExecuteQuery(query);
        }
    }
}
