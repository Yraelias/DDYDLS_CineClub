using System;
using System.Collections.Generic;
using System.Text;

namespace DDYDLS_CineClubDAL.Interfaces
{
    public interface IStudioRepository<Studio>
    {
        IEnumerable<Studio> GetAll();
        Studio GetOne(int Id);
        void Insert(Studio s);
        void Update(Studio s);
        bool Delete(int Id);
    }
}
