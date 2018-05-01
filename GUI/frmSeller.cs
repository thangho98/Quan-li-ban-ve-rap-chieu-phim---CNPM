using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.DAO;
using GUI.DTO;

namespace GUI
{
    public partial class frmSeller : Form
    {
        public frmSeller()
        {
            InitializeComponent();

            LoadGenre();
            LoadScreenType();
        }

        private void LoadScreenType()
        {
            cboScreenType.Items.Clear();
            DataTable data = ScreenTypeDAO.GetListScreenType();
            foreach (DataRow row in data.Rows)
            {
                ScreenType type = new ScreenType(row["id"].ToString(),row["TenMH"].ToString());
                cboScreenType.Items.Add(type);
            }
        }
        
        private void LoadGenre()
        {
            cboGenre.Items.Clear();
            DataTable data = GenreDAO.GetListGenre();
            foreach (DataRow row in data.Rows)
            {
                Genre genre = new Genre(row["id"].ToString(), row["TenTheLoai"].ToString());
                cboGenre.Items.Add(genre);
            }
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
