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
    public partial class frmThongTinDatVe : Form
    {
        public frmThongTinDatVe()
        {
            InitializeComponent();
        }

        private void frmThongTinDatVe_Load(object sender, EventArgs e)
        {
            
        }

        private void ckbThanhVien_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbThanhVien.Checked == true)
            {
                pnThanhVien.Enabled = true;
            }
            else
                pnThanhVien.Enabled = false;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
