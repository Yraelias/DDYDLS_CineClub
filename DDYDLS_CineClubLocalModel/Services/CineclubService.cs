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

namespace DDYDLS_CineClubLocalModel.Services
{
    public class CineclubService : Interfaces.ICineclubService
    {
        private ICineclubRepository<dal.Cineclub> _CineclubRepository;
        private IMovieRepository<dal.Movie> _movieRepository;
        public CineclubService(ICineclubRepository<dal.Cineclub> CineclubRepository, IMovieRepository<dal.Movie> movieRepository)
        {
            _CineclubRepository = CineclubRepository;
            _movieRepository = movieRepository;
        }

        public bool Add(Cineclub g)
        {
            _CineclubRepository.Insert(g.toDal("Add"));
            return true;
        }

        public bool Delete(int Id)
        {
            return _CineclubRepository.Delete(Id);
        }

        public IEnumerable<Cineclub> GetAll()
        {
            return _CineclubRepository.GetAll().Select(g => g.toLocal(_movieRepository));
        }

        public Cineclub GetOne(int Id)
        {
            Cineclub cineclub = new Cineclub();
            cineclub = _CineclubRepository.GetOne(Id).toLocal(_movieRepository);
            return cineclub;
        }

        public void Update(Cineclub g)
        {
            _CineclubRepository.Update(g.toDal("Add"));
        }
    }
}
