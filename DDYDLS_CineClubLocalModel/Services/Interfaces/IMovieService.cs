using DDYDLS_CineClubDAL.Models;
using DDYDLS_CineClubLocalModel.Models;
using System.Collections.Generic;
using Movie = DDYDLS_CineClubLocalModel.Models.Movie;

namespace DDYDLS_CineClubLocalModel.Services.Interfaces
{
    public interface IMovieService
    {
        Movie GetOne(int movieId,int Id);
        Movie GetOnevisitor(int Id);
        IEnumerable<Movie> GetAll();
        void Update(Movie m);
        bool AddMovie(Movie m);
        bool Delete(int Id);

        //int GetRatingForOneUser(int movieId, int userId);

    }
}
