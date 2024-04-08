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
    public class RoleService : Interfaces.IRoleService
    {
        private IRoleRepository<dal.Role> _RoleRepository;
        public RoleService(IRoleRepository<dal.Role> RoleRepository)
        {
            _RoleRepository = RoleRepository;
        }

        public bool Delete(int Id)
        {
            return _RoleRepository.Delete(Id);
        }

        public IEnumerable<Role> GetAll()
        {
            return _RoleRepository.GetAll().Select(g => g.toLocal());
        }

        public Role GetOne(int Id)
        {
            return _RoleRepository.GetOne(Id).toLocal();
        }

        public bool AddRole(Role g)
        {
            
            _RoleRepository.Insert(g.toDal());

            return true;
        }

        public void Update(Role g)
        {
            _RoleRepository.Update(g.toDal());
        }
        
    }
}
