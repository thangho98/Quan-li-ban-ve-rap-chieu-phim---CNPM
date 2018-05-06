using GUI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DAO
{
    public class FormatMovieDAO
    {
        public static List<FormatMovie> GetListFormatMovieByMovie(string movieID)
        {
            List<FormatMovie> listFormat = new List<FormatMovie>();
            string query = "select d.id, p.TenPhim, m.TenMH " +
                "from Phim p, DinhDangPhim d, LoaiManHinh m " +
                "where p.id = d.idPhim and d.idLoaiManHinh = m.id "
                + "and p.id = '" + movieID + "'";
            DataTable data =  DataProvider.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                FormatMovie format = new FormatMovie(row);
                listFormat.Add(format);
            }
            return listFormat;
        }

        public static DataTable GetFormatMovie(string movieID, string screenTypeID)
        {
            string query = "select d.id, p.TenPhim, m.TenMH " +
                "from Phim p, DinhDangPhim d, LoaiManHinh m " +
                "where p.id = d.idPhim and d.idLoaiManHinh = m.id "
                + "and p.id = '" + movieID + "' and m.id = '" + screenTypeID + "'";
            return DataProvider.ExecuteQuery(query);
        }
    }
}
