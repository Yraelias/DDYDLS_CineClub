﻿using dal = DDYDLS_CineClubDAL.Models;

namespace DDYDLS_CineClubLocalModel.Tools
{
    public static class  LocalMappers
    {
       
       
        public static Models.User toLocal(this dal.User newUser)
        {
            return new Models.User
            {
                ID_User = newUser.ID_User,
                Login = newUser.Login,
                Password = newUser.Password,
                Email = newUser.Email,
                Username = newUser.Username,
                Language = newUser.Language,
                Country = newUser.Country,
                IsActive = newUser.IsActive,
                Registration_Date = newUser.Registration_Date,
                IsAdministrator = newUser.IsAdministrator
            };
        }
        public static dal.User toDal (this Models.User newUser)
        {
            return new dal.User
            {
                ID_User = newUser.ID_User,
                Login = newUser.Login,
                Password = newUser.Password,
                Email = newUser.Email,
                Username = newUser.Username,
                Language = newUser.Language,
                Country = newUser.Country,
                IsActive = newUser.IsActive,
                Registration_Date = newUser.Registration_Date,
                IsAdministrator = newUser.IsAdministrator
            };
        }
        public static Models.Genre toLocal(this dal.Genre newGenre)
        {
            return new Models.Genre
            {
                ID_Genre = newGenre.Id_Genre,
                Name  = newGenre.Name
            };
        }
        public static dal.Genre toDal(this Models.Genre newGenre)
        {
            return new dal.Genre
            {
                Id_Genre = newGenre.ID_Genre, 
                Name = newGenre.Name
            };
        }
    }
}
