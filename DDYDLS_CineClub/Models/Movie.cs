﻿using System;
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
    }
}
