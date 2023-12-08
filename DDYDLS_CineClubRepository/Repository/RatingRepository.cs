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
            Command cmd = new Command("INSERT INTO [dbo].[T_Rating] ([Id_User],[Id_Movie],[Rating],[Date]) VALUES (@Id_User,@Id_Movie,@Rating,@Date)");
            cmd.AddParameter("Id_User", g.Id_User);
            cmd.AddParameter("Id_Movie",g.Id_Movie);
            cmd.AddParameter("Rating",g.Ratings);
            if (g.Date == null)
            {
                g.Date = DateTime.Now;
            }
            cmd.AddParameter("Date",g.Date);
            _connection.ExecuteNonQuery(cmd);
        }

        public void Update(Rating g)
        {
            Command cmd = new Command("UPDATE [dbo].[T_Rating] SET ([Id_User] = Id_User,[Id_Movie] = Id_Movie,[Rating] = Rating,[Date] = Date) WHERE ID_Rating = @Id_Rating");
            cmd.AddParameter("Id_Rating", g.Id_Rating);
            cmd.AddParameter("Id_User", g.Id_User);
            cmd.AddParameter("Id_Movie", g.Id_Movie);
            cmd.AddParameter("Rating", g.Ratings);
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
            return (int)_connection.ExecuteScalar(cmd);
        }

        public int RatebyIdMovieAndIdUser(int ID_Movie, int ID_User)
        {
            Command cmd = new Command("SELECT AVG (Rating) FROM [T_Rating] WHERE Id_Movie = @Id_Movie AND Id_User = @Id_User ");
            cmd.AddParameter("Id_Movie", ID_Movie);
            cmd.AddParameter("Id_User", ID_User);
            return (int)_connection.ExecuteScalar(cmd);
        }
    }
}