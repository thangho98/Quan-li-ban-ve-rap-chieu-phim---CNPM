using GUI.frmAdminUserControls;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmAdminNewDesign : Form
    {
        public frmAdminNewDesign()
        {
            InitializeComponent();
        }


        private void btnRevenueUC_Click(object sender, EventArgs e)
        {
            this.Text = "Doanh Thu";
            pnAdmin.Controls.Clear();
            RevenueUC revenueUc = new RevenueUC();
            revenueUc.Dock = DockStyle.Fill;
            pnAdmin.Controls.Add(revenueUc);
        }

        private void btnDataUC_Click(object sender, EventArgs e)
        {
            this.Text = "Dữ Liệu";
            pnAdmin.Controls.Clear();
            DataUC dataUc = new DataUC();
            dataUc.Dock = DockStyle.Fill;
            pnAdmin.Controls.Add(dataUc);
        }

        private void btnStaffUC_Click(object sender, EventArgs e)
        {
            this.Text = "Nhân Viên";
            pnAdmin.Controls.Clear();
            StaffUC staffUc = new StaffUC();
            staffUc.Dock = DockStyle.Fill;
            pnAdmin.Controls.Add(staffUc);
        }

        private void btnCustomerUC_Click(object sender, EventArgs e)
        {
            this.Text = "Khách Hàng";
            pnAdmin.Controls.Clear();
            CustomerUC customerUc = new CustomerUC();
            customerUc.Dock = DockStyle.Fill;
            pnAdmin.Controls.Add(customerUc);
        }

        private void btnAccountUC_Click(object sender, EventArgs e)
        {
            this.Text = "Tài Khoản";
            pnAdmin.Controls.Clear();
            AccountUC accountUc = new AccountUC();
            accountUc.Dock = DockStyle.Fill;
            pnAdmin.Controls.Add(accountUc);
        }
    }
}
