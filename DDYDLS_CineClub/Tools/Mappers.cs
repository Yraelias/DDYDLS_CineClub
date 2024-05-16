using DDYDLS_CineClubLocalModel.Tools;
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
        public static model.Movie toLocal(this api.Movie newMovie)
        {
            return new model.Movie
            {
                Id_Movie = newMovie.Id_Movie,
                Name = newMovie.Name,
                Year = newMovie.Year,
                TMDB_ID = newMovie.TMDB_ID
            };
        }
        public static api.Movie toApi(this model.Movie newMovie)
        {
            return new api.Movie
            {
                Id_Movie = newMovie.Id_Movie,
                Name = newMovie.Name,
                Year = newMovie.Year,
                RatingForUser = newMovie.RatingForUser,
                TMDB_ID = newMovie.TMDB_ID
            };
        }

        public static model.Ratings toLocal(this api.Rating newMovie)
        {
            return new model.Ratings
            {
                Id_Movie = newMovie.Id_Movie,
                Id_Rating = newMovie.Id_Rating,
                ID_User = newMovie.ID_User, 
                Rating = newMovie.Ratings,
                Date = newMovie.Date ,
                Commentary = newMovie.Commentary,
                Approbate = newMovie.Approbate,
                Username = newMovie.Username,
    };
        }

        public static model.Cineclub toLocal(this api.Cineclub newCineclub)
        {
            return new model.Cineclub
            {
                Id_Cineclub = newCineclub.Id_Cineclub,
                Movie_1 = newCineclub.Movie_1.toLocal(),
                Movie_2 = newCineclub.Movie_2.toLocal(),
                Movie_3 = newCineclub.Movie_3.toLocal(),
                Movie_4 = newCineclub.Movie_4.toLocal(),
                Movie_5 = newCineclub.Movie_5.toLocal(),
                NumberOfCineclub = newCineclub.NumberOfCineclub,
                Begin = newCineclub.Begin,
                End = newCineclub.End,
                Title = newCineclub.Title
            };
        }
        public static model.Cineclub toLocal(this api.Cineclub newCineclub, string Add)   
        {
            return new model.Cineclub
            {
                Id_Cineclub = newCineclub.Id_Cineclub,
                Movie_1 = new model.Movie(),
                Movie_2 = new model.Movie(),
                Movie_3 = new model.Movie(),
                Movie_4 = new model.Movie(),
                Movie_5 = new model.Movie(),
                Id_Movie_1 = newCineclub.Id_Movie_1,
                Id_Movie_2 = newCineclub.Id_Movie_2,
                Id_Movie_3 = newCineclub.Id_Movie_3,
                Id_Movie_4 = newCineclub.Id_Movie_4,
                Id_Movie_5 = newCineclub.Id_Movie_5,
                NumberOfCineclub = newCineclub.NumberOfCineclub,
                Begin = newCineclub.Begin,
                End = newCineclub.End,
                Title = newCineclub.Title
            };
        }
    }
}
