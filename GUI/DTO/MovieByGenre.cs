using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DTO
{
    public class MovieByGenre
    {
        public MovieByGenre(string movieID, string genre)
        {
            this.MovieID = movieID;
            this.Genre = genre;
        }

        public MovieByGenre(DataRow row)
        {
            this.MovieID = row["idPhim"].ToString();
            this.Genre = row["idTheLoai"].ToString();
        }

        public string MovieID { get; set; }

        public string Genre { get; set; }
    }
}
