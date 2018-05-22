﻿using GUI.DAO;
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
		BindingSource customerList = new BindingSource();

		public frmAdmin()
        {
            InitializeComponent();

			LoadRevenue();
			
			LoadStaff();

			LoadCustomer();
        }

		#region Doanh Thu
		void LoadRevenue()
		{
			LoadComboBoxRevenue();
			LoadDateTimePickerRevenue();//Set "Từ ngày" & "Đến ngày ngày" về đầu tháng & cuối tháng
			LoadRevenue(cboSelectMovie.SelectedValue.ToString(), dtmFromDate.Value, dtmToDate.Value);
		}

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
			txtDoanhThu.Text = GetSumRevenue().ToString() + " VNĐ";
		}

		private void btnShowRevenue_Click(object sender, EventArgs e)
		{
			LoadRevenue(cboSelectMovie.SelectedValue.ToString(), dtmFromDate.Value, dtmToDate.Value);
		}
		#endregion

		#region Nhân Viên
		void LoadStaff()
		{
			dtgvStaff.DataSource = staffList;
			LoadStaffList();
			AddStaffBinding();
		}

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
                MessageBox.Show("Thêm nhân viên thành công");
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại");
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
				MessageBox.Show("Sửa nhân viên thành công");
			}
			else
			{
				MessageBox.Show("Sửa nhân viên thất bại");
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
				MessageBox.Show("Xóa nhân viên thành công");
			}
			else
			{
				MessageBox.Show("Xóa nhân viên thất bại");
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
			dtgvCustomer.DataSource = customerList;
			LoadCustomerList();
			AddCustomerBinding();
		}

		void LoadCustomerList()
        {
            customerList.DataSource = CustomerDAO.GetListCustomer();
        }
        private void btnShowCustomer_Click(object sender, EventArgs e)
        {
            LoadCustomerList();
        }

		void AddCustomerBinding()
		{
			txtCusID.DataBindings.Add("Text", dtgvCustomer.DataSource, "Mã khách hàng", true, DataSourceUpdateMode.Never);
			txtCusName.DataBindings.Add("Text", dtgvCustomer.DataSource, "Họ tên", true, DataSourceUpdateMode.Never);
			txtCusBirth.DataBindings.Add("Text", dtgvCustomer.DataSource, "Ngày sinh", true, DataSourceUpdateMode.Never);
			txtCusAddress.DataBindings.Add("Text", dtgvCustomer.DataSource, "Địa chỉ", true, DataSourceUpdateMode.Never);
			txtCusPhone.DataBindings.Add("Text", dtgvCustomer.DataSource, "SĐT", true, DataSourceUpdateMode.Never);
			txtCusINumber.DataBindings.Add("Text", dtgvCustomer.DataSource, "CMND", true, DataSourceUpdateMode.Never);
			nudPoint.DataBindings.Add("Value", dtgvCustomer.DataSource, "Điểm tích lũy", true, DataSourceUpdateMode.Never);
		}

		void InsertCustomer(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, int cmnd)
		{
			if (CustomerDAO.InsertCustomer(id, hoTen, ngaySinh, diaChi, sdt, cmnd))
			{
				MessageBox.Show("Thêm khách hàng thành công");
			}
			else
			{
				MessageBox.Show("Thêm khách hàng thất bại");
			}
		}
		private void btnAddCustomer_Click(object sender, EventArgs e)
		{
			string cusID = txtCusID.Text;
			string cusName = txtCusName.Text;
			DateTime cusBirth = DateTime.Parse(txtCusBirth.Text);
			string cusAddress = txtCusAddress.Text;
			string cusPhone = txtCusPhone.Text;
			int cusINumber = Int32.Parse(txtCusINumber.Text);
			InsertCustomer(cusID, cusName, cusBirth, cusAddress, cusPhone, cusINumber);
			LoadCustomerList();
		}

		void UpdateCustomer(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, int cmnd, int point)
		{
			if (CustomerDAO.UpdateCustomer(id, hoTen, ngaySinh, diaChi, sdt, cmnd, point))
			{
				MessageBox.Show("Sửa khách hàng thành công");
			}
			else
			{
				MessageBox.Show("Sửa khách hàng thất bại");
			}
		}
		private void btnUpdateCustomer_Click(object sender, EventArgs e)
		{
			string cusID = txtCusID.Text;
			string cusName = txtCusName.Text;
			DateTime cusBirth = DateTime.Parse(txtCusBirth.Text);
			string cusAddress = txtCusAddress.Text;
			string cusPhone = txtCusPhone.Text;
			int cusINumber = Int32.Parse(txtCusINumber.Text);
			int cusPoint = (int)nudPoint.Value;
			UpdateCustomer(cusID, cusName, cusBirth, cusAddress, cusPhone, cusINumber, cusPoint);
			LoadCustomerList();
		}

		void DeleteCustomer(string id)
		{
			if (CustomerDAO.DeleteCustomer(id))
			{
				MessageBox.Show("Xóa khách hàng thành công");
			}
			else
			{
				MessageBox.Show("Xóa khách hàng thất bại");
			}
		}
		private void btnDeleteCustomer_Click(object sender, EventArgs e)
		{
			string cusID = txtCusID.Text;
			DeleteCustomer(cusID);
			LoadCustomerList();
		}
		#endregion

	}
}