using GUI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GUI.DAO
{
    public class CinemaDAO
    {
        public static Cinema GetCinemaByName(string cinemaName)
        {
            string query = "select * from dbo.PhongChieu where TenPhong = '" + cinemaName + "'";
            DataTable data = DataProvider.ExecuteQuery(query);
            return new Cinema(data.Rows[0]);
        }

		public static Cinema GetCinemaByID(string id)
		{
			string query = "select * from dbo.PhongChieu where id = '" + id + "'";
			DataTable data = DataProvider.ExecuteQuery(query);
			if (data.Rows.Count>0)
				return new Cinema(data.Rows[0]);
			return null;
		}

		public static List<Cinema> GetCinemaByScreenTypeID(string screenTypeID)
		{
			List<Cinema> cinemaList = new List<Cinema>();
            DataTable data = DataProvider.ExecuteQuery("SELECT * FROM dbo.PhongChieu where idManHinh ='" + screenTypeID + "'");
			foreach (DataRow item in data.Rows)
			{
				Cinema cinema = new Cinema(item);
				cinemaList.Add(cinema);
			}
			return cinemaList;
		}

        public static DataTable GetListCinema()
        {
            return DataProvider.ExecuteQuery("EXEC USP_GetCinema");
        }

        public static bool InsertCinema(string id, string name, string idMH, int seats, int status, int numberOfRows, int seatsPerRow)
        {
            int result = DataProvider.ExecuteNonQuery("EXEC USP_InsertCinema @idCinema , @tenPhong , @idMH , @soChoNgoi , @tinhTrang , @soHangGhe , @soGheMotHang", new object[] { id, name, idMH, seats, status, numberOfRows, seatsPerRow });
            return result > 0;
        }

        public static bool UpdateCinema(string id, string name, string idMH, int seats, int status, int numberOfRows, int seatsPerRow)
        {
            string command = string.Format("UPDATE dbo.PhongChieu SET TenPhong = N'{0}', idManHinh = '{1}', SoChoNgoi = {2}, TinhTrang = {3}, SoHangGhe = {4}, SoGheMotHang = {5} WHERE id = '{6}'", name, idMH, seats, status, numberOfRows, seatsPerRow, id);
            int result = DataProvider.ExecuteNonQuery(command);
            return result > 0;
        }

        public static bool DeleteCinema(string id)
        {
			DataProvider.ExecuteNonQuery("DELETE dbo.LichChieu WHERE idPhong = '" + id + "'");

            int result = DataProvider.ExecuteNonQuery("DELETE dbo.PhongChieu WHERE id = '" + id + "'");
            return result > 0;
        }
    }
}
