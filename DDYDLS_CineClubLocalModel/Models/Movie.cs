﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DDYDLS_CineClubLocalModel.Models
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
    }
}
