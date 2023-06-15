using System;
using System.Collections.Generic;
using System.Text;

namespace DDYDLS_CineClubDAL.Interfaces
{
    public interface IGenreRepository<Genre>
    {
        IEnumerable<Genre> GetAll();
        Genre GetOne(int Id);
        void Insert(Genre g);
        void Update(Genre g);
        bool Delete(int Id);
    }
}
