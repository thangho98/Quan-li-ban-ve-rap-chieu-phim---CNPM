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
        public ShowTimes(string iD, DateTime time, string cinemaName, 
            string formatMovieID, string movieName, float ticketPrice)
        {
            this.ID = iD;
            this.CinemaName = cinemaName;
            this.MovieName = movieName;
            this.Time = time;
            this.FormatMovieID = formatMovieID;
            this.TicketPrice = ticketPrice;
        }

        public ShowTimes(DataRow row)
        {
            this.ID = row["id"].ToString();
            this.CinemaName = row["TenPhong"].ToString();
            this.MovieName = row["TenPhim"].ToString();
            this.Time = (DateTime)row["ThoiGianChieu"];
            this.FormatMovieID = row["idDinhDang"].ToString();
            if (row["GiaVe"].ToString() == "")
                this.TicketPrice = 0;
            else
                this.TicketPrice = float.Parse(row["GiaVe"].ToString());
        }

        public string ID { get; set; }

        public DateTime Time { get; set; }

        public string CinemaName { get; set; }

        public string FormatMovieID { get; set; }

        public string MovieName { get; set; }

        public float TicketPrice { get; set; }
    }
}
