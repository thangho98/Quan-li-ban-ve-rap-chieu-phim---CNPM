using GUI.DAO;
using GUI.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;//thư viện thay đổi vùng/quốc gia

namespace GUI
{
    public partial class frmTheatre : Form
    {
        int SIZE = 30;
        List<Ticket> list = new List<Ticket>();

        float originalFare = 0;
        float total = 0;
        float discount = 0;
        float payment = 0;

        public frmTheatre(ShowTimes showTimes, Movie movie)
        {
            InitializeComponent();

            lblInformation.Text = "CGV Hung Vuong | " + showTimes.CinemaName + " | " + showTimes.MovieName;
            lblTime.Text = showTimes.Time.ToShortDateString() + " | "
                + showTimes.Time.ToShortTimeString() + " - "
                + showTimes.Time.AddMinutes(movie.Time).ToShortTimeString();

            DataTable data = TicketDAO.GetListTicketByShowTimes(showTimes.ID);
            foreach(DataRow row in data.Rows)
            {
                Ticket ticket = new Ticket(row);
                list.Add(ticket);
            }
            LoadSeats(list);
        }

        private void LoadBill()
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            //Đổi culture vùng quốc gia để đổi đơn vị tiền tệ 

            //Thread.CurrentThread.CurrentCulture = culture;
            //dùng thread để chuyển cả luồng đang chạy về vùng quốc gia đó

            lblOrignalFare.Text = originalFare.ToString("c", culture);
            lblTotal.Text = total.ToString("c", culture);
            lblDiscount.Text = discount.ToString("c", culture);
            lblPayment.Text = payment.ToString("c", culture);
            //Đổi đơn vị tiền tệ
            //gán culture chỗ này thì chỉ có chỗ này sd culture này còn
            //lại sài mặc định
        }

        private void LoadSeats(List<Ticket> list)
        {
            flpSeat.Controls.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                Button btnSeat = new Button() { Width = SIZE + 20, Height = SIZE };
                btnSeat.Text = list[i].SeatName;
                btnSeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                if(list[i].Status == 1)
                    btnSeat.BackColor = Color.Red;
                else
                    btnSeat.BackColor = Color.White;
                btnSeat.FlatAppearance.BorderSize = 2;
                btnSeat.FlatStyle = FlatStyle.Flat;
                if (list[i].TypeSeat == 1)
                    btnSeat.ForeColor = Color.Blue;
                else btnSeat.ForeColor = Color.Green;
                btnSeat.Click += BtnSeat_Click;
                flpSeat.Controls.Add(btnSeat);

                btnSeat.Tag = list[i];
            }
        }


        private void BtnSeat_Click(object sender, EventArgs e)
        {
            Button btnSeat = sender as Button;
            if (btnSeat.BackColor == Color.White)
            {
                btnSeat.BackColor = Color.Yellow;
                Ticket ticket = btnSeat.Tag as Ticket;
                originalFare = ticket.Price;
                total += ticket.Price;
            }
            else if (btnSeat.BackColor == Color.Yellow)
            {
                btnSeat.BackColor = Color.White;
                Ticket ticket = btnSeat.Tag as Ticket;
                originalFare = 0;
                total -= ticket.Price;
            }
            else if (btnSeat.BackColor == Color.Red)
            {
                MessageBox.Show("Ghế số [" + btnSeat.Text + "] đã có người mua");
            }
            LoadBill();
        }

        private void ckbCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbCustomer.Checked == true)
            {
                frmCustomer frm = new frmCustomer();
                if (frm.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }
    }
}
