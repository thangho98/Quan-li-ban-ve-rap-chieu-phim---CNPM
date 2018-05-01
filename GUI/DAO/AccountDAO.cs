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
            //byte[] temp = ASCIIEncoding.ASCII.GetBytes(passWord);
            //byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

            //string hasPass = "";

            //foreach (byte item in hasData)
            //{
            //    hasPass += item;
            //}
            //var list = hasData.ToString();
            //list.Reverse();

            string query = "USP_Login @userName , @passWord";

            //DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, hasPass /*list*/});

            DataTable result = DataProvider.ExecuteQuery(query, new object[] { userName, passWord  /*list*/});

            return result.Rows.Count > 0;
        }

        public static bool UpdateAccount(string userName, string displayName, string pass, string newPass)
        {
            int result = DataProvider.ExecuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @password , @newPassword", new object[] { userName, displayName, pass, newPass });

            return result > 0;
        }

        public static DataTable GetListAccount()
        {
            return DataProvider.ExecuteQuery("SELECT UserName, DisplayName, Type FROM dbo.Account");
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

        public static bool InsertAccount(string name, string displayName, int type)
        {
            string query = string.Format("INSERT dbo.Account ( UserName, DisplayName, Type, password )VALUES  ( N'{0}', N'{1}', {2}, N'{3}')", name, displayName, type, "1962026656160185351301320480154111117132155");
            int result = DataProvider.ExecuteNonQuery(query);

            return result > 0;
        }

        public static bool UpdateAccount(string name, string displayName, int type)
        {
            string query = string.Format("UPDATE dbo.Account SET DisplayName = N'{1}', Type = {2} WHERE UserName = N'{0}'", name, displayName, type);
            int result = DataProvider.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteAccount(string name)
        {
            string query = string.Format("Delete Account where UserName = N'{0}'", name);
            int result = DataProvider.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool ResetPassword(string name)
        {
            string query = string.Format("update account set password = N'1962026656160185351301320480154111117132155' where UserName = N'{0}'", name);
            int result = DataProvider.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
