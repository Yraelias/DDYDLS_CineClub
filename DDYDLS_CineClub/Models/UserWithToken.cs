﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDYDLS_CineClubApi.Models
{
    public class UserWithToken
    {
        public int ID_User { get; set; }
        public string Token { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public bool IsActive { get; set; }
        public DateTime Registration_Date { get; set; }
        public bool IsAdministrator { get; set; }
        public bool isModerator { get; set; }
    }
}
