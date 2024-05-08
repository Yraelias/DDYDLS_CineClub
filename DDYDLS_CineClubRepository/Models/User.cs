using System;

namespace DDYDLS_CineClubDAL.Models
{
    public class User
    {
        public int ID_User { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public DateTime Registration_Date { get; set; }
        public int UserRole { get; set; }
    }
}
