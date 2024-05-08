﻿using DDYDLS_CineClubDAL.Interfaces;
using DDYDLS_CineClubDAL.Models;
using DDYDLS_CineClubDAL.Repository;
#pragma warning disable CS8981 // Le nom de type contient uniquement des caractères ascii en minuscules. De tels noms peuvent devenir réservés pour la langue.
using dal = DDYDLS_CineClubDAL.Models;
#pragma warning restore CS8981 // Le nom de type contient uniquement des caractères ascii en minuscules. De tels noms peuvent devenir réservés pour la langue.

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
                IsActive = newUser.IsActive,
                Registration_Date = newUser.Registration_Date
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
                IsActive = newUser.IsActive,
                Registration_Date = newUser.Registration_Date
            };
        }
        public static Models.Person toLocal(this dal.Person newPerson)
        {
            return new Models.Person
            {
                Id_Person = newPerson.Id_Person,
                Name = newPerson.Name,
                FirstName = newPerson.FirstName
            };
        }
        public static dal.Person toDal(this Models.Person newPerson)
        {
            return new dal.Person
            {
                Id_Person = newPerson.Id_Person,
                Name = newPerson.Name,
                FirstName = newPerson.FirstName
            };
        }
        public static Models.Role toLocal(this dal.Role newRole)
        {
            return new Models.Role
            {
                ID_Role = newRole.Id_Role,
                Name = newRole.Name
            };
        }
        public static dal.Role toDal(this Models.Role newRole)
        {
            return new dal.Role
            {
                Id_Role = newRole.ID_Role,
                Name = newRole.Name
            };
        }
        
        public static Models.Movie toLocal(this dal.Movie newMovie)
        {
            return new Models.Movie
            {
                Id_Movie = newMovie.Id_Movie,
                Name = newMovie.Name,
                Year = newMovie.Year
                

            };
        }
        public static Models.Movie toLocal(this dal.Movie newMovie, IRatingRepository<dal.Rating> ratingRepository)
        {
            return new Models.Movie
            {
                Id_Movie = newMovie.Id_Movie,
                Name = newMovie.Name,
                Year = newMovie.Year,
                Rating = null,
                AvgRating = ratingRepository.AvgRate(newMovie.Id_Movie),
                TMDB_ID = newMovie.TMDB_ID
            };
        }
        public static dal.Movie toDal(this Models.Movie newStudio)
        {
            return new dal.Movie
            {
                Id_Movie = newStudio.Id_Movie,
                Name = newStudio.Name,
                Year = newStudio.Year,
                TMDB_ID = newStudio.TMDB_ID,
            };
        }
        public static Models.Rating toLocal(this dal.Rating newRating)
        {
            if (newRating == null) { return new Models.Rating(); }
            return new Models.Rating
            {
               Id_Rating = newRating.Id_Rating ,
               Id_Movie = newRating.Id_Movie,
               ID_User = newRating.ID_User,
               Date = newRating.Date,
               Ratings = newRating.Ratings,
               Commentary = newRating.Commentary,
               Approbate = newRating.Approbate,
               Username = newRating.Username,
            };
        }
        public static dal.Rating toDal(this Models.Rating newRating)
        {
            return new dal.Rating
            {
                Id_Rating = newRating.Id_Rating,
                Id_Movie = newRating.Id_Movie,
                ID_User = newRating.ID_User,
                Date = newRating.Date,
                Ratings = newRating.Ratings,
                Commentary = newRating.Commentary,
                Approbate = newRating.Approbate,
                Username=newRating.Username,
            };
        }
        public static Models.Cineclub toLocal(this dal.Cineclub newRating, IMovieRepository<dal.Movie> movieRepository)
        {
            return new Models.Cineclub
            {
                Id_Cineclub = newRating.Id_Cineclub,
                Movie_1 = movieRepository.GetOne(newRating.Id_Movie_1).toLocal(),
                Movie_2 = movieRepository.GetOne(newRating.Id_Movie_2).toLocal(),
                Movie_3 = movieRepository.GetOne(newRating.Id_Movie_3).toLocal(),
                Movie_4 = movieRepository.GetOne(newRating.Id_Movie_4).toLocal(),
                Movie_5 = movieRepository.GetOne(newRating.Id_Movie_5).toLocal(),
                NumberOfCineclub = newRating.NumberOfCineclub,
                Begin = newRating.Begin,
                End = newRating.End,
                Title = newRating.Title
            };
        }
        public static dal.Cineclub toDal(this Models.Cineclub newRating, string Add)
        {
            return new dal.Cineclub
            {
                Id_Cineclub = newRating.Id_Cineclub,
                Id_Movie_1 = newRating.Id_Movie_1,
                Id_Movie_2 = newRating.Id_Movie_2,
                Id_Movie_3 = newRating.Id_Movie_3,
                Id_Movie_4 = newRating.Id_Movie_4,
                Id_Movie_5 = newRating.Id_Movie_5,
                NumberOfCineclub = newRating.NumberOfCineclub,
                Begin = newRating.Begin,
                End = newRating.End,
                Title = newRating.Title
            };
        }
    }
}
