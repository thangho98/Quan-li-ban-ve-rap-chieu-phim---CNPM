using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DAO
{
	public class RevenueDAO
	{
		public static DataTable GetRevenue(string idMovie, DateTime fromDate, DateTime toDate)
		{
			return DataProvider.ExecuteQuery("EXEC USP_GetRevenueByMovieAndDate @idMovie , @fromDate , @toDate", new object[] { idMovie, fromDate, toDate });
		}
	}
}
