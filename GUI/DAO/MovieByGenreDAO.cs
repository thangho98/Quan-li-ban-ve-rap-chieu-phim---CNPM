using GUI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GUI.DAO
{
    public class MovieByGenreDAO
    {
        public static List<Genre> GetListGenreByMovieID(string id)
        {
            List<Genre> genreList = new List<Genre>();
            DataTable data = DataProvider.ExecuteQuery("EXEC USP_GetListGenreByMovie @idPhim", new object[] { id });
            foreach (DataRow item in data.Rows)
            {
                Genre genre = new Genre(item);
                genreList.Add(genre);
            }
            return genreList;
        }

        public static void InsertMovie_Genre(string movieID, List<Genre> genreList)
        {
            foreach (Genre item in genreList)
            {
                string command = string.Format("INSERT dbo.PhanLoaiPhim (idPhim, idTheLoai) VALUES  ('{0}','{1}')", movieID, item.ID);
                DataProvider.ExecuteNonQuery(command);
            }
        }

        public static void UpdateMovie_Genre(string movieID, List<Genre> genreList)
        //Idea : Delete all rows that contain movieID, then re-add all genre that have been chosen from CheckedListBox to 'PhanLoaiPhim' with movieID
        {
            DataProvider.ExecuteNonQuery("DELETE dbo.PhanLoaiPhim WHERE idPhim = '" + movieID + "'");
            foreach (Genre item in genreList)
            {
                string command = string.Format("INSERT dbo.PhanLoaiPhim (idPhim, idTheLoai) VALUES  ('{0}','{1}')", movieID, item.ID);
                DataProvider.ExecuteNonQuery(command);
            }
        }

        public static void DeleteMovie_GenreByMovieID(string movieID)
        {
            DataProvider.ExecuteNonQuery("DELETE dbo.PhanLoaiPhim WHERE idPhim = '" + movieID + "'");
        }
    }
}
