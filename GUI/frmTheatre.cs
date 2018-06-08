using GUI.DAO;
using GUI.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;//thư viện thay đổi vùng/quốc gia
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmTheatre : Form
    {
        int SIZE = 30;//Size của ghế
        int GAP = 7;//Khoảng cách giữa các ghế

        List<Ticket> listSeat = new List<Ticket>();

        //dùng lưu vết các Ghế đang chọn
        List<Button> listSeatSelected = new List<Button>();

        float displayPrice = 0;//Hiện thị giá vé
        float ticketPrice = 0;//Lưu giá vé gốc
        float total = 0;//Tổng giá tiền
        float discount = 0;//Tiền được giảm
        float payment = 0;//Tiền phải trả

        ShowTimes Times;
        Movie Movie;

        public frmTheatre(ShowTimes showTimes, Movie movie)
        {
            InitializeComponent();

            Times = showTimes;
            Movie = movie;
        }

        private void frmTheatre_Load(object sender, EventArgs e)
        {
            ticketPrice = Times.TicketPrice;

            lblInformation.Text = "CGV Hung Vuong | " + Times.CinemaName + " | " + Times.MovieName;
            lblTime.Text = Times.Time.ToShortDateString() + " | "
                + Times.Time.ToShortTimeString() + " - "
                + Times.Time.AddMinutes(Movie.Time).ToShortTimeString();
            picFilm.Image = MovieDAO.byteArrayToImage(Movie.Poster);

            rdoAdult.Checked = true;
            chkCustomer.Enabled = false;
            grpLoaiVe.Enabled = false;

            LoadDataCinema(Times.CinemaName);

            ShowOrHideLablePoint();

            listSeat = TicketDAO.GetListTicketByShowTimes(Times.ID);

            LoadSeats(listSeat);
        }

        private void LoadDataCinema(string cinemaName)
        {
            Cinema cinema = CinemaDAO.GetCinemaByName(cinemaName);
            int Row = cinema.Row;
            int Column = cinema.SeatInRow;
            flpSeat.Size = new Size((SIZE + 20 + GAP) * Column, (SIZE + GAP) * Row);
        }

        private void LoadBill()
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            //Đổi culture vùng quốc gia để đổi đơn vị tiền tệ 

            //Thread.CurrentThread.CurrentCulture = culture;
            //dùng thread để chuyển cả luồng đang chạy về vùng quốc gia đó

            lblTicketPrice.Text = displayPrice.ToString("c", culture);
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
                if (list[i].Status == 1)
                    btnSeat.BackColor = Color.Red;
                else
                    btnSeat.BackColor = Color.White;
                btnSeat.Click += BtnSeat_Click;
                flpSeat.Controls.Add(btnSeat);

                btnSeat.Tag = list[i];
            }
        }

        //private void BtnSeat_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Right)
        //    {
        //        Button btnSeat = sender as Button;
        //        btnSeat.Focus();
        //        if (btnSeat.BackColor == Color.Yellow)
        //        {
        //            Ticket ticket = btnSeat.Tag as Ticket;

        //            displayPrice = ticket.Price;

        //            if (ticket.Type == 1)
        //                rdoAdult.Checked = true;
        //            else if (ticket.Type == 2)
        //                rdoStudent.Checked = true;
        //            else
        //                rdoChild.Checked = true;

        //            LoadBill();
        //            MessageBox.Show(ticket.SeatName + "\t" + ticket.Type + "\n" + ticket.Price);
        //        }
        //    }
        //}

        private void BtnSeat_Click(object sender, EventArgs e)
        {
            Button btnSeat = sender as Button;
            if (btnSeat.BackColor == Color.White)
            {
                grpLoaiVe.Enabled = true;
                rdoAdult.Checked = true;

                btnSeat.BackColor = Color.Yellow;
                Ticket ticket = btnSeat.Tag as Ticket;

                ticket.Price = ticketPrice;
                displayPrice = ticket.Price;
                total += ticketPrice;
                ticket.Type = 1;

                listSeatSelected.Add(btnSeat);
            }
            else if (btnSeat.BackColor == Color.Yellow)
            {
                btnSeat.BackColor = Color.White;
                Ticket ticket = btnSeat.Tag as Ticket;

                total -= ticket.Price;
                ticket.Price = 0;
                displayPrice = ticket.Price;

                listSeatSelected.Remove(btnSeat);
                grpLoaiVe.Enabled = false;
            }
            else if (btnSeat.BackColor == Color.Red)
            {
                MessageBox.Show("Ghế số [" + btnSeat.Text + "] đã có người mua");
            }
            LoadBill();
            if (listSeatSelected.Count > 0)
            {
                chkCustomer.Enabled = true;
            }
            else
            {
                chkCustomer.Enabled = false;
            }
        }

        //dùng để ẩn hiện lable điểm tích lũy của khách hàng thành viên
        private void ShowOrHideLablePoint()
        {
            if (chkCustomer.Checked == true)
            {
                lblPoint.Visible = true;
                lblDiemTichLuy.Visible = true;
            }
            else
            {
                lblPoint.Visible = false;
                lblDiemTichLuy.Visible = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn hủy tất cả những vé đã chọn ko?",
                "Hủy Mua Vé", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            foreach (Button btn in listSeatSelected)
            {
                btn.BackColor = Color.White;
            }
            RestoreDefault();
        }

        private void RestoreDefault()
        {
            listSeatSelected.Clear();

            rdoAdult.Checked = true;
            grpLoaiVe.Enabled = false;
            chkCustomer.Checked = false;
            chkCustomer.Enabled = false;

            ShowOrHideLablePoint();
            lblPoint.Visible = false;
            lblDiemTichLuy.Visible = false;

            total = 0;
            displayPrice = 0;
            discount = 0;
            payment = 0;

            LoadBill();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (listSeatSelected.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn vé trước khi thanh toán!");
                return;
            }
            string message = "Bạn có chắc chắn mua những vé: \n";
            foreach (Button btn in listSeatSelected)
            {
                message += "[" + btn.Text + "] ";
            }
            message += "\nKhông?";
            DialogResult result = MessageBox.Show(message, "Hỏi Mua",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                int ret = 0;
                foreach (Button btn in listSeatSelected)
                {
                    Ticket ticket = btn.Tag as Ticket;
                    ret += TicketDAO.BuyTicket(ticket.ID, ticket.Type, ticket.Price);
                }
                if (ret == listSeatSelected.Count)
                {
                    MessageBox.Show("Bạn đã mua vé thành công!");
                }
            }
            RestoreDefault();
            this.OnLoad(null);
        }

        private void rdoStudent_Click(object sender, EventArgs e)
        {
            if (rdoStudent.Checked == true)
            {
                if (listSeatSelected.Count == 0) return;
                Ticket ticket = listSeatSelected[listSeatSelected.Count - 1].Tag as Ticket;
                ticket.Type = 2;

                float oldPrice = ticket.Price;
                ticket.Price = 0.8f * ticketPrice;
                displayPrice = ticket.Price;
                total = total + ticket.Price - oldPrice;

                LoadBill();
            }
        }

        private void rdoAdult_Click(object sender, EventArgs e)
        {
            if (rdoAdult.Checked == true)
            {
                if (listSeatSelected.Count == 0) return;
                Ticket ticket = listSeatSelected[listSeatSelected.Count - 1].Tag as Ticket;
                ticket.Type = 1;

                float oldPrice = ticket.Price;
                ticket.Price = ticketPrice;
                displayPrice = ticket.Price;
                total = total + ticket.Price - oldPrice;

                LoadBill();
            }
        }

        private void rdoChild_Click(object sender, EventArgs e)
        {
            if (rdoChild.Checked == true)
            {
                if (listSeatSelected.Count == 0) return;
                Ticket ticket = listSeatSelected[listSeatSelected.Count - 1].Tag as Ticket;
                ticket.Type = 3;

                float oldPrice = ticket.Price;
                ticket.Price = 0.7f * ticketPrice;
                displayPrice = ticket.Price;
                total = total + ticket.Price - oldPrice;

                LoadBill();
            }
        }

        private void chkCustomer_Click(object sender, EventArgs e)
        {
            if (chkCustomer.Checked == true)
            {
                frmCustomer frm = new frmCustomer();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    lblPoint.Visible = true;
                    lblDiemTichLuy.Visible = true;
                    ShowOrHideLablePoint();
                }
                else
                {
                    chkCustomer.Checked = false;
                }
            }
            else
            {
                ShowOrHideLablePoint();
            }
        }
    }
}
