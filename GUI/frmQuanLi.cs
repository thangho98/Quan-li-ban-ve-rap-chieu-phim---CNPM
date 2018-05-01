using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace GUI
{
    public partial class frmQuanLi : Form
    {
        public frmQuanLi()
        {
            InitializeComponent();

			LoadAccountList();
        }


		void LoadAccountList()
		{
			string commandStr = "SELECT * FROM dbo.NHANVIEN";
			
			dgvTest.DataSource = DataProvider.Instance.ExecuteQuerry(commandStr);

		}
	}
}