using IdentityServer4.Models;
using DDYDLS_CineClubLocalModel.Services.Interfaces;
using DDYDLS_CineClubLocalModel.Models;
using DDYDLS_CineClubLocalModel.Tools;
using System.Collections.Generic;
using System.Linq;
using dal = DDYDLS_CineClubDAL.Models;
using System;
using DDYDLS_CineClubDAL.Interfaces;

namespace DDYDLS_CineClubLocalModel.Services
{
    public class MovieService : Interfaces.IMovieService
    {
        private IMovieRepository<dal.Movie> _MovieRepository;
        public MovieService(IMovieRepository<dal.Movie> MovieRepository)
        {
            _MovieRepository = MovieRepository;
        }

        public bool Delete(int Id)
        {
            return _MovieRepository.Delete(Id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return _MovieRepository.GetAll().Select(g => g.toLocal());
        }

        public Movie GetOne(int Id)
        {
            return _MovieRepository.GetOne(Id).toLocal();
        }

        public bool AddMovie(Movie g)
        {
            
            _MovieRepository.Insert(g.toDal());

            return true;
        }

        public void Update(Movie g)
        {
            _MovieRepository.Update(g.toDal());
        }
        
    }
}
