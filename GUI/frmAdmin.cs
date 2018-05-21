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

namespace GUI
{
    public partial class frmAdmin : Form
    {
        BindingSource staffList = new BindingSource();

		public frmAdmin()
        {
            InitializeComponent();

			dtgvStaff.DataSource = staffList;

			LoadComboBoxRevenue();
			LoadDateTimePickerRevenue();//Set "Từ ngày" & "Đến ngày ngày" về đầu tháng & cuối tháng
			LoadStaffList();
            AddStaffBinding();
        }

		#region Doanh Thu
		void LoadComboBoxRevenue()
		{
			cboSelectMovie.DataSource = MovieDAO.GetListMovie();
			cboSelectMovie.DisplayMember = "Name";
			cboSelectMovie.ValueMember = "ID";
		}

		void LoadDateTimePickerRevenue()
		{
			dtmFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
			dtmToDate.Value = dtmFromDate.Value.AddMonths(1).AddDays(-1);
		}

		decimal GetSumRevenue()
		{
			decimal sum = 0;
			foreach (DataGridViewRow row in dtgvRevenue.Rows)
			{
				sum += Convert.ToDecimal(row.Cells["Tiền vé"].Value);
			}
			return sum;
		}

		void LoadRevenue(string idMovie, DateTime fromDate, DateTime toDate)
		{
			dtgvRevenue.DataSource = RevenueDAO.GetRevenue(idMovie, fromDate, toDate);
		}

		private void btnShowRevenue_Click(object sender, EventArgs e)
		{
			LoadRevenue(cboSelectMovie.SelectedValue.ToString(), dtmFromDate.Value, dtmToDate.Value);
			txtDoanhThu.Text = GetSumRevenue().ToString() + " VNĐ";
		}
        #endregion

        #region Nhân Viên
        void LoadStaffList()
        {
            staffList.DataSource = StaffDAO.GetListStaff();
        }

        private void btnShowStaff_Click(object sender, EventArgs e)
        {
            LoadStaffList();
        }
        void AddStaffBinding()
        {
            txtStaffId.DataBindings.Add("Text", dtgvStaff.DataSource, "Mã nhân viên", true, DataSourceUpdateMode.Never);
            txtStaffName.DataBindings.Add("Text", dtgvStaff.DataSource, "Họ tên", true, DataSourceUpdateMode.Never);
            txtStaffBirth.DataBindings.Add("Text", dtgvStaff.DataSource, "Ngày sinh", true, DataSourceUpdateMode.Never);
            txtStaffAddress.DataBindings.Add("Text", dtgvStaff.DataSource, "Địa chỉ", true, DataSourceUpdateMode.Never);
            txtStaffPhone.DataBindings.Add("Text", dtgvStaff.DataSource, "SĐT", true, DataSourceUpdateMode.Never);
            txtStaffINumber.DataBindings.Add("Text", dtgvStaff.DataSource, "CMND", true, DataSourceUpdateMode.Never);

        }


		//Thêm Staff
        void AddStaff(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, int cmnd)
        {
            if (StaffDAO.InsertStaff(id, hoTen, ngaySinh, diaChi, sdt, cmnd))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }
        }
        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            string staffId = txtStaffId.Text;
            string staffName = txtStaffName.Text;
            DateTime staffBirth = DateTime.Parse(txtStaffBirth.Text);
            string staffAddress = txtStaffAddress.Text;
            string staffPhone = txtStaffPhone.Text;
            int staffINumber = Int32.Parse(txtStaffINumber.Text);
            AddStaff(staffId, staffName, staffBirth, staffAddress, staffPhone, staffINumber);
            LoadStaffList();
        }

		//Sửa Staff
		void UpdateStaff(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, int cmnd)
		{
			if (StaffDAO.UpdateStaff(id, hoTen, ngaySinh, diaChi, sdt, cmnd))
			{
				MessageBox.Show("Sửa tài khoản thành công");
			}
			else
			{
				MessageBox.Show("Sửa tài khoản thất bại");
			}
		}
		private void btnUpdateStaff_Click(object sender, EventArgs e)
		{
			string staffId = txtStaffId.Text;
			string staffName = txtStaffName.Text;
			DateTime staffBirth = DateTime.Parse(txtStaffBirth.Text);
			string staffAddress = txtStaffAddress.Text;
			string staffPhone = txtStaffPhone.Text;
			int staffINumber = Int32.Parse(txtStaffINumber.Text);
			UpdateStaff(staffId, staffName, staffBirth, staffAddress, staffPhone, staffINumber);
			LoadStaffList();
		}

		//Xóa Staff
		void DeleteStaff(string id)
		{
			if (StaffDAO.DeleteStaff(id))
			{
				MessageBox.Show("Xóa tài khoản thành công");
			}
			else
			{
				MessageBox.Show("Xóa tài khoản thất bại");
			}
		}
		private void btnDeleteStaff_Click(object sender, EventArgs e)
		{
			string staffId = txtStaffId.Text;
			DeleteStaff(staffId);
			LoadStaffList();
		}

		//Tìm kiếm Staff
		private void btnSearchStaff_Click(object sender, EventArgs e)
		{
			string staffName = txtSearchStaff.Text;
			DataTable staffSearchList = StaffDAO.SearchStaffByName(staffName);
			staffList.DataSource = staffSearchList;
		}

		private void txtSearchStaff_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btnSearchStaff.PerformClick();
				e.SuppressKeyPress = true;//Tắt tiếng *ting của windows
			}
		}
		#endregion

		#region Khách Hàng
		void LoadCustomer()
        {
            dtgvCustomer.DataSource = CustomerDAO.GetListCustomer();
        }
        private void btnShowCustomer_Click(object sender, EventArgs e)
        {
            LoadCustomer();
        }

		#endregion
		
	}
}