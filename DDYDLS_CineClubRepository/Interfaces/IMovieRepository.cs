using System;
using System.Collections.Generic;
using System.Text;

namespace DDYDLS_CineClubDAL.Interfaces
{
    public interface IMovieRepository<Movie>
    {
        IEnumerable<Movie> GetAll();
        Movie GetOne(int Id);
        void Insert(Movie m);
        void Update(Movie m);
        bool Delete(int Id);
    }
}
