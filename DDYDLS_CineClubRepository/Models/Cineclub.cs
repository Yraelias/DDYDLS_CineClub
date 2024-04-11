using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDYDLS_CineClubDAL.Models
{
    public class Cineclub
    {
        public int Id_Cineclub { get; set; }
        public int Id_Movie_1 { get; set; }
        public int Id_Movie_2 { get; set; }
        public int Id_Movie_3 { get; set; }
        public int Id_Movie_4 { get; set; }
        public int Id_Movie_5 { get; set; }
        public int NumberOfCineclub { get; set; }
        public DateTime Begin {  get; set; }
        public DateTime End { get; set; }
        public string Title { get; set; }
    }
}
