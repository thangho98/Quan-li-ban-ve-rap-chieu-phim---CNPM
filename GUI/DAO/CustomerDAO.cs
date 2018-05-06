using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DAO
{
    public class CustomerDAO
    {
        public static DataTable GetCustomerMember(string customerID, string name)
        {
            string query = "Select * from KhachHang where id = '" + customerID + "' and HoTen = N'" + name + "'";
            return DataProvider.ExecuteQuery(query);
        }
    }
}
