using DDYDLS_CineClubDAL.Interfaces;
using DDYDLS_CineClubDAL.Models;
using DDYDLS_CineClubDAL.Repository;
using Microsoft.VisualBasic;
using System;


#pragma warning disable CS8981 // Le nom de type contient uniquement des caractères ascii en minuscules. De tels noms peuvent devenir réservés pour la langue.
using dal = DDYDLS_CineClubDAL.Models;
#pragma warning restore CS8981 // Le nom de type contient uniquement des caractères ascii en minuscules. De tels noms peuvent devenir réservés pour la langue.

namespace DDYDLS_CineClubLocalModel.Tools
{
    public static class  LocalMappers
    {
        public static Models.User ToLocal(this dal.User newUser)
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
        public static dal.User ToDal (this Models.User newUser)
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
        
        public static Models.Movie ToLocal(this dal.Movie newMovie)
        {
            return new Models.Movie
            {
                Id_Movie = newMovie.Id_Movie,
                Name = newMovie.Name,
                Year = newMovie.Year
                

            };
        }
        public static Models.Movie ToLocal(this dal.Movie newMovie, IRatingRepository<dal.Ratings> ratingRepository)
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
        public static dal.Movie ToDal(this Models.Movie newStudio)
        {
            return new dal.Movie
            {
                Id_Movie = newStudio.Id_Movie,
                Name = newStudio.Name,
                Year = newStudio.Year,
                TMDB_ID = newStudio.TMDB_ID,
            };
        }
        public static Models.Ratings ToLocal(this dal.Ratings newRating)
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
        public static dal.Ratings ToDal(this Models.Ratings newRating)
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
        public static Models.Cineclub ToLocal(this dal.Cineclub newRating, IMovieRepository<dal.Movie> movieRepository)
        {
            return new Models.Cineclub
            {
                Id_Cineclub = newRating.Id_Cineclub,
                Movie_1 = movieRepository.GetOne(newRating.Id_Movie_1)?.ToLocal(),
                Movie_2 = movieRepository.GetOne(newRating.Id_Movie_2)?.ToLocal(),
                Movie_3 = movieRepository.GetOne(newRating.Id_Movie_3)?.ToLocal(),
                Movie_4 = movieRepository.GetOne(newRating.Id_Movie_4)?.ToLocal(),
                Movie_5 = newRating.Id_Movie_5.HasValue ? movieRepository.GetOne(newRating.Id_Movie_5.Value)?.ToLocal() : null,
                NumberOfCineclub = newRating.NumberOfCineclub,
                Begin = newRating.Begin,
                End = newRating.End ?? DateTime.MinValue,
                Title = newRating.Title
            };
        }
        public static dal.Cineclub ToDal(this Models.Cineclub newRating, string Add)
        {
            return new dal.Cineclub
            {
                Id_Cineclub = newRating.Id_Cineclub,
                Id_Movie_1 = newRating.Movie_1.Id_Movie,
                Id_Movie_2 = newRating.Movie_2.Id_Movie,
                Id_Movie_3 = newRating.Movie_3.Id_Movie,
                Id_Movie_4 = newRating.Movie_4.Id_Movie,
                Id_Movie_5 = newRating.Movie_5.Id_Movie,
                NumberOfCineclub = newRating.NumberOfCineclub,
                Begin = newRating.Begin,
                End = newRating.End,
                Title = newRating.Title
            };
        }
    }
}
