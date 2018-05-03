using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DAO
{
    public class TicketDAO
    {
        public static DataTable GetListTicketByShowTimes(string showTimesID)
        {
            string query = "select * from Ve where idLichChieu = '" + showTimesID + "'";
            return DataProvider.ExecuteQuery(query);
        }
    }
}
