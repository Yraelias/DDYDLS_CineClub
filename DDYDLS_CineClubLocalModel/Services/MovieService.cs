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
        private IRatingRepository<dal.Rating> _ratingRepo;
        public MovieService(IMovieRepository<dal.Movie> MovieRepository, IRatingRepository<dal.Rating> ratingRepo)
        {
            _MovieRepository = MovieRepository;
            _ratingRepo = ratingRepo;
        }

        public bool Delete(int Id)
        {
            return _MovieRepository.Delete(Id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return _MovieRepository.GetAll().Select(g => g.toLocal());
        }

        public Movie GetOne(int userId, int Id)
        {
            Movie movie = new Movie();
            movie = _MovieRepository.GetOne(Id).toLocal(_ratingRepo);
            movie.RatingForUser = _ratingRepo.RatebyIdMovieAndIdUser(Id, userId);
            return movie;
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
        /*
        public int GetRatingForOneUser(int movieId, int userId)
        {
            return _ratingRepo.RatebyIdMovieAndIdUser(movieId, userId);
        }
        */
    }
}
