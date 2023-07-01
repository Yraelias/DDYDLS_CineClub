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
        public static model.Genre toLocal(this api.Genre newGenre)
        {
            return new model.Genre
            {
                ID_Genre = newGenre.ID_Genre,
                Name = newGenre.Name
            };
        }

        public static api.Genre toApi(this model.Genre newGenre)
        {
            return new api.Genre
            {
                ID_Genre = newGenre.ID_Genre,
                Name = newGenre.Name
            };
        }
        public static model.Person toLocal(this api.Person newPerson)
        {
            return new model.Person
            {
                Id_Person = newPerson.Id_Person, 
                Name = newPerson.Name,
                Country = newPerson.Country,
                FirstName = newPerson.FirstName
            };
        }

        public static api.Person toApi(this model.Person newPerson)
        {
            return new api.Person
            {
                Id_Person = newPerson.Id_Person,
                Name = newPerson.Name,
                Country = newPerson.Country,
                FirstName = newPerson.FirstName
            };
        }
        public static model.Role toLocal(this api.Role newRole)
        {
            return new model.Role
            {
                ID_Role = newRole.ID_Role,
                Name = newRole.Name
            };
        }

        public static api.Role toApi(this model.Role newRole)
        {
            return new api.Role
            {
                ID_Role = newRole.ID_Role,
                Name = newRole.Name
            };
        }


    }
}
