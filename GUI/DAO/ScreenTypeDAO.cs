using GUI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GUI.DAO
{
    public class ScreenTypeDAO
    {
        public static List<ScreenType> GetListScreenType()
        {
            List<ScreenType> screenTypeList = new List<ScreenType>();
            DataTable data = DataProvider.ExecuteQuery("SELECT * FROM dbo.LoaiManHinh");
            foreach (DataRow item in data.Rows)
            {
                ScreenType screenType = new ScreenType(item);
                screenTypeList.Add(screenType);
            }
            return screenTypeList;
        }

        public static DataTable GetScreenType()
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
			DataProvider.ExecuteNonQuery("DELETE dbo.PhongChieu WHERE idManHinh = '" + id + "'");
			DataProvider.ExecuteNonQuery("DELETE dbo.DinhDangPhim WHERE idLoaiManHinh = '" + id + "'");

			int result = DataProvider.ExecuteNonQuery("DELETE dbo.LoaiManHinh WHERE id = '" + id + "'");
            return result > 0;
        }

        public static ScreenType GetScreenTypeByName(string screenName)
        {
            ScreenType screenType = null;
            DataTable data = DataProvider.ExecuteQuery("SELECT * FROM dbo.LoaiManHinh WHERE TenMH = N'" + screenName + "'");
            foreach (DataRow item in data.Rows)
            {
                screenType = new ScreenType(item);
                return screenType;
            }
            return screenType;
        }
    }
}
