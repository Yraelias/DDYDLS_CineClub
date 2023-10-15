﻿using DDYDLS_CineClubDAL.Interfaces;
using DDYDLS_CineClubDAL.Models;
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
        public static Models.Person toLocal(this dal.Person newPerson)
        {
            return new Models.Person
            {
                Id_Person = newPerson.Id_Person,
                Name = newPerson.Name,
                Country = newPerson.Country,
                FirstName = newPerson.FirstName
            };
        }
        public static dal.Person toDal(this Models.Person newPerson)
        {
            return new dal.Person
            {
                Id_Person = newPerson.Id_Person,
                Name = newPerson.Name,
                Country = newPerson.Country,
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
        public static Models.Studio toLocal(this dal.Studio newStudio)
        {
            return new Models.Studio
            {
                Id_Studio = newStudio.Id_Studio,
                Name = newStudio.Name,
                Country = newStudio.Country
            };
        }
        public static dal.Studio toDal(this Models.Studio newStudio)
        {
            return new dal.Studio
            {
                Id_Studio = newStudio.Id_Studio,
                Name = newStudio.Name,
                Country = newStudio.Country
            };
        }
        public static Models.Movie toLocal(this dal.Movie newMovie, IStudioRepository<dal.Studio> studioRepository, IRatingRepository<dal.Rating> ratingRepository)
        {
            return new Models.Movie
            {
                Id_Movie = newMovie.Id_Movie,
                Name = newMovie.Name,
                Id_Studio = newMovie.Id_Studio,
                Synopsis = newMovie.Synopsis,
                Year = newMovie.Year,
                Studio = studioRepository.GetOne(newMovie.Id_Studio).toLocal(),     
                Rating = ratingRepository.GetOne(newMovie.Id_Movie).toLocal()
            };
        }
        public static dal.Movie toDal(this Models.Movie newStudio)
        {
            return new dal.Movie
            {
                Id_Movie = newStudio.Id_Movie,
                Id_Studio = newStudio.Id_Studio,
                Name = newStudio.Name,
                Synopsis = newStudio.Synopsis,
                Year = newStudio.Year
            };
        }
        public static Models.Rating toLocal(this dal.Rating newRating)
        {
            return new Models.Rating
            {
               Id_Rating = newRating.Id_Rating,
               Id_Movie = newRating.Id_Movie,
               Id_User = newRating.Id_User,
               Date = newRating.Date
            };
        }
        public static dal.Rating toDal(this Models.Rating newRating)
        {
            return new dal.Rating
            {
                Id_Rating = newRating.Id_Rating,
                Id_Movie = newRating.Id_Movie,
                Id_User = newRating.Id_User,
                Date = newRating.Date
            };
        }
    }
}
