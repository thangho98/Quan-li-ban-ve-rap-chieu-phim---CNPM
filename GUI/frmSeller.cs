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
    public partial class frmSeller : Form
    {
        public frmSeller()
        {
            InitializeComponent();
        }

        private void frmSeller_Load(object sender, EventArgs e)
        {
            dtpThoiGian.Value = DateTime.Now;
        }

        private void lvLichChieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvLichChieu.SelectedItems.Count > 0)
            {
                //Xu lí
                frmTheatre frm = new frmTheatre();
                if (frm.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }
    }
}
