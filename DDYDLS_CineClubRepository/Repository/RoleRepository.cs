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
    public class RoleRepository : BaseRepository, IRoleRepository<Role>
    {
        public RoleRepository(IConfiguration config) : base(config)
        { }

        public IEnumerable<Role> GetAll()
        {
            Command cmd = new Command("SELECT * FROM [T_Role]");
            return _connection.ExecuteReader(cmd, Converters.RoleConvert);
        }

        public Role GetOne(int Id)
        {
            Command cmd = new Command("SELECT * FROM [T_Role] WHERE ID_Role = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteReader(cmd, Converters.RoleConvert).FirstOrDefault();
        }

        public void Insert(Role g)
        {
            Command cmd = new Command("INSERT INTO [dbo].[T_Role] ([Name]) VALUES (@Name)");
            cmd.AddParameter("Name", g.Name);
            _connection.ExecuteNonQuery(cmd);
        }

        public void Update(Role g)
        {
            Command cmd = new Command("UPDATE [dbo].[T_Role] SET[Name] = @Name WHERE Id_Role = @Id");
            cmd.AddParameter("Name", g.Name);
            _connection.ExecuteNonQuery(cmd);
        }
        public bool Delete(int iD)
        {
            Command cmd = new Command("DELETE FROM [dbo].[T_Role] WHERE Id_Role = @Id ");
            cmd.AddParameter("Id", iD);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

    }
}
