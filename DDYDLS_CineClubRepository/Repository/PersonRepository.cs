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
    public class PersonRepository : BaseRepository, IPersonRepository<Person>
    {
        public PersonRepository(IConfiguration config) : base(config)
        { }

        public IEnumerable<Person> GetAll()
        {
            Command cmd = new Command("SELECT * FROM [T_Person]");
            return _connection.ExecuteReader(cmd, Converters.PersonConvert);
        }

        public Person GetOne(int Id)
        {
            Command cmd = new Command("SELECT * FROM [T_Person] WHERE ID_Person = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteReader(cmd, Converters.PersonConvert).FirstOrDefault();
        }

        public void Insert(Person p)
        {
            Console.WriteLine("");
            Command cmd = new Command("INSERT INTO [dbo].[T_Person] ([Name],[Country],[FirstName]) VALUES (@Name,@Country,@FirstName)");
            cmd.AddParameter("Name", p.Name);
            cmd.AddParameter("Country", p.Country);
            cmd.AddParameter("FirstName", p.FirstName);
            _connection.ExecuteNonQuery(cmd);
        }

        public void Update(Person p)
        {
            Command cmd = new Command("UPDATE [dbo].[T_Genre] SET[Name] = @Name,[Country] = @Country,[FirstName] = @FirstName WHERE ID_Person = @Id");
            cmd.AddParameter("Name", p.Name);
            cmd.AddParameter("Country", p.Country);
            cmd.AddParameter("FirstName", p.FirstName);
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
