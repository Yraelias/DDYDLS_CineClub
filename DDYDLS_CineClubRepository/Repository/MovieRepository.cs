using ADO_Toolbox;
using DDYDLS_CineClubDAL.Interfaces;
using DDYDLS_CineClubDAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static DDYDLS_CineClubDAL.Repository.CineclubContext;


namespace DDYDLS_CineClubDAL.Repository
{
    public class MovieRepository : BaseRepository, IMovieRepository<Movie>
    {
        private readonly CineclubContext _dbContext;
        public MovieRepository(IConfiguration config, CineclubContext dbContext) : base(config)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Movie> GetAll()
        {
           return _dbContext.T_Movie.ToList();
        }

        public Movie GetOne(int Id)
        {
            return _dbContext.T_Movie.Find(Id);
        }

        public void Insert(Movie g)
        {
            _dbContext.Add(g);
            _dbContext.SaveChanges();
        }

        public void Update(Movie g)
        {
            _dbContext.T_Movie.Update(g);
            _dbContext.SaveChanges();
        }
        public bool Delete(int iD)
        {
            var movieToDelete = _dbContext.T_Movie.Find(iD);
            if (movieToDelete != null)
            {
                _dbContext.T_Movie.Remove(movieToDelete);
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false; // L'élément avec l'ID spécifié n'existe pas dans la base de données
            }
        }

        public Movie GetOnewithTMBD(int IdTMDB)
        {
            return _dbContext.T_Movie.FirstOrDefault(m => m.TMDB_ID == IdTMDB);
        }

    }
}
