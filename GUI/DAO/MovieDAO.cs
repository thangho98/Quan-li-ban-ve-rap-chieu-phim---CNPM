using GUI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;

namespace GUI.DAO
{
    public class MovieDAO
    {
        //ảnh -> byte[]
        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        //byte[] -> ảnh
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static List<Movie> GetListMovieByDate(DateTime date)
        {
            List<Movie> listMovie = new List<Movie>();
            DataTable data = DataProvider.ExecuteQuery("select * from Phim where @Date <= NgayKetThuc", new object[] { date });
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

        public static bool InsertMovie(string id, string name, string desc, float length, DateTime startDate, DateTime endDate, string productor, string director, int year, byte[] image)
        {
            int result = DataProvider.ExecuteNonQuery("EXEC USP_InsertMovie @id , @tenPhim , @moTa , @thoiLuong , @ngayKhoiChieu , @ngayKetThuc , @sanXuat , @daoDien , @namSX , @apPhich ", new object[] { id, name, desc, length, startDate, endDate, productor, director, year, image});
            return result > 0;
        }

        public static bool UpdateMovie(string id, string name, string desc, float length, DateTime startDate, DateTime endDate, string productor, string director, int year, byte[] image)
        {
            int result = DataProvider.ExecuteNonQuery("EXEC USP_UpdateMovie @id , @tenPhim , @moTa , @thoiLuong , @ngayKhoiChieu , @ngayKetThuc , @sanXuat , @daoDien , @namSX , @apPhich ", new object[] { id, name, desc, length, startDate, endDate, productor, director, year, image });
            return result > 0;
        }

        public static bool DeleteMovie(string id)
        {
			DataProvider.ExecuteNonQuery("DELETE dbo.PhanLoaiPhim WHERE idPhim = '" + id + "'");
			DataProvider.ExecuteNonQuery("DELETE dbo.DinhDangPhim WHERE idPhim = '" + id + "'");

			MovieByGenreDAO.DeleteMovie_GenreByMovieID(id);
            int result = DataProvider.ExecuteNonQuery("DELETE dbo.Phim WHERE id = '" + id + "'");
            return result > 0;
        }

        public static Movie GetMovieByID(string id)
        {
            Movie movie = null;
            DataTable data = DataProvider.ExecuteQuery("SELECT * FROM dbo.Phim WHERE id = '" + id + "'");
            foreach (DataRow item in data.Rows)
            {
                movie = new Movie(item);
                return movie;
            }
            return movie;
        }
    }
}
