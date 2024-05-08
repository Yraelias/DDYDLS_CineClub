using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDYDLS_CineClubDAL.Models
{
    public class CineclubMovie
    {
        public int Id { get; set; }
        public int CineclubId { get; set; }
        public int MovieId { get; set; }

        public Cineclub Cineclub { get; set; }
        public Movie Movie { get; set; }
    }
}
