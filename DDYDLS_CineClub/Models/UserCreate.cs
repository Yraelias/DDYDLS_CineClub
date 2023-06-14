using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDYDLS_CineClubApi.Models
{
    public class UserCreate
    {
        public string email { get; set; }
        public string password { get; set; }
        public string login { get; set; }
        public string username { get; set; }
    }
}
