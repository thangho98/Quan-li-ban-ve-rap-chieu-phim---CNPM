﻿using GUI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GUI.DAO
{
    public class ShowTimesDAO
    {
        public static DataTable GetListShowTimeByFormatMovie(string formatMovieID, DateTime date)
        {
            string query = "USP_GetListShowTimesByFormatMovie @ID , @Date";
            return DataProvider.ExecuteQuery(query, new object[] { formatMovieID, date });
        }
        public static List<ShowTimes> GetAllListShowTimes()
        {
            List<ShowTimes> listShowTimes = new List<ShowTimes>();
            DataTable data = DataProvider.ExecuteQuery("USP_GetAllListShowTimes");
            foreach (DataRow row in data.Rows)
            {
                ShowTimes showTimes = new ShowTimes(row);
                listShowTimes.Add(showTimes);
            }
            return listShowTimes;
        }
        public static int UpdateStatusShowTimes(string showTimesID, int status)
        {
            string query = "USP_UpdateStatusShowTimes @idLichChieu , @status";
            return DataProvider.ExecuteNonQuery(query, new object[] { showTimesID, status });
        }

		public static DataTable GetListShowtime()
		{
			return DataProvider.ExecuteQuery("EXEC USP_GetShowtime");
		}

		public static bool InsertShowtime(string id, string cinemaID, string formatMovieID, DateTime time, float ticketPrice)
		{
			int result = DataProvider.ExecuteNonQuery("EXEC USP_InsertShowtime @id , @idPhong , @idDinhDang , @thoiGianChieu , @giaVe ", new object[] { id, cinemaID, formatMovieID, time, ticketPrice });
			return result > 0;
		}

		public static bool UpdateShowtime(string id, string cinemaID, string formatMovieID, DateTime time, float ticketPrice)
		{
			string command = string.Format("UPDATE dbo.LichChieu SET idPhong = '{0}', idDinhDang = '{1}', ThoiGianChieu = '{2}', GiaVe = {3} WHERE id = '{4}'", cinemaID, formatMovieID, time, ticketPrice, id);
			int result = DataProvider.ExecuteNonQuery(command);
			return result > 0;
		}

		public static bool DeleteShowtime(string id)
		{
			//TODO : Xóa vé trước
			int result = DataProvider.ExecuteNonQuery("DELETE dbo.LichChieu WHERE id = '" + id + "'");
			return result > 0;
		}

		public static DataTable SearchShowtimeByMovieName(string movieName)
		{
			DataTable data = DataProvider.ExecuteQuery("EXEC USP_SearchShowtimeByMovieName @tenPhim ", new object[] { movieName });
			return data;
		}
	}
}
