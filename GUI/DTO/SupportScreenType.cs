using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DTO
{
    public class SupportScreenType
    {
        public SupportScreenType(string movieID, string screenType)
        {
            this.MovieID = movieID;
            this.ScreenType = screenType;
        }

        public SupportScreenType(DataRow row)
        {
            this.MovieID = row["idPhim"].ToString();
            this.ScreenType = row["idLoaiManHinh"].ToString();
        }

        public string MovieID { get; set; }

        public string ScreenType { get; set; }
    }
}
