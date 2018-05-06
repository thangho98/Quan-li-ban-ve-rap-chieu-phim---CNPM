using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DAO
{
    public class ShowTimesDAO
    {
        public static DataTable GetListShowTimeByFormatMovie(string formatMovieID, DateTime date)
        {
            string query = "USP_GetListShowTimeByFormatMovie @ID , @Date";
            return DataProvider.ExecuteQuery(query, new object[] { formatMovieID, date });
        }
    }
}
