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
    public class GenreRepository : BaseRepository, IGenreRepository<Genre>
    {
        public GenreRepository(IConfiguration config) : base(config)
        { }

        public IEnumerable<Genre> GetAll()
        {
            Command cmd = new Command("SELECT * FROM [T_Genre]");
            return _connection.ExecuteReader(cmd, Converters.GenreConvert);
        }

        public Genre GetOne(int Id)
        {
            Command cmd = new Command("SELECT * FROM [T_Genre] WHERE ID_Genre = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteReader(cmd, Converters.GenreConvert).FirstOrDefault();
        }

        public void Insert(Genre g)
        {
            Command cmd = new Command("INSERT INTO [dbo].[T_Genre] [Name] VALUES (@Name)");
            cmd.AddParameter("Name", g.Name);
            _connection.ExecuteNonQuery(cmd);
        }

        public void Update(Genre g)
        {
            Command cmd = new Command("UPDATE [dbo].[T_Genre] SET[Name] = @Name WHERE ID_Genre = @Id");
            cmd.AddParameter("Name", g.Name);
            _connection.ExecuteNonQuery(cmd);
        }
        public bool Delete(int iD)
        {
            Command cmd = new Command("DELETE FROM [dbo].[T_Genre] WHERE ID_Genre = @Id ");
            cmd.AddParameter("Id", iD);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

    }
}
