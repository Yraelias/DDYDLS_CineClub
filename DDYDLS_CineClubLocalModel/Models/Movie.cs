using System;
using System.Collections.Generic;
using System.Text;

namespace DDYDLS_CineClubLocalModel.Models
{
    public class Movie
    {
        public int Id_Movie { get; set; }
        public string Name { get; set; }
        public string Synopsis { get; set; }
        public int Year { get; set; }
        public Ratings Rating { get; set; }
        public int AvgRating { get; set; }
        public int RatingForUser { get; set; }
        public int TMDB_ID { get; set; }
    }
}
