using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DTO
{
    public class ShowTimes
    {
        ShowTimes(string iD, DateTime time, string cinemaID, string FilmID)
        {
            this.ID = iD;
            this.Time = time;
            this.CinemaID = cinemaID;
            this.FilmID = FilmID;
        }

        ShowTimes(DataRow row)
        {
            this.ID = row["id"].ToString();
            this.Time = (DateTime)row["ThoiGianChieu"];
            this.CinemaID = row["idPhong"].ToString();
            this.FilmID = row["idPhim"].ToString();
        }

        public string ID { get; set; }

        public DateTime Time { get; set; }

        public string CinemaID { get; set; }

        public string FilmID { get; set; }
    }
}
