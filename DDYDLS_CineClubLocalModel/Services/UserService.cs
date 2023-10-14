using IdentityServer4.Models;
using DDYDLS_CineClubLocalModel.Services.Interfaces;
using DDYDLS_CineClubLocalModel.Models;
using DDYDLS_CineClubLocalModel.Tools;
using System.Collections.Generic;
using System.Linq;
#pragma warning disable CS8981 // Le nom de type contient uniquement des caractères ascii en minuscules. De tels noms peuvent devenir réservés pour la langue.
using dal = DDYDLS_CineClubDAL.Models;
#pragma warning restore CS8981 // Le nom de type contient uniquement des caractères ascii en minuscules. De tels noms peuvent devenir réservés pour la langue.
using System;
using DDYDLS_CineClubDAL.Interfaces;

namespace DDYDLS_CineClubLocalModel.Services
{
    public class UserService : Interfaces.IUserService
    {
        private IUserRepository<dal.User> _userRepository;
        public UserService(IUserRepository<dal.User> userRepository)
        {
            _userRepository = userRepository;
        }

        public bool checkIfModerator(int Id)
        {
            throw new System.NotImplementedException();
        }

        public bool checkIfPlayer(int Id)
        {
            throw new System.NotImplementedException();
        }

        public bool? CheckUser(User u)
        {
            u.Password = u.Password.Sha256();
            bool? reponse = _userRepository.CheckUser(u.toDal());

            return reponse;
        }

        public bool Delete(int Id)
        {
            return _userRepository.Delete(Id);
        }

        public bool Desactive(int Id)
        {
            return _userRepository.DesactiveUser(Id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll().Select(x => x.toLocal());
        }

        public User GetByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public User GetOne(int Id)
        {
            throw new System.NotImplementedException();
        }

        public bool RegistrationUser(User m)
        {
            
            m.Registration_Date = DateTime.Now;
            m.Password = m.Password.Sha256();

            _userRepository.Insert(m.toDal());

            return true;
        }

        public void Update(User m)
        {
            _userRepository.Update(m.toDal());
        }
        
    }
}
