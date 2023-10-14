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
using DDYDLS_CineClubDAL.Repository;

namespace DDYDLS_CineClubLocalModel.Services
{
    public class MovieService : Interfaces.IMovieService
    {
        private IMovieRepository<dal.Movie> _MovieRepository;
        private IStudioRepository<dal.Studio> _studioRepo;
        public MovieService(IMovieRepository<dal.Movie> MovieRepository, IStudioRepository<dal.Studio> studioRepository)
        {
            _MovieRepository = MovieRepository;
            _studioRepo = studioRepository;
        }

        public bool Delete(int Id)
        {
            return _MovieRepository.Delete(Id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return _MovieRepository.GetAll().Select(g => g.toLocal(_studioRepo));
        }

        public Movie GetOne(int Id)
        {
            return _MovieRepository.GetOne(Id).toLocal(_studioRepo);
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
