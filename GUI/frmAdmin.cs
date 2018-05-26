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
		BindingSource customerList = new BindingSource();
		BindingSource genreList = new BindingSource();
		BindingSource screenTypeList = new BindingSource();
		BindingSource cinemaList = new BindingSource();

		public frmAdmin()
        {
            InitializeComponent();

			LoadRevenue();
			
			LoadStaff();

			LoadCustomer();

			LoadGenre();

			LoadScreenType();

			LoadCinema();
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

		private void btnSearchCus_Click(object sender, EventArgs e)
		{
			string cusName = txtSearchCus.Text;
			customerList.DataSource = CustomerDAO.SearchCustomerByName(cusName);
		}
		private void txtSearchCus_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btnSearchCus.PerformClick();
				e.SuppressKeyPress = true;
			}
		}
		#endregion

		//Tab 'Dữ liệu'
		#region Thể Loại
		void LoadGenre()
		{
			dtgvGenre.DataSource = genreList;
			LoadGenreList();
			AddGenreBinding();
		}
		void LoadGenreList()
		{
			genreList.DataSource = GenreDAO.GetListGenre();
		}
		void AddGenreBinding()
		{
			txtGenreID.DataBindings.Add("Text", dtgvGenre.DataSource, "Mã thể loại", true, DataSourceUpdateMode.Never);
			txtGenreName.DataBindings.Add("Text", dtgvGenre.DataSource, "Tên thể loại", true, DataSourceUpdateMode.Never);
			txtGenreDesc.DataBindings.Add("Text", dtgvGenre.DataSource, "Mô tả", true, DataSourceUpdateMode.Never);
		}
		private void btnShowGenre_Click(object sender, EventArgs e)
		{
			LoadGenreList();
		}

		void InsertGenre(string id, string name, string desc)
		{
			if (GenreDAO.InsertGenre(id, name, desc))
			{
				MessageBox.Show("Thêm thể loại thành công");
			}
			else
			{
				MessageBox.Show("Thêm thể loại thất bại");
			}
		}
		private void btnInsertGenre_Click(object sender, EventArgs e)
		{
			string GenreID = txtGenreID.Text;
			string GenreName = txtGenreName.Text;
			string GenreDesc = txtGenreDesc.Text;
			InsertGenre(GenreID, GenreName, GenreDesc);
			LoadGenreList();
		}

		void UpdateGenre(string id, string name, string desc)
		{
			if (GenreDAO.UpdateGenre(id, name, desc))
			{
				MessageBox.Show("Sửa thể loại thành công");
			}
			else
			{
				MessageBox.Show("Sửa thể loại thất bại");
			}
		}
		private void btnUpdateGenre_Click(object sender, EventArgs e)
		{
			string GenreID = txtGenreID.Text;
			string GenreName = txtGenreName.Text;
			string GenreDesc = txtGenreDesc.Text;
			UpdateGenre(GenreID, GenreName, GenreDesc);
			LoadGenreList();
		}

		void DeleteGenre(string id)
		{
			if (GenreDAO.DeleteGenre(id))
			{
				MessageBox.Show("Xóa thể loại thành công");
			}
			else
			{
				MessageBox.Show("Xóa thể loại thất bại");
			}
		}
		private void btnDeleteGenre_Click(object sender, EventArgs e)
		{
			string GenreID = txtGenreID.Text;
			DeleteGenre(GenreID);
			LoadGenreList();
		}
		#endregion

		#region Loại Màn Hình
		void LoadScreenType()
		{
			dtgvScreenType.DataSource = screenTypeList;
			LoadScreenTypeList();
			AddScreenTypeBinding();
		}
		void LoadScreenTypeList()
		{
			screenTypeList.DataSource = ScreenTypeDAO.GetScreenType();
		}
		void AddScreenTypeBinding()
		{
			txtScreenTypeID.DataBindings.Add("Text", dtgvScreenType.DataSource, "Mã loại màn hình");
			txtScreenTypeName.DataBindings.Add("Text", dtgvScreenType.DataSource, "Tên màn hình");
		}
		private void btnShowScreenType_Click(object sender, EventArgs e)
		{
			LoadScreenTypeList();
		}

		void InsertScreenType(string id, string name)
		{
			if (ScreenTypeDAO.InsertScreenType(id, name))
			{
				MessageBox.Show("Thêm loại màn hình thành công");
			}
			else
			{
				MessageBox.Show("Thêm loại màn hình thất bại");
			}
		}
		private void btnInsertScreenType_Click(object sender, EventArgs e)
		{
			string screenTypeID = txtScreenTypeID.Text;
			string screenTypeName = txtScreenTypeName.Text;
			InsertScreenType(screenTypeID, screenTypeName);
			LoadScreenTypeList();
		}

		void UpdateScreenType(string id, string name)
		{
			if (ScreenTypeDAO.UpdateScreenType(id, name))
			{
				MessageBox.Show("Sửa loại màn hình thành công");
			}
			else
			{
				MessageBox.Show("Sửa loại màn hình thất bại");
			}
		}
		private void btnUpdateScreenType_Click(object sender, EventArgs e)
		{
			string screenTypeID = txtScreenTypeID.Text;
			string screenTypeName = txtScreenTypeName.Text;
			UpdateScreenType(screenTypeID, screenTypeName);
			LoadScreenTypeList();
		}

		void DeleteScreenType(string id)
		{
			if (ScreenTypeDAO.DeleteScreenType(id))
			{
				MessageBox.Show("Xóa loại màn hình thành công");
			}
			else
			{
				MessageBox.Show("Xóa loại màn hình thất bại");
			}
		}
		private void btnDeleteScreenType_Click(object sender, EventArgs e)
		{
			string screenTypeID = txtScreenTypeID.Text;
			DeleteScreenType(screenTypeID);
			LoadScreenTypeList();
		}
		#endregion

		#region Phòng chiếu
		void LoadCinema()
		{
			dtgvCinema.DataSource = cinemaList;
			LoadCinemaList();
			AddCinemaBinding();
		}
		void LoadCinemaList()
		{
			cinemaList.DataSource = CinemaDAO.GetListCinema();
		}
		void AddCinemaBinding()
		{
			txtCinemaID.DataBindings.Add("Text", dtgvCinema.DataSource, "Mã phòng");
			txtCinemaName.DataBindings.Add("Text", dtgvCinema.DataSource, "Tên phòng");
			txtCinemaSeats.DataBindings.Add("Text", dtgvCinema.DataSource, "Số chỗ ngồi");
			txtCinemaStatus.DataBindings.Add("Text", dtgvCinema.DataSource, "Tình trạng");
			txtNumberOfRows.DataBindings.Add("Text", dtgvCinema.DataSource, "Số hàng ghế");
			txtSeatsPerRow.DataBindings.Add("Text", dtgvCinema.DataSource, "Ghế mỗi hàng");
			LoadScreenTypeIntoComboBox(cboCinemaScreenType);
		}
		void LoadScreenTypeIntoComboBox(ComboBox cbo)
		{
			cbo.DataSource = ScreenTypeDAO.GetListScreenType();
			cbo.DisplayMember = "Name";
			cbo.ValueMember = "ID";
		}
		private void txtCinemaID_TextChanged(object sender, EventArgs e)
			//Use this to bind data between dtgv and cbo because cbo can't be applied DataBindings normally
		{
			string screenName = (string)dtgvCinema.SelectedCells[0].OwningRow.Cells["Tên màn hình"].Value;
			ScreenType screenType = ScreenTypeDAO.GetScreenTypeByName(screenName);
			//This is the ScreenType that we're currently selecting in dtgv

			cboCinemaScreenType.SelectedItem = screenType;

			int index = -1;
			int i = 0;
			foreach (ScreenType item in cboCinemaScreenType.Items)
			{
				if (item.Name == screenType.Name)
				{
					index = i;
					break;
				}
				i++;
			}
			cboCinemaScreenType.SelectedIndex = index;
		}

		private void btnShowCinema_Click(object sender, EventArgs e)
		{
			LoadCinemaList();
		}

		void InsertCinema(string id, string name, string idMH, int seats, int status, int numberOfRows, int seatsPerRow)
		{
			if (CinemaDAO.InsertCinema(id, name,idMH,seats,status,numberOfRows,seatsPerRow))
			{
				MessageBox.Show("Thêm phòng chiếu thành công");
			}
			else
			{
				MessageBox.Show("Thêm phòng chiếu thất bại");
			}
		}
		private void btnInsertCinema_Click(object sender, EventArgs e)
		{
			string cinemaID = txtCinemaID.Text;
			string cinemaName = txtCinemaName.Text;
			string screenTypeID = cboCinemaScreenType.SelectedValue.ToString();
			int cinemaSeats = int.Parse(txtCinemaSeats.Text);
			int cinemaStatus = int.Parse(txtCinemaStatus.Text);
			int numberOfRows = int.Parse(txtNumberOfRows.Text);
			int seatsPerRows = int.Parse(txtSeatsPerRow.Text);
			InsertCinema(cinemaID, cinemaName, screenTypeID, cinemaSeats, cinemaStatus, numberOfRows, seatsPerRows);
			LoadCinemaList();
		}

		void UpdateCinema(string id, string name, string idMH, int seats, int status, int numberOfRows, int seatsPerRow)
		{
			if (CinemaDAO.UpdateCinema(id, name, idMH, seats, status, numberOfRows, seatsPerRow))
			{
				MessageBox.Show("Sửa phòng chiếu thành công");
			}
			else
			{
				MessageBox.Show("Sửa phòng chiếu thất bại");
			}
		}
		private void btnUpdateCinema_Click(object sender, EventArgs e)
		{
			string cinemaID = txtCinemaID.Text;
			string cinemaName = txtCinemaName.Text;
			string screenTypeID = cboCinemaScreenType.SelectedValue.ToString();
			int cinemaSeats = int.Parse(txtCinemaSeats.Text);
			int cinemaStatus = int.Parse(txtCinemaStatus.Text);
			int numberOfRows = int.Parse(txtNumberOfRows.Text);
			int seatsPerRows = int.Parse(txtSeatsPerRow.Text);
			UpdateCinema(cinemaID, cinemaName, screenTypeID, cinemaSeats, cinemaStatus, numberOfRows, seatsPerRows);
			LoadCinemaList();
		}

		void DeleteCinema(string id)
		{
			if (CinemaDAO.DeleteCinema(id))
			{
				MessageBox.Show("Xóa phòng chiếu thành công");
			}
			else
			{
				MessageBox.Show("Xóa phòng chiếu thất bại");
			}
		}
		private void btnDeleteCinema_Click(object sender, EventArgs e)
		{
			string cinemaID = txtCinemaID.Text;
			DeleteCinema(cinemaID);
			LoadCinemaList();
		}
		#endregion

	}
}