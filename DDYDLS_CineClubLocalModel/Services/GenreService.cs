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
    public class GenreService : Interfaces.IGenreService
    {
        private IGenreRepository<dal.Genre> _genreRepository;
        public GenreService(IGenreRepository<dal.Genre> genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public bool Delete(int Id)
        {
            return _genreRepository.Delete(Id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return _genreRepository.GetAll().Select(g => g.toLocal());
        }

        public Genre GetOne(int Id)
        {
            return _genreRepository.GetOne(Id).toLocal();
        }

        public bool AddGenre(Genre g)
        {
            
            _genreRepository.Insert(g.toDal());

            return true;
        }

        public void Update(Genre g)
        {
            _genreRepository.Update(g.toDal());
        }
        
    }
}
