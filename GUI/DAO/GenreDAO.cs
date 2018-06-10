using GUI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GUI.DAO
{
    public class GenreDAO
    {
        public static List<Genre> GetListGenre()
        {
            List<Genre> genreList = new List<Genre>();
            DataTable data = DataProvider.ExecuteQuery("SELECT * FROM dbo.TheLoai");
            foreach (DataRow item in data.Rows)
            {
                Genre genre = new Genre(item);
                genreList.Add(genre);
            }
            return genreList;
        }

        public static DataTable GetGenre()
        {
            return DataProvider.ExecuteQuery("SELECT id AS [Mã thể loại], TenTheLoai AS [Tên thể loại], MoTa AS [Mô tả] FROM dbo.TheLoai");
        }

        public static bool InsertGenre(string id, string name, string desc)
        {
            int result = DataProvider.ExecuteNonQuery("EXEC USP_InsertGenre @idGenre , @ten , @moTa ", new object[] { id, name, desc });
            return result > 0;
        }

        public static bool UpdateGenre(string id, string name, string desc)
        {
            string command = string.Format("UPDATE dbo.TheLoai SET TenTheLoai = N'{0}', MoTa = N'{1}' WHERE id = '{2}'", name, desc, id);
            int result = DataProvider.ExecuteNonQuery(command);
            return result > 0;
        }

        public static bool DeleteGenre(string id)
        {
			DataProvider.ExecuteNonQuery("DELETE dbo.PhanLoaiPhim WHERE idTheLoai = '" + id + "'");

			int result = DataProvider.ExecuteNonQuery("DELETE dbo.TheLoai WHERE id = '" + id + "'");
            return result > 0;
        }
    }
}
