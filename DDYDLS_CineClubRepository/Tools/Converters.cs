using DDYDLS_CineClubDAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DAL.Tools
{
    public static class Converters
    {
        
        public static User UserConvert(SqlDataReader reader)
        {
            return new User
            {
                ID_User = (int)reader["ID_User"],
                Username = (string)reader["Username"],
                Password = reader["Password"].ToString(),
                Email = reader["Email"].ToString(),
                IsActive = (bool)reader["isActive"],
                Registration_Date = (DateTime)reader["Registration_Date"],
                UserRole = (int)reader["ID_UserRole"]
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
        
        public static Movie MovieConvert(SqlDataReader reader)
        {
            return new Movie
            {
                Id_Movie = (int)reader["Id_Movie"],
                Name = reader["Name"].ToString(),
                Year = (int)reader["Year"],
                TMDB_ID = (int)reader["TMDB_ID"]
            };
        }
        public static Rating RatingConvert(SqlDataReader reader)
        {
            return new Rating
            {
                Id_Rating = Convert.IsDBNull((int)reader["Id_Rating"]) ? 0 : (int)reader["Id_Rating"],
                ID_User = Convert.IsDBNull((int)reader["ID_User"]) ? 0 : (int)reader["ID_User"],
                Id_Movie = Convert.IsDBNull((int)reader["Id_Movie"]) ? 0 : (int)reader["Id_Movie"],
                Ratings = Convert.IsDBNull((int)reader["Rating"]) ? 0 : (int)reader["Rating"],
                Date = Convert.IsDBNull((DateTime)reader["Date"]) ? new DateTime() : (DateTime)reader["Date"],
                Approbate = Convert.IsDBNull((int)reader["Approbate"]) ? 0 : (int)reader["Approbate"],
                Commentary = reader["Commentary"].ToString(),
                Username = reader["Username"].ToString() 
            };
        }
        public static Cineclub CineclubConvert(SqlDataReader reader)
        {
            return new Cineclub
            {
                Id_Cineclub = Convert.IsDBNull((int)reader["Id_Cineclub"]) ? 0 : (int)reader["Id_Cineclub"],
                Id_Movie_1 = Convert.IsDBNull((int)reader["Id_Movie_1"]) ? 0 : (int)reader["Id_Movie_1"],
                Id_Movie_2 = Convert.IsDBNull((int)reader["Id_Movie_2"]) ? 0 : (int)reader["Id_Movie_2"],
                Id_Movie_3 = Convert.IsDBNull((int)reader["Id_Movie_3"]) ? 0 : (int)reader["Id_Movie_3"],
                Id_Movie_4 = Convert.IsDBNull((int)reader["Id_Movie_4"]) ? 0 : (int)reader["Id_Movie_4"],
                Id_Movie_5 = Convert.IsDBNull((int)reader["Id_Movie_5"]) ? 0 : (int)reader["Id_Movie_5"],
                NumberOfCineclub = Convert.IsDBNull((int)reader["NumberOfCineclub"]) ? 0 : (int)reader["NumberOfCineclub"],
                Begin = Convert.IsDBNull((DateTime)reader["Begin"]) ? new DateTime() : (DateTime)reader["Begin"],
                End  =  Convert.IsDBNull((DateTime)reader["End"]) ? new DateTime() : (DateTime)reader["End"],
                Title = reader["Title"].ToString()
            };
        }
    }
}
