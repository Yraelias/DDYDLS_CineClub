using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDYDLS_CineClubDAL.Models
{
    public class Cineclub
    {
        [Required]
        public int Id_Cineclub { get; set; }
        [Required]
        public int Id_Movie_1 { get; set; }
        [Required]
        public int Id_Movie_2 { get; set; }
        [Required]
        public int Id_Movie_3 { get; set; }
        [Required]
        public int Id_Movie_4 { get; set; }
        public int? Id_Movie_5 { get; set; }
        [Required]
        public int NumberOfCineclub { get; set; }
        [Required]
        public DateTime Begin {  get; set; }
        public DateTime? End { get; set; }
        [Required]
        public string Title { get; set; }

        public ICollection<CineclubMovie> CineclubMovies { get; set; }

    }
}
