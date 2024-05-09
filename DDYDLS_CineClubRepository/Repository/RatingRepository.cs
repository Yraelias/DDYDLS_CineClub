using ADO_Toolbox;
using DDYDLS_CineClubDAL.Interfaces;
using DDYDLS_CineClubDAL.Models;
using DAL.Tools;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DDYDLS_CineClubDAL.Repository
{
    public class RatingRepository : BaseRepository, IRatingRepository<Ratings>
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
            Command cmd = new Command("SELECT AVG (Rating) FROM [T_Rating] WHERE Id_Movie = @Id_Movie AND ID_User = @ID_User ");
            cmd.AddParameter("Id_Movie", ID_Movie);
            cmd.AddParameter("ID_User", ID_User);
            if (_connection.ExecuteScalar(cmd)  == null) return 10;
            else return (int)_connection.ExecuteScalar(cmd);
        }
        public IEnumerable<Ratings> RatingsbyIdMovie(int ID_Movie)
        {
            Command cmd = new Command("SELECT  T_User.Username, [Id_Movie], [Rating], [Date], [Commentary], [Approbate], [Id_Rating], [T_Rating].[ID_User] " +
                "FROM[DDYDLS_CineClubDb].[dbo].[T_Rating], [T_User] WHERE T_Rating.Id_Movie = @Id_Movie AND T_Rating.ID_User = T_User.ID_User");
            cmd.AddParameter("Id_Movie", ID_Movie);
            return _connection.ExecuteReader(cmd, Converters.RatingConvert);
        }

        public IEnumerable<Ratings> RatingsbyUser(int ID_User) 
        {
            Command cmd = new Command("SELECT TOP (1000) [ID_Rating], [ID_User], [Id_Movie], [Rating], [Date], [Commentary], [Approbate],'' AS Username " +
                "FROM[DDYDLS_CineClubDb].[dbo].[T_Rating] WHERE ID_User = @ID_User ORDER BY ID_Rating DESC");
            cmd.AddParameter("ID_User", ID_User);
            return _connection.ExecuteReader(cmd, Converters.RatingConvert);
        }

        public IEnumerable<Ratings> RatingsbyUserbyYear(int ID_User, int Year)
        {
            Command cmd = new Command("SELECT TOP (1000) [ID_Rating], [ID_User], [Id_Movie], [Rating], [Date], [Commentary], [Approbate],'' AS Username " +
                "FROM[DDYDLS_CineClubDb].[dbo].[T_Rating] WHERE ID_User = @ID_User AND YEAR([Date]) = @Year ORDER BY ID_Rating DESC");
            cmd.AddParameter("ID_User", ID_User);
            cmd.AddParameter("Year", Year);
            return _connection.ExecuteReader(cmd, Converters.RatingConvert);
        }

        public IEnumerable<Ratings> RatingsbyUserbyMonth(int ID_User,int Month,int Year)
        {
            Command cmd = new Command("SELECT TOP (1000) [ID_Rating], [ID_User], [Id_Movie], [Rating], [Date], [Commentary], [Approbate],'' AS Username " +
                "FROM[DDYDLS_CineClubDb].[dbo].[T_Rating] WHERE ID_User = @ID_User AND MONTH([Date]) = @Month AND YEAR([Date]) = @Year " +
                "ORDER BY ID_Rating DESC");
            cmd.AddParameter("ID_User", ID_User);
            cmd.AddParameter("Month", Month);
            cmd.AddParameter("Year", Year);
            return _connection.ExecuteReader(cmd, Converters.RatingConvert);
        }


    }
}
