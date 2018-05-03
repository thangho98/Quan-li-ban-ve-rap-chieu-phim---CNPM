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

            dtpThoiGian.Value = DateTime.Now;
            LoadMovie();
        }

        private void LoadMovie()
        {
            cboFilmName.Items.Clear();
            DataTable data = MovieDAO.GetListMovie(dtpThoiGian.Value.Date);
            foreach (DataRow row in data.Rows)
            {
                Movie movie = new Movie(row);
                cboFilmName.Items.Add(movie);
            }
        }

        private void cboFilmName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboFilmName.SelectedIndex != -1)
            {
                Movie movie = cboFilmName.SelectedItem as Movie;
                LoadFormatMovieByMovie(movie.ID);
            }
        }

        private void LoadFormatMovieByMovie(string movieID)
        {
            cboFormatFilm.Items.Clear();
            DataTable data = FormatMovieDAO.GetListFormatMovieByMovie(movieID);
            foreach (DataRow row in data.Rows)
            {
                FormatMovie format = new FormatMovie(row);
                cboFormatFilm.Items.Add(format);
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
                ListViewItem lvi = new ListViewItem(showTimes.CinemaName);
                lvi.SubItems.Add(showTimes.MovieName);
                lvi.SubItems.Add(showTimes.Time.ToShortTimeString());
                lvi.Tag = showTimes;

                lvLichChieu.Items.Add(lvi);
            }
        }

        private void lvLichChieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvLichChieu.SelectedItems.Count > 0)
            {
                ShowTimes showTimes = lvLichChieu.SelectedItems[0].Tag as ShowTimes;
                Movie movie = cboFilmName.SelectedItem as Movie;
                frmTheatre frm = new frmTheatre(showTimes,movie);
                if (frm.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }
    }
}
