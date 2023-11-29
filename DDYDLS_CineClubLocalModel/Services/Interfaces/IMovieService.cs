using DDYDLS_CineClubLocalModel.Models;
using System.Collections.Generic;

namespace DDYDLS_CineClubLocalModel.Services.Interfaces
{
    public interface IMovieService
    {
        Movie GetOne(int Id);
        IEnumerable<Movie> GetAll();
        void Update(Movie m);
        bool AddMovie(Movie m);
        bool Delete(int Id);


    }
}
