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
    public partial class frmDashBoard : Form
    {
        public frmDashBoard()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            if(frm.ShowDialog()==DialogResult.OK)
            {
                //xử lí

                this.Hide();
                frmQuanLi quanLi = new frmQuanLi();
                quanLi.Closed += (s, args) => this.Close();
                quanLi.Show();
            }
            else if (frm.ShowDialog() == DialogResult.Cancel)
                frm.Close();
        }
        private void btnSeller_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSeller frm = new frmSeller();
            frm.Closed += (s, args) => this.Close();
            frm.Show();
        }
    }
}
