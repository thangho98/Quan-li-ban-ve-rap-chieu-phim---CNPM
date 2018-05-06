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
        }

        private void frmSeller_Load(object sender, EventArgs e)
        {
            dtpThoiGian.Value = DateTime.Now;
            //LoadMovie(dtpThoiGian.Value);
            timer1.Start();
        }

        private void LoadMovie(DateTime date)
        {
            cboFilmName.DataSource = MovieDAO.GetListMovieByDate(date);
            cboFilmName.DisplayMember = "Name";
        }

        private void cboFilmName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboFilmName.SelectedIndex != -1)
            {
                Movie movie = cboFilmName.SelectedItem as Movie;
                cboFormatFilm.DataSource = FormatMovieDAO.GetListFormatMovieByMovie(movie.ID);
                cboFormatFilm.DisplayMember = "ScreenTypeName";
            }
        }

        private void cboFormatFilm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboFormatFilm.SelectedIndex != -1)
            {
                lvLichChieu.Items.Clear();
                FormatMovie format = cboFormatFilm.SelectedItem as FormatMovie;
                LoadListShowTimeByFilm(format.ID);
            }
        }

        private void LoadListShowTimeByFilm(string formatMovieID)
        {
            DataTable data = ShowTimesDAO.GetListShowTimeByFormatMovie(formatMovieID);
            foreach(DataRow row in data.Rows)
            {
                ShowTimes showTimes = new ShowTimes(row);
                ListViewItem lvi = new ListViewItem("");
                lvi.SubItems.Add(showTimes.CinemaName);
                lvi.SubItems.Add(showTimes.MovieName);
                lvi.SubItems.Add(showTimes.Time.ToShortTimeString());
                lvi.Tag = showTimes;

                string statusShowTimes = TicketDAO.CountTheNumberOfTicketsSoldByShowTime(showTimes.ID)
                    + "/" + TicketDAO.CountToltalTicketByShowTime(showTimes.ID);

                lvi.SubItems.Add(statusShowTimes);

                float status = (float)TicketDAO.CountTheNumberOfTicketsSoldByShowTime(showTimes.ID)
                    / TicketDAO.CountToltalTicketByShowTime(showTimes.ID);

                //thêm ảnh status
                if (status == 1)
                    lvi.ImageIndex = 2;
                else if(status > 0.5f)
                    lvi.ImageIndex = 1;
                else lvi.ImageIndex = 0;

                lvLichChieu.Items.Add(lvi);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Load lại form để cập nhật cơ sở dữ liệu
            this.OnLoad(null);
        }

        private void lvLichChieu_Click(object sender, EventArgs e)
        {
            if (lvLichChieu.SelectedItems.Count > 0)
            {
                ShowTimes showTimes = lvLichChieu.SelectedItems[0].Tag as ShowTimes;
                Movie movie = cboFilmName.SelectedItem as Movie;
                frmTheatre frm = new frmTheatre(showTimes, movie);
                this.Hide();
                frm.ShowDialog();
                this.OnLoad(null);
                this.Show();
            }
        }

        private void dtpThoiGian_ValueChanged(object sender, EventArgs e)
        {
            LoadMovie(dtpThoiGian.Value);
        }
    }
}
