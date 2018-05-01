using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DTO
{
    public class Movie
    {

        public Movie(string iD, string name, float time, string director)
        {
            this.ID = iD;
            this.Name = name;
            this.Time = time;
            this.Director = director;
        }

        public Movie(DataRow row)
        {
            this.ID = row["id"].ToString();
            this.Name = row["TenPhim"].ToString();
            this.Time = (float)row["ThoiLuong"];
            this.Director = row["DaoDien"].ToString();
        }

        public string ID { get; set; }

        public string Name { get; set; }
        
        public float Time { get; set; }

        public string Director { get; set; }
    }
}
