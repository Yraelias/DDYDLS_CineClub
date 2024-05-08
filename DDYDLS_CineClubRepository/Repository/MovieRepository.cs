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
    public class MovieRepository : BaseRepository, IMovieRepository<Movie>
    {
        
        public MovieRepository(IConfiguration config) : base(config)
        {
            
        }

        public IEnumerable<Movie> GetAll()
        {
            Command cmd = new Command("SELECT * FROM [T_Movie]");
            return _connection.ExecuteReader(cmd, Converters.MovieConvert);
        }

        public Movie GetOne(int Id)
        {
            Command cmd = new Command("SELECT * FROM [T_Movie] WHERE ID_Movie = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteReader(cmd, Converters.MovieConvert).FirstOrDefault();
        }

        public void Insert(Movie g)
        {
            Command cmd = new Command("INSERT INTO [dbo].[T_Movie] ([Name],[Year],[TMDB_Id]) VALUES (@Name,@Year,@TMDB_Id)");
            cmd.AddParameter("Name", g.Name);
            cmd.AddParameter("Year", g.Year);
            cmd.AddParameter("TMDB_Id", g.TMDB_ID);
            _connection.ExecuteNonQuery(cmd);
        }

        public void Update(Movie g)
        {
            Command cmd = new Command("UPDATE [dbo].[T_Movie] SET[Name] = @Name,[Id_Studio] = @Id_Studio,[Year] = @Year WHERE ID_Movie = @Id");
            cmd.AddParameter("Name", g.Name);
            cmd.AddParameter("Year", g.Year);
            _connection.ExecuteNonQuery(cmd);
        }
        public bool Delete(int iD)
        {
            Command cmd = new Command("DELETE FROM [dbo].[T_Movie] WHERE ID_Movie = @Id ");
            cmd.AddParameter("Id", iD);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        public Movie GetOnewithTMBD(int IdTMDB)
        {
            Command cmd = new Command("SELECT * FROM [T_Movie] WHERE TMDB_Id = @Id");
            cmd.AddParameter("Id", IdTMDB);
            return _connection.ExecuteReader(cmd, Converters.MovieConvert).FirstOrDefault();
        }

    }
}
