using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DAO
{
    public class ScreenTypeDAO
    {
        public static DataTable GetListScreenType()
        {
            return DataProvider.ExecuteQuery("SELECT id AS [Mã loại màn hình], TenMH as [Tên màn hình] FROM dbo.LoaiManHinh");
        }

        public static DataTable GetScreenTypeByFormatFilm(string screenTypeID)
        {
            return DataProvider.ExecuteQuery("SELECT *  FROM dbo.LoaiManHinh where id = '" + screenTypeID + "'");
        }

		public static bool InsertScreenType(string id, string name)
		{
			int result = DataProvider.ExecuteNonQuery("EXEC USP_InsertScreenType @idScreenType , @ten", new object[] { id, name });
			return result > 0;
		}

		public static bool UpdateScreenType(string id, string name)
		{
			string command = string.Format("UPDATE dbo.LoaiManHinh SET TenMH = N'{0}' WHERE id = '{1}'", name, id);
			int result = DataProvider.ExecuteNonQuery(command);
			return result > 0;
		}

		public static bool DeleteScreenType(string id)
		{
			int result = DataProvider.ExecuteNonQuery("DELETE dbo.LoaiManHinh WHERE id = '" + id + "'");
			return result > 0;
		}
    }
}
