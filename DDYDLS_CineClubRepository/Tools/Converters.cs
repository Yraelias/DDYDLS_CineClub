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
        public static Genre GenreConvert(SqlDataReader reader)
        {
            return new Genre
            {
                Id_Genre = (int)reader["ID_Genre"],
                Name = reader["Name"].ToString()
            };
        }
        public static Person PersonConvert( SqlDataReader reader) 
        {
            return new Person
            {
                Id_Person = (int)reader["Id_Person"],
                Name = reader["Name"].ToString(),
                FirstName = reader["Name"].ToString(),
                Country = reader["Country"].ToString()
            };
        }
        public static Role RoleConvert(SqlDataReader reader)
        {
            return new Role
            {
                Id_Role = (int)reader["Id_Role"],
                Name = reader["Name"].ToString()
            };
        }
        public static Studio StudioConvert(SqlDataReader reader)
        {
            return new Studio
            {
                Id_Studio = (int)reader["Id_Studio"],
                Name = reader["Name"].ToString(),
                Country = (int)reader["Id_Country"]
            };
        }
        public static Movie MovieConvert(SqlDataReader reader)
        {
            return new Movie
            {
                Id_Movie = (int)reader["Id_Movie"],
                Name = reader["Name"].ToString(),
                Id_Studio = (int)reader["Id_Studio"],
                Synopsis = reader["Synopsis"].ToString(),
                Year = (int)reader["Year"]
            };
        }
    }
}
