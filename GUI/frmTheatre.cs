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

namespace GUI
{
    public partial class frmTheatre : Form
    {
        int SIZE = 30;
        DateTime time = new DateTime();

        public frmTheatre()
        {
            InitializeComponent();
        }

        private void frmTheatre_Load(object sender, EventArgs e)
        {
            time = DateTime.Now.AddHours(2.5);
            LoadSeats();
            lblInformation.Text = "CGV Hung Vuong | Cinema 1 | Hello Co Tien";
            lblTime.Text = DateTime.Now.ToShortDateString() + " | "
                + DateTime.Now.ToShortTimeString() + " - "
                + time.ToShortTimeString();
            
        }

        private void LoadSeats()
        {
            flpSeat.Controls.Clear();

            List<Ticket> SeatList= new List<Ticket>();

            //foreach (Ticket item in SeatList)
            //{
            //    Button btnSeat = new Button() { Width = SIZE, Height =SIZE };
            //    btnSeat.Text = item.Seat + Environment.NewLine + item.Status;
            //    btnSeat.Click += btnSeat_Click;
            //    btnSeat.Tag = item;

            //    switch (item.Status)
            //    {
            //        case "Chưa Bán":
            //            btnSeat.BackColor = Color.Aqua;
            //            break;
            //        default:
            //            btnSeat.BackColor = Color.LightPink;
            //            break;
            //    }

            //    flpSeat.Controls.Add(btnSeat);
            //}

            for (int i = 65; i <= 75; i++)
            {
                for (int j = 1; j <= 14; j++)
                {
                    Button btnSeat = new Button() { Width = SIZE + 20, Height = SIZE };
                    btnSeat.Text = "" + (char)i + j;
                    btnSeat.BackColor = Color.White;
                    btnSeat.FlatAppearance.BorderSize = 2;
                    btnSeat.FlatStyle = FlatStyle.Flat;
                    if (i > 68 && j > 3 && j < 12)
                        btnSeat.ForeColor = Color.Red;
                    else btnSeat.ForeColor = Color.Green;
                    btnSeat.Click += BtnSeat_Click;
                    flpSeat.Controls.Add(btnSeat);
                }
            }
        }


        private void BtnSeat_Click(object sender, EventArgs e)
        {
            Button btnSeat = sender as Button;
            if (btnSeat.BackColor == Color.White)
                btnSeat.BackColor = Color.Aqua;
            else if (btnSeat.BackColor == Color.Aqua)
                btnSeat.BackColor = Color.White;
            else if (btnSeat.BackColor == Color.Yellow)
            {
                MessageBox.Show("Ghế số [" + btnSeat.Text + "] đã có người đặt vé");
            }
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
