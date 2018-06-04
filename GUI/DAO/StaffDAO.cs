using GUI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DAO
{
    public class StaffDAO
    {
        public static DataTable GetListStaff()
        {
            return DataProvider.ExecuteQuery("EXEC USP_GetStaff");
        }

        public static bool InsertStaff(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, int cmnd)
        {
            int result = DataProvider.ExecuteNonQuery("EXEC USP_InsertStaff @idStaff , @hoTen , @ngaySinh , @diaChi , @sdt , @cmnd ", new object[] {id, hoTen, ngaySinh, diaChi, sdt, cmnd});
            return result > 0;
        }

		public static bool UpdateStaff(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, int cmnd)
		{
			string command = string.Format("UPDATE dbo.NhanVien SET HoTen = N'{0}', NgaySinh = '{1}', DiaChi = N'{2}', SDT = '{3}', CMND = {4} WHERE id = '{5}'", hoTen, ngaySinh, diaChi, sdt, cmnd, id);
			int result = DataProvider.ExecuteNonQuery(command);
			return result > 0;
		}

		public static bool DeleteStaff(string id)
		{
			AccountDAO.DeleteAccountByIdStaff(id);
			int result = DataProvider.ExecuteNonQuery("DELETE dbo.NhanVien WHERE id = '" + id + "'");
			return result > 0;
		}

		public static DataTable SearchStaffByName(string name)
		{
			//List<Staff> searchList = new List<Staff>();
			//DataTable data = DataProvider.ExecuteQuery("SELECT * FROM dbo.NhanVien WHERE HoTen = N'" + name + "'");
			DataTable data = DataProvider.ExecuteQuery("EXEC USP_SearchStaff @hoTen", new object[] { name });
			//foreach (DataRow item in data.Rows)
			//{
			//	Staff staff = new Staff(item);
			//	searchList.Add(staff);
			//}
			return data;
			//TODO : Giải quyết trường hợp đang được comment
		}
	}
}