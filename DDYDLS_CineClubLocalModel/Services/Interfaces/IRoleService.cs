using DDYDLS_CineClubLocalModel.Models;
using System.Collections.Generic;

namespace DDYDLS_CineClubLocalModel.Services.Interfaces
{
    public interface IRoleService
    {
        Role GetOne(int Id);
        IEnumerable<Role> GetAll();
        void Update(Role r);
        bool AddRole(Role r);
        bool Delete(int Id);
        
    }
}
