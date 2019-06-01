using System;
using System.Data;
using System.Linq;

namespace GUI.DTO
{
    public class ShowTimes
    {
        public ShowTimes(string iD, DateTime time, string cinemaName,
            string formatMovieID, string movieName, float ticketPrice, int status)
        {
            this.ID = iD;
            this.CinemaName = cinemaName;
            this.MovieName = movieName;
            this.Time = time;
            this.FormatMovieID = formatMovieID;
            this.TicketPrice = ticketPrice;
            this.Status = status;
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
            this.Status = (int)row["TrangThai"];
        }

        public string ID { get; set; }

        public DateTime Time { get; set; }

        public string CinemaName { get; set; }

        public string FormatMovieID { get; set; }

        public string MovieName { get; set; }

        public float TicketPrice { get; set; }

        public int Status { get; set; }

        //public override string ToString()
        //{
        //    return MovieName + " " + CinemaName + " " + Time.ToString("HH:mm:ss dd/MM/yyyy");
        //}
    }
}
