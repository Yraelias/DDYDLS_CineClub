using System;

using api = DDYDLS_CineClubApi.Models;
using model = DDYDLS_CineClubLocalModel.Models;

namespace DDYDLS_CineClubApi.Tools
{
    public static class Mappers
    {
            
        public static model.User toModelUser(this api.UserCreate newuser)
        {
            return new model.User
            {
                Login = newuser.login,
                Email = newuser.email,
                Registration_Date = DateTime.Today,
                Password = newuser.password,
                IsActive = true,
                Username = newuser.username,
                IsAdministrator =false
            };
        }
            public static model.User toLocal (this api.User newUser)
        {
            return new model.User
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

        public static api.User toApi (this model.User newUser)
        {
            return new api.User
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

    }
}
