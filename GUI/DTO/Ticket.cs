using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DTO
{
    public class Ticket
    {
        public Ticket(string iD, int type, string showTimesID, string seatName
            ,int typeSeat, string customerID, string promotionID, float price,
            int status)
        {
            this.ID = iD;
            this.Type = type;
            this.ShowTimesID = showTimesID;
            this.SeatName = seatName;
            this.TypeSeat = TypeSeat;
            this.CustomerID = customerID;
            this.PromotionID = promotionID;
            this.Price = price;
            this.Status = status;
        }

        public Ticket(DataRow row)
        {
            this.ID = row["id"].ToString();
            this.Type = (int)row["LoaiVe"];
            this.ShowTimesID = row["idLichChieu"].ToString();
            this.SeatName = row["MaGheNgoi"].ToString();
            this.TypeSeat = (int)row["LoaiGheNgoi"];
            this.CustomerID = row["idKhachHang"].ToString();
            this.PromotionID = row["idCheDoKM"].ToString();
            if (row["GiaVe"].ToString() == "")
                this.Price = 0;
            else
                this.Price = float.Parse(row["GiaVe"].ToString());
            this.Status =(int)row["TrangThai"];
        }

        public string ID { get; set; }

        public int Type { get; set; }

        public string ShowTimesID { get; set; }

        public string SeatName { get; set; }

        public int TypeSeat { get; set; }

        public string CustomerID { get; set; }

        public string PromotionID { get; set; }

        public float Price { get; set; }

        public int Status { get; set; }
    }
}
