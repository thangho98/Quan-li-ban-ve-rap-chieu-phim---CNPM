﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DTO
{
    public class Ticket
    {
        public Ticket(string iD, int type, string showTimesID, int seat, string customerID, 
            string promotionID, float price, string status)
        {
            this.ID = iD;
            this.Type = type;
            this.ShowTimesID = showTimesID;
            this.Seat = seat;
            this.CustomerID = customerID;
            this.PromotionID = promotionID;
            this.Price = price;
            this.Status = status;
        }

        public Ticket(DataRow row)
        {
            this.ID = row["id"].ToString();
            this.Type = (int)row["LoaiVe"];
            this.ShowTimesID = row["idSuatChieu"].ToString();
            this.Seat = (int)row["GheNgoi"];
            this.CustomerID = row["idKhachHang"].ToString();
            this.PromotionID = row["idCheDoKM"].ToString();
            this.Price = (float)row["GiaVe"];
            this.Status =row["TrangThai"].ToString();
        }

        public string ID { get; set; }

        public int Type { get; set; }

        public string ShowTimesID { get; set; }

        public int Seat { get; set; }

        public string CustomerID { get; set; }

        public string PromotionID { get; set; }

        public float Price { get; set; }

        public string Status { get; set; }
    }
}
