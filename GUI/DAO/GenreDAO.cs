using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DAO
{
    public class GenreDAO
    {
        public static DataTable GetListGenre()
        {
            return DataProvider.ExecuteQuery("SELECT id , TenTheLoai FROM dbo.TheLoai");
        }
    }
}
