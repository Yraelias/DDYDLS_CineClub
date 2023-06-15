using DDYDLS_CineClubDAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Tools
{
    public static class Converters
    {
        
        public static User UserConvert(SqlDataReader reader)
        {
            return new User
            {
                ID_User = (int)reader["ID_User"],
                Login = reader["Login"].ToString(),
                Password = reader["Password"].ToString(),
                Email = reader["Email"].ToString(),
                Language = Convert.IsDBNull(reader["Language"]) ? null : reader["Language"].ToString(),
                Country = Convert.IsDBNull(reader["Country"]) ? null : reader["Country"].ToString(),
                IsActive = (bool)reader["isActive"],
                Registration_Date = (DateTime)reader["Registration_Date"],
                IsAdministrator = (bool)reader["IsAdministrator"],
                IsModerator = (bool)reader["IsModerator"]
            };
        }
    }
}
