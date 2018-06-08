using System;
using System.Data;
using System.Linq;

namespace GUI.DTO
{
    public class Movie
    {

        public Movie(string iD, string name, string desc, float time
            , DateTime starDate, DateTime endDate, string country
            , string director, int yearProduction, byte[] poster)
        {
            this.ID = iD;
            this.Name = name;
            this.Desc = desc;
            this.Time = time;
            this.StartDate = starDate;
            this.EndDate = endDate;
            this.Country = country;
            this.Director = director;
            this.YearProduction = yearProduction;
            this.Poster = poster;
        }

        public Movie(DataRow row)
        {
            this.ID = row["id"].ToString();
            this.Name = row["TenPhim"].ToString();
            this.Desc = row["MoTa"].ToString();
            this.Time = float.Parse(row["ThoiLuong"].ToString());
            this.StartDate = (DateTime)row["NgayKhoiChieu"];
            this.EndDate = (DateTime)row["NgayKetThuc"];
            this.Country = row["SanXuat"].ToString();
            this.Director = row["DaoDien"].ToString();
            this.YearProduction = (int)row["NamSX"];
            if (row["ApPhich"].ToString() == "")
                this.Poster = null;
            else
                this.Poster = (byte[])row["ApPhich"];
        }

        public string ID { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public float Time { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Country { get; set; }

        public int YearProduction { get; set; }

        public string Director { get; set; }

        public byte[] Poster { get; set; }
    }
}
