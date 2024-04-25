﻿using ADO_Toolbox;
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
    public class RatingRepository : BaseRepository, IRatingRepository<Rating>
    {
        public RatingRepository(IConfiguration config) : base(config)
        { }

        public IEnumerable<Rating> GetAll()
        {
            Command cmd = new Command("SELECT * FROM [T_Rating]");
            return _connection.ExecuteReader(cmd, Converters.RatingConvert);
        }

        public Rating GetOne(int Id)
        {
            Command cmd = new Command("SELECT * FROM [T_Rating] WHERE ID_Rating = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteReader(cmd, Converters.RatingConvert).FirstOrDefault();
        }

        public void Insert(Rating g)
        {
            Command cmd = new Command("INSERT INTO [dbo].[T_Rating] ([ID_User],[Id_Movie],[Rating],[Commentary],[Approbate],[Date]) VALUES (@ID_User,@Id_Movie,@Rating,@Commentary,@Approbate,@Date)");
            cmd.AddParameter("ID_User", g.ID_User);
            cmd.AddParameter("Id_Movie",g.Id_Movie);
            cmd.AddParameter("Rating",g.Ratings);
            cmd.AddParameter("Commentary", g.Commentary);
            cmd.AddParameter("Approbate", g.Approbate);
            if (g.Date == null)
            {
                g.Date = DateTime.Now;
            }
            cmd.AddParameter("Date",g.Date);
            _connection.ExecuteNonQuery(cmd);
        }

        public void Update(Rating g)
        {
            Command cmd = new Command("UPDATE [dbo].[T_Rating] SET [Rating] = @Rating,[Date] = @Date, [Commentary] = @Commentary, [Approbate] = @Approbate  WHERE ID_User = @ID_User AND Id_Movie = @Id_Movie");
            cmd.AddParameter("Id_Rating", g.Id_Rating);
            cmd.AddParameter("ID_User", g.ID_User);
            cmd.AddParameter("Id_Movie", g.Id_Movie);
            cmd.AddParameter("Rating", g.Ratings);
            cmd.AddParameter("Commentary", g.Commentary);
            cmd.AddParameter("Approbate", g.Approbate);
            cmd.AddParameter("Date", g.Date);
            _connection.ExecuteNonQuery(cmd);
        }
        public bool Delete(int iD)
        {
            Command cmd = new Command("DELETE FROM [dbo].[T_Rating] WHERE ID_Rating = @Id ");
            cmd.AddParameter("Id", iD);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }
        public int AvgRate(int iD)
        {
            Command cmd = new Command("SELECT AVG (Rating) FROM [T_Rating] WHERE Id_Movie = @Id ");
            cmd.AddParameter("Id", iD);
            if (_connection.ExecuteScalar(cmd) == null) return 0;
            return (int)_connection.ExecuteScalar(cmd);
        }

        public int RatebyIdMovieAndIdUser(int ID_Movie, int ID_User)
        {
            object rep;
            Command cmd = new Command("SELECT AVG (Rating) FROM [T_Rating] WHERE Id_Movie = @Id_Movie AND ID_User = @ID_User ");
            cmd.AddParameter("Id_Movie", ID_Movie);
            cmd.AddParameter("ID_User", ID_User);
            if (_connection.ExecuteScalar(cmd)  == null) return 10;
            else return (int)_connection.ExecuteScalar(cmd);
        }
        public IEnumerable<Rating> RatingsbyIdMovie(int ID_Movie)
        {
            object rep;
            Command cmd = new Command("SELECT  T_User.Username, [Id_Movie], [Rating], [Date], [Commentary], [Approbate], [Id_Rating], [T_Rating].[ID_User] " +
                "FROM[DDYDLS_CineClubDb].[dbo].[T_Rating], [T_User] WHERE T_Rating.Id_Movie = @Id_Movie AND T_Rating.ID_User = T_User.ID_User");
            cmd.AddParameter("Id_Movie", ID_Movie);
            return _connection.ExecuteReader(cmd, Converters.RatingConvert);
        }

        public IEnumerable<Rating> RatingsbyUser(int ID_User) 
        {
            Command cmd = new Command("SELECT TOP (1000) [ID_Rating], [ID_User], [Id_Movie], [Rating], [Date], [Commentary], [Approbate],'' AS Username " +
                "FROM[DDYDLS_CineClubDb].[dbo].[T_Rating] WHERE ID_User = @ID_User ORDER BY ID_Rating DESC");
            cmd.AddParameter("ID_User", ID_User);
            return _connection.ExecuteReader(cmd, Converters.RatingConvert);
        }

        public IEnumerable<Rating> RatingsbyUserbyYear(int ID_User, int Year)
        {
            Command cmd = new Command("SELECT TOP (1000) [ID_Rating], [ID_User], [Id_Movie], [Rating], [Date], [Commentary], [Approbate],'' AS Username " +
                "FROM[DDYDLS_CineClubDb].[dbo].[T_Rating] WHERE ID_User = @ID_User AND YEAR([Date]) = @Year ORDER BY ID_Rating DESC");
            cmd.AddParameter("ID_User", ID_User);
            cmd.AddParameter("Year", Year);
            return _connection.ExecuteReader(cmd, Converters.RatingConvert);
        }

        public IEnumerable<Rating> RatingsbyUserbyMonth(int ID_User,int Month,int Year)
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
