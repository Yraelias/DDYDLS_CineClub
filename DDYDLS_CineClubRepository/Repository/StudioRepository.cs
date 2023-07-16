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
    public class StudioRepository : BaseRepository, IStudioRepository<Studio>
    {
        public StudioRepository(IConfiguration config) : base(config)
        { }

        public IEnumerable<Studio> GetAll()
        {
            Command cmd = new Command("SELECT * FROM [T_Studio]");
            return _connection.ExecuteReader(cmd, Converters.StudioConvert);
        }

        public Studio GetOne(int Id)
        {
            Command cmd = new Command("SELECT * FROM [T_Studio] WHERE ID_Studio = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteReader(cmd, Converters.StudioConvert).FirstOrDefault();
        }

        public void Insert(Studio g)
        {
            Command cmd = new Command("INSERT INTO [dbo].[T_Studio] ([Name],[Id_Country]) VALUES (@Name,@Country)");
            cmd.AddParameter("Name", g.Name);
            _connection.ExecuteNonQuery(cmd);
        }

        public void Update(Studio g)
        {
            Command cmd = new Command("UPDATE [dbo].[T_Studio] SET[Name] = @Name WHERE ID_Studio = @Id");
            cmd.AddParameter("Name", g.Name);
            _connection.ExecuteNonQuery(cmd);
        }
        public bool Delete(int iD)
        {
            Command cmd = new Command("DELETE FROM [dbo].[T_Studio] WHERE ID_Studio = @Id ");
            cmd.AddParameter("Id", iD);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

    }
}
