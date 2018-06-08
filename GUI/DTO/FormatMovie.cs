using System;
using System.Data;
using System.Linq;

namespace GUI.DTO
{
    public class FormatMovie
    {
        public FormatMovie(string iD, string movieID, string screenTypeID)
        {
            this.ID = iD;
            this.MovieName = movieID;
            this.ScreenTypeName = screenTypeID;
        }

        public FormatMovie(DataRow row)
        {
            this.ID = row["id"].ToString();
            this.MovieName = row["TenPhim"].ToString();
            this.ScreenTypeName = row["TenMH"].ToString();
        }

        public string ID { get; set; }

        public string MovieName { get; set; }

        public string ScreenTypeName { get; set; }
    }
}
