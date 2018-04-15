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
        public frmTheatre()
        {
            InitializeComponent();
        }
        
        private void frmTheatre_Load(object sender, EventArgs e)
        {
            XuLiVeGheLenGiaoDien(120);
        }

        private void XuLiVeGheLenGiaoDien(int Ghe)
        {
            TableLayoutPanel pnGhe = new TableLayoutPanel();
            pnGhe.AutoScroll = true;
            pnGhe.ContextMenuStrip = contextMenuStrip1;
            pnGhe.Dock = DockStyle.Fill;
            pnGhe.RowCount = 10;
            for(int i =0;i<pnGhe.RowCount;i++)
            {
                pnGhe.RowStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            }
            pnGhe.ColumnCount = Ghe / 10;
            double percent = 100 / Ghe;
            for (int i = 0; i < pnGhe.ColumnCount; i++)
            {
                pnGhe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            }
            this.Controls.Add(pnGhe);
            int ghe = 1;
            for (int i = 0; i < pnGhe.RowCount; i++)
            {
                for (int j = 0; j < pnGhe.ColumnCount; j++)
                {
                    Label lblGhe = new Label();
                    lblGhe.Text = ghe + "";
                    lblGhe.AutoSize = false;
                    lblGhe.Dock = DockStyle.Fill;
                    lblGhe.TextAlign = ContentAlignment.MiddleCenter;
                    lblGhe.Width = lblGhe.Height = 50;
                    lblGhe.BackColor = Color.White;
                    pnGhe.Controls.Add(lblGhe, j, i);
                    ghe++;
                    lblGhe.Click += LblGhe_Click;
                }
            }
        }

        private void LblGhe_Click(object sender, EventArgs e)
        {
            Label lblGhe = sender as Label;
            if (lblGhe.BackColor == Color.White)
                lblGhe.BackColor = Color.Green;
            else if (lblGhe.BackColor == Color.Green)
                lblGhe.BackColor = Color.White;
            else if (lblGhe.BackColor == Color.Yellow)
            {
                MessageBox.Show("Ghế số [" + lblGhe.Text + "] đã có người đặt vé");
            }
        }

        private void mnuDatVe_Click(object sender, EventArgs e)
        {
            frmThongTinDatVe frm = new frmThongTinDatVe();
            if(frm.ShowDialog()==DialogResult.OK)
            {
                if(frm.ckbThanhVien.Checked ==true)
                {
                    //Xử lí
                    MessageBox.Show("");
                }
                {
                    //Xử lí
                    MessageBox.Show("Bạn đã mua vé...");
                }
            }
        }
    }
}
