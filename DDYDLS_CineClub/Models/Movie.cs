using DDYDLS_CineClubDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDYDLS_CineClubApi.Models
{
    public class Movie
    {
        public int Id_Movie { get; set; }
        public string Name { get; set; }
        public int Id_Studio { get; set; }
        public string Synopsis { get; set; }
        public int Year { get; set; }

        public Rating Rating { get; set; }
        public int AvgRating { get; set; }
        public int RatingForUser { get; set; }
        public int TMDB_ID { get; set; }
    }
}
