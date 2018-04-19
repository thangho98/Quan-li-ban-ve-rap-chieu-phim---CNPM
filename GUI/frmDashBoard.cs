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
			this.Hide();
            frmLogin frm = new frmLogin();
			frm.ShowDialog();

            while (frm.DialogResult == DialogResult.OK)
            {
                frmQuanLi quanLi = new frmQuanLi();
				frm.Hide();
				quanLi.ShowDialog();
				frm.ShowDialog();
            }

			if (frm.DialogResult == DialogResult.Cancel)
			{
				frm.Close();
			}
			this.Show();
        }

        private void btnSeller_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSeller frm = new frmSeller();
			frm.ShowDialog();
            this.Show();
        }
    }
}