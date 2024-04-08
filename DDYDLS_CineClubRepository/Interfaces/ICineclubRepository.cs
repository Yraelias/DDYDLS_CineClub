using System;
using System.Collections.Generic;
using System.Text;

namespace DDYDLS_CineClubDAL.Interfaces
{
    public interface ICineclubRepository<Cineclub>
    {
        IEnumerable<Cineclub> GetAll();
        Cineclub GetOne(int Id);
        void Insert(Cineclub g);
        void Update(Cineclub g);
        bool Delete(int Id);
    }
}
