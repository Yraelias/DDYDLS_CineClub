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
                Password = newUser.Password,
                Email = newUser.Email,
                Username = newUser.Username,
                IsActive = newUser.IsActive,
                Registration_Date = newUser.Registration_Date
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
        public static Models.Movie toLocal(this dal.Movie newMovie, IRatingRepository<dal.Ratings> ratingRepository)
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
        public static Models.Ratings toLocal(this dal.Ratings newRating)
        {
            if (newRating == null) { return new Models.Ratings(); }
            return new Models.Ratings
            {
               Id_Rating = newRating.Id_Rating ,
               Id_Movie = newRating.Id_Movie,
               ID_User = newRating.ID_User,
               Date = newRating.Date,
               Rating = newRating.Rating,
               Commentary = newRating.Commentary,
               Approbate = newRating.Approbate,
               Username = "Test"
            };
        }
        public static dal.Ratings toDal(this Models.Ratings newRating)
        {
            return new dal.Ratings
            {
                Id_Rating = newRating.Id_Rating,
                Id_Movie = newRating.Id_Movie,
                ID_User = newRating.ID_User,
                Date = newRating.Date,
                Rating = newRating.Rating,
                Commentary = newRating.Commentary,
                Approbate = newRating.Approbate
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
                //Movie_5 = movieRepository.GetOne(newRating.Id_Movie_5).toLocal(),
                NumberOfCineclub = newRating.NumberOfCineclub,
                Begin = newRating.Begin,
                //End = newRating.End,
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
