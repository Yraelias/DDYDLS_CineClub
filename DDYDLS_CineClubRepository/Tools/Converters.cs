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
        public static Role RoleConvert(SqlDataReader reader)
        {
            return new Role
            {
                Id_Role = (int)reader["Id_Role"],
                Name = reader["Name"].ToString()
            };
        }
        public static Ratings RatingConvert(SqlDataReader reader)
        {
            return new Ratings
            {
                Id_Rating = Convert.IsDBNull((int)reader["Id_Rating"]) ? 0 : (int)reader["Id_Rating"],
                ID_User = Convert.IsDBNull((int)reader["ID_User"]) ? 0 : (int)reader["ID_User"],
                Id_Movie = Convert.IsDBNull((int)reader["Id_Movie"]) ? 0 : (int)reader["Id_Movie"],
                Rating = Convert.IsDBNull((int)reader["Rating"]) ? 0 : (int)reader["Rating"],
                Date = Convert.IsDBNull((DateTime)reader["Date"]) ? new DateTime() : (DateTime)reader["Date"],
                Approbate = Convert.IsDBNull((int)reader["Approbate"]) ? 0 : (int)reader["Approbate"],
                Commentary = reader["Commentary"].ToString()
            };
        }
    }
}
