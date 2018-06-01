using GUI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DAO
{
    public class AccountDAO
    {
        private AccountDAO() { }

        public static bool Login(string userName, string passWord)
        {
			string query = "USP_Login @userName , @passWord";
			DataTable result = DataProvider.ExecuteQuery(query, new object[] { userName, passWord  /*list*/});

            return result.Rows.Count > 0;
        }

        public static bool UpdateAccountPassword(string username, string pass, string newPass)
        {
            int result = DataProvider.ExecuteNonQuery("EXEC USP_UpdateAccount @username , @pass , @newPass", new object[] { username, pass, newPass });

            return result > 0;
        }

        public static Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.ExecuteQuery("Select * from TaiKhoan where userName = '" + userName + "'");

            foreach (DataRow row in data.Rows)
            {
                return new Account(row);
            }

            return null;
        }

		public static void DeleteAccountByIdStaff(string idStaff)
		{
			DataProvider.ExecuteQuery("DELETE dbo.TaiKhoan WHERE idNV = '" + idStaff + "'");
		}
    }
}
