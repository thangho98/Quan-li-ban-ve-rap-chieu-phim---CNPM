using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DTO
{
    public class Promotion//Chế độ khuyến mãi
    {
        Promotion(string iD, string name, string desc, DateTime starTime,
            DateTime endTime, int point, float rates)
        {
            this.ID = iD;
            this.Name = name;
            this.Desc = desc;
            this.StarTime = starTime;
            this.EndTime = endTime;
            this.Point = point;
            this.Rates = rates;
        }

        Promotion(DataRow row)
        {
            this.ID = row["id"].ToString();
            this.Name = row["TenKM"].ToString();
            this.Desc = row["MoTa"].ToString();
            this.StarTime = (DateTime)row["NgayBatDau"];
            this.EndTime = (DateTime)row["NgayKetThuc"];
            this.Point = (int)row["DiemTichLuy"];
            this.Rates = (float)row["TiSuatKM"];
        }

        public string ID { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public DateTime StarTime { get; set; }

        public DateTime EndTime { get; set; }

        public int Point { get; set; }

        public float Rates { get; set; }
    }
}
