using GUI.DTO;
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
        public static List<Movie> GetListMovieByDate(DateTime date)
        {
            List<Movie> listMovie = new List<Movie>();
            DataTable data = DataProvider.ExecuteQuery("select * from Phim where @Date <= NgayKetThuc",new object[] { date });
            foreach (DataRow row in data.Rows)
            {
                Movie movie = new Movie(row);
                listMovie.Add(movie);
            }
            return listMovie;
        }

		public static List<Movie> GetListMovie()
		{
			List<Movie> listMovie = new List<Movie>();
			DataTable data = DataProvider.ExecuteQuery("SELECT * FROM Phim");
			foreach (DataRow row in data.Rows)
			{
				Movie movie = new Movie(row);
				listMovie.Add(movie);
			}
			return listMovie;
		}

		public static DataTable GetMovie()
		{
			return DataProvider.ExecuteQuery("EXEC USP_GetMovie");
		}

		public static bool InsertMovie(string id, string name, string desc, float length, DateTime startDate, DateTime endDate, string productor, string director, int year)
		{
			int result = DataProvider.ExecuteNonQuery("EXEC USP_InsertMovie @id , @tenPhim , @moTa , @thoiLuong , @ngayKhoiChieu , @ngayKetThuc , @sanXuat , @daoDien , @namSX ", new object[] { id, name, desc, length, startDate, endDate, productor, director, year });
			return result > 0;
		}

		public static bool UpdateMovie(string id, string name, string desc, float length, DateTime startDate, DateTime endDate, string productor, string director, int year)
		{
			int result = DataProvider.ExecuteNonQuery("EXEC USP_UpdateMovie @id , @tenPhim , @moTa , @thoiLuong , @ngayKhoiChieu , @ngayKetThuc , @sanXuat , @daoDien , @namSX ", new object[] { id, name, desc, length, startDate, endDate, productor, director, year });
			return result > 0;
		}

		public static bool DeleteMovie(string id)
		{
			MovieByGenreDAO.DeleteMovie_GenreByMovieID(id);
			int result = DataProvider.ExecuteNonQuery("DELETE dbo.Phim WHERE id = '" + id + "'");
			return result > 0;
		}
	}
}
