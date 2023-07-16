using dal = DDYDLS_CineClubDAL.Models;

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
    }
}
