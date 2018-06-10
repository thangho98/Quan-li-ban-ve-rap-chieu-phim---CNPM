using GUI.DAO;
using GUI.DTO;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmAccountSettings : Form
    {
        Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }

        public frmAccountSettings(Account account)
        {
            InitializeComponent();

            LoginAccount = account;
        }

        void ChangeAccount(Account account)
        {
            txtStaffID.Text = account.StaffID.ToString();
            txtUsername.Text = account.UserName.ToString();
        }

        void ApplyChanges()
        {
            string username = txtUsername.Text;
            string newPass = txtNewPass.Text;
            string reEnterPass = txtReEnter.Text;
            string confirmPass = txtConfirmPass.Text;

            if (newPass != reEnterPass)
            {
                MessageBox.Show("Hai mật khẩu mới chưa trùng nhau!");
            }
            else if (newPass == "")
            {
                MessageBox.Show("Mật khẩu không được để trống.");
            }
            else
            {
                if (AccountDAO.UpdatePasswordForAccount(username, confirmPass, newPass))
                {
                    MessageBox.Show("Cập nhật thành công!");
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khẩu.");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            ApplyChanges();
        }
    }
}
