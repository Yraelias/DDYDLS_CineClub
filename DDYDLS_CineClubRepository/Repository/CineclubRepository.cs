using DDYDLS_CineClubDAL.Interfaces;
using DDYDLS_CineClubDAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DDYDLS_CineClubDAL.Repository
{
    public class CineclubRepository : CineclubContext, ICineclubRepository<Cineclub>
    {
        private readonly CineclubContext _dbContext;
        public CineclubRepository(IConfiguration config, CineclubContext dbContext) : base(config)
        { _dbContext = dbContext; }
        public bool Delete(int Id)
        {
            var cineclubToDelete = _dbContext.T_Cineclub.Find(Id);
            if (cineclubToDelete != null)
            {
                _dbContext.T_Cineclub.Remove(cineclubToDelete);
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false; 
            }
        }

        public IEnumerable<Cineclub> GetAll()
        {
            return [.. _dbContext.T_Cineclub];
        }

        public Cineclub GetOne(int Id)
        {
            return _dbContext.T_Cineclub.Find(Id);
        }

        public void Insert(Cineclub g)
        {
            if (g.Id_Movie_5 == 0) g.Id_Movie_5 = 1;
            _dbContext.T_Cineclub.Add(g);
            _dbContext.SaveChanges();
        }

        public void Update(Cineclub g)
        {
            if (g.Id_Movie_5 == 0) g.Id_Movie_5 = 1;
            _dbContext.T_Cineclub.Update(g);
            _dbContext.SaveChanges();
        }
    }
}
