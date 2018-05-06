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
    }
}
