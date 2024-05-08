using System;
using System.ComponentModel.DataAnnotations;

namespace DDYDLS_CineClubDAL.Models
{
    public class User
    {
        [Required]
        public int ID_User { get; set; }
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public string Username { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public DateTime Registration_Date { get; set; }
        public int UserRole { get; set; }
    }
}
