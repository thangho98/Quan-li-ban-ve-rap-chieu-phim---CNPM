using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DTO
{
    public class Cinema
    {
        Cinema(string iD, string name, string screenType, int seats,
            float area, string status)
        {
            this.ID = iD;
            this.Name = name;
            this.ScreenTypeID = screenType;
            this.Seats = seats;
            this.Area = area;
            this.Status = status;
        }

        Cinema(DataRow row)
        {
            this.ID = row["id"].ToString();
            this.Name = row["TenPhong"].ToString();
            this.ScreenTypeID = row["idManHinh"].ToString();
            this.Seats = (int)row["SoChoNgoi"];
            this.Area = (float)row["DienTich"];
            this.Status = row["TinhTrang"].ToString();
        }

        public string ID { get; set; }

        public string Name { get; set; }

        public string ScreenTypeID { get; set; }

        public int Seats { get; set; }

        public float Area { get; set; }

        public string Status { get; set; }
    }
}
