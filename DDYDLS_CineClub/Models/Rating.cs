using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDYDLS_CineClubApi.Models
{
    public class Rating
    {
        public int Id_Rating { get;set; }
        public int Id_User { get; set; }
        public int Id_Movie { get; set; }
        public int Ratings { get; set; }

        public DateTime Date { get; set; }

        public int Approbate { get; set; }

        public string Commentary { get; set; }
    }
}
