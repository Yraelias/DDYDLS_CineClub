using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDYDLS_CineClubDAL.Models
{
    public class Movie
    {
        [Required]
        public int Id_Movie { get; set; }
        [Required]
        public string Name { get; set; }
        public int Year { get; set; }
        public Ratings Rating { get; set; }
        [Required]
        public int TMDB_ID { get; set; }

        public Movie()
        {
            Id_Movie = 1; // Initialisation de l'ID du film à zéro par défaut
        }
    }

}
