using System;

#pragma warning disable CS8981 // Le nom de type contient uniquement des caractères ascii en minuscules. De tels noms peuvent devenir réservés pour la langue.
using api = DDYDLS_CineClubApi.Models;
#pragma warning restore CS8981 // Le nom de type contient uniquement des caractères ascii en minuscules. De tels noms peuvent devenir réservés pour la langue.
#pragma warning disable CS8981 // Le nom de type contient uniquement des caractères ascii en minuscules. De tels noms peuvent devenir réservés pour la langue.
using model = DDYDLS_CineClubLocalModel.Models;
#pragma warning restore CS8981 // Le nom de type contient uniquement des caractères ascii en minuscules. De tels noms peuvent devenir réservés pour la langue.

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
        public static model.Movie toLocal(this api.Movie newMovie)
        {
            return new model.Movie
            {
                Id_Movie = newMovie.Id_Movie,
                Name = newMovie.Name,
                Id_Studio = newMovie.Id_Studio,
                Synopsis = newMovie.Synopsis,
                Year = newMovie.Year
            };
        }
        public static api.Movie toApi(this model.Movie newMovie)
        {
            return new api.Movie
            {
                Id_Movie = newMovie.Id_Movie,
                Name = newMovie.Name,
                Id_Studio = newMovie.Id_Studio,
                Synopsis = newMovie.Synopsis,
                Year = newMovie.Year,
                RatingForUser = newMovie.RatingForUser

            };
        }

        public static model.Rating toLocal(this api.Rating newMovie)
        {
            return new model.Rating
            {
                Id_Movie = newMovie.Id_Movie,
                Id_Rating = newMovie.Id_Rating,
                Id_User = newMovie.Id_User, 
                Ratings = newMovie.Ratings,
                Date = newMovie.Date ,
                Commentary = newMovie.Commentary,
                Approbate = newMovie.Approbate
    };
        }
        public static api.Rating toApi(this model.Rating newMovie)
        {
            return new api.Rating
            {
                Id_Movie = newMovie.Id_Movie,
                Id_Rating = newMovie.Id_Rating,
                Id_User = newMovie.Id_User,
                Ratings = newMovie.Ratings,
                Date = newMovie.Date,
                Commentary = newMovie.Commentary,
                Approbate = newMovie.Approbate

            };
        }

    }
}
