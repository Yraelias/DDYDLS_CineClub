﻿using DDYDLS_CineClubDAL.Interfaces;
using DDYDLS_CineClubDAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DDYDLS_CineClubDAL.Repository
{
    public class RatingRepository : CineclubContext, IRatingRepository<Ratings>
    {
        private readonly CineclubContext _dbContext;
        public RatingRepository(IConfiguration config, CineclubContext dbContext) : base(config)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Ratings> GetAll()
        {
            return _dbContext.T_Rating.ToList();
        }

        public Ratings GetOne(int Id)
        {
            return _dbContext.T_Rating.Find(Id);
        }

        public void Insert(Ratings g)
        {
            _dbContext.T_Rating.Add(g);
            _dbContext.SaveChanges();
        }

        public void Update(Ratings g)
        {
            _dbContext.T_Rating.Update(g);
            _dbContext.SaveChanges();
        }
        public bool Delete(int iD)
        {
            var ratingToDelete = _dbContext.T_Rating.Find(iD);
            if (ratingToDelete != null)
            {
                _dbContext.T_Rating.Remove(ratingToDelete);
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public int AvgRate(int iD)
        {
            var ratings = _dbContext.T_Rating
                           .Where(r => r.Id_Movie == iD)
                           .Select(r => r.Rating)
                           .ToList();
            if (ratings.Count == 0)
            {
                return 0;
            }
            return (int)ratings.Average();
        }

        public int RatebyIdMovieAndIdUser(int ID_Movie, int ID_User)
        {
            var ratings = _dbContext.T_Rating
                           .Where(r => r.Id_Movie == ID_Movie && r.ID_User == ID_User )
                           .Select(r => r.Rating)
                           .ToList();
            if (ratings.Count == 0)
            {
                return 0;
            }
            return (int)ratings.Average();
        }
        public IEnumerable<Ratings> RatingsbyIdMovie(int ID_Movie)
        {
            return _dbContext.T_Rating
                            .Where(r => r.Id_Movie == ID_Movie)
                            .ToList();
        }

        public IEnumerable<Ratings> RatingsbyUser(int ID_User) 
        {
            return _dbContext.T_Rating
                            .Where(r => r.ID_User == ID_User)
                            .ToList();
        }

        public IEnumerable<Ratings> RatingsbyUserbyYear(int ID_User, int Year)
        {
            return _dbContext.T_Rating
                             .Where(r => r.ID_User == ID_User && r.Date.Year == Year)
                             .ToList();
        }

        public IEnumerable<Ratings> RatingsbyUserbyMonth(int ID_User,int Month,int Year)
        {
            return _dbContext.T_Rating
                             .Where(r => r.ID_User == ID_User && r.Date.Year == Year && r.Date.Month == Month)
                             .ToList();
        }


    }
}
