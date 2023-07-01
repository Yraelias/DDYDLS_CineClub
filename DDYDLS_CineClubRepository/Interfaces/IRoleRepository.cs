using System;
using System.Collections.Generic;
using System.Text;

namespace DDYDLS_CineClubDAL.Interfaces
{
    public interface IRoleRepository<Role>
    {
        IEnumerable<Role> GetAll();
        Role GetOne(int Id);
        void Insert(Role r);
        void Update(Role r);
        bool Delete(int Id);
    }
}
