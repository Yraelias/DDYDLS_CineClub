using ADO_Toolbox;
using DDYDLS_CineClubDAL.Interfaces;
using DDYDLS_CineClubDAL.Models;
using DAL.Tools;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDYDLS_CineClubDAL.Repository
{
    public class CineclubRepository : BaseRepository, ICineclubRepository<Cineclub>
    {
        public CineclubRepository(IConfiguration config) : base(config)
        { }
        public bool Delete(int Id)
        {
            Command cmd = new Command("DELETE FROM [dbo].[T_Cineclub] WHERE ID_Genre = @Id ");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<Cineclub> GetAll()
        {
            Command cmd = new Command("SELECT * FROM [T_Cineclub]");
            return _connection.ExecuteReader(cmd, Converters.CineclubConvert);
        }

        public Cineclub GetOne(int Id)
        {
            Command cmd = new Command("SELECT * FROM [T_Cineclub] WHERE ID_Genre = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteReader(cmd, Converters.CineclubConvert).FirstOrDefault();
        }

        public void Insert(Cineclub g)
        {
            Command cmd = new Command("INSERT INTO [dbo].[T_Cineclub]([Id_Movie_1],[Id_Movie_2],[Id_Movie_3],[Id_Movie_4],[Id_Movie_5],[NumberOfCineclub],[Begin],[End],[Link_Yt]) " +
                                      "VALUES (@Id_Movie_1,@Id_Movie_2,@Id_Movie_3,@Id_Movie_4,@Id_Movie_5,@NumberOfCineclub,@Begin,@End,@Link_Yt) GO");
            cmd.AddParameter("Id_Movie_1", g.Id_Movie_1);
            cmd.AddParameter("Id_Movie_2", g.Id_Movie_2);
            cmd.AddParameter("Id_Movie_3", g.Id_Movie_3);
            cmd.AddParameter("Id_Movie_4", g.Id_Movie_4);
            cmd.AddParameter("Id_Movie_5", g.Id_Movie_5);
            cmd.AddParameter("NumberOfCineclub", g.NumberOfCineclub);
            cmd.AddParameter("Begin", g.Begin);
            cmd.AddParameter("End", g.End);
            cmd.AddParameter("Link_Yt", g.Link_Yt);
            _connection.ExecuteNonQuery(cmd);
        }

        public void Update(Cineclub g)
        {
            Command cmd = new Command("UPDATE [dbo].[T_Cineclub]([Id_Movie_1],[Id_Movie_2],[Id_Movie_3],[Id_Movie_4],[Id_Movie_5],[NumberOfCineclub],[Begin],[End],[Link_Yt]) " +
                                      "VALUES (@Id_Movie_1,@Id_Movie_2,@Id_Movie_3,@Id_Movie_4,@Id_Movie_5,@NumberOfCineclub,@Begin,@End,@Link_Yt) GO" +
                                      "WHERE @Id_Cineclub == @Id_Cineclub" );
            cmd.AddParameter("Id_Movie_1", g.Id_Movie_1);
            cmd.AddParameter("Id_Movie_2", g.Id_Movie_2);
            cmd.AddParameter("Id_Movie_3", g.Id_Movie_3);
            cmd.AddParameter("Id_Movie_4", g.Id_Movie_4);
            cmd.AddParameter("Id_Movie_5", g.Id_Movie_5);
            cmd.AddParameter("NumberOfCineclub", g.NumberOfCineclub);
            cmd.AddParameter("Begin", g.Begin);
            cmd.AddParameter("End", g.End);
            cmd.AddParameter("Link_Yt", g.Link_Yt);
            cmd.AddParameter("Id_Cineclub", g.Id_Cineclub);
            _connection.ExecuteNonQuery(cmd);
        }
    }
}
