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
    public class UserRepository : BaseRepository, IUserRepository<User>
    {
        public UserRepository(IConfiguration config) : base(config)
        { }
        public bool? CheckUser(User u)
        {
            string Query = "SELECT ID_User FROM [T_User] WHERE Email = @email AND Password = @pass";
            Command cmd = new Command(Query);
            cmd.AddParameter("email", u.Email);

            cmd.AddParameter("pass", u.Password);


            int Id = Convert.ToInt32(_connection.ExecuteScalar(cmd));

            if (Id > 0)
            {
                Command checkActive = new Command("SELECT ID_User FROM [T_User] WHERE ID_User = " + Id + " AND IsActive = 1");


                if ((int)_connection.ExecuteScalar(checkActive) > 0) return true;
                else return false;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<User> GetAll()
        {
            Command cmd = new Command("SELECT * FROM [T_User]");
            return _connection.ExecuteReader(cmd, Converters.UserConvert);
        }

        public User GetByEmail(string email)
        {
            Command cmd = new Command("SELECT * FROM [T_User] WHERE Email = @email");
            cmd.AddParameter("email", email);
            return _connection.ExecuteReader(cmd, Converters.UserConvert).FirstOrDefault();
        }

        public User GetOne(int Id)
        {
            Command cmd = new Command("SELECT * FROM [T_User] WHERE ID_User = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteReader(cmd, Converters.UserConvert).FirstOrDefault();
        }

        public void Insert(User u)
        {
            //Command cmd = new Command("INSERT INTO [dbo].[T_User] ([Login],[Password],[Email],[UserName],[Language],[Country],[isActive],[Registration_Date],[IsAdministrator],[IsModerator]) VALUES (@Login, @Password, @Email, @UserName, @Language, @Country, @isActive, @Registration_Date, @IsAdministrator, @IsModerator)");
            Command cmd = new Command("INSERT INTO [dbo].[T_User] ([Password],[UserName],[ID_UserRole]) VALUES (@Password, @UserName, @UserRole)");
            u.Login = u.Email;
            cmd.AddParameter("Login", u.Login);
            cmd.AddParameter("Password", u.Password);
            cmd.AddParameter("Email", u.Email);
            if (u.Username != null) cmd.AddParameter("UserName", u.Username); else cmd.AddParameter("Username", "");
            cmd.AddParameter("UserRole", (int)1 );
            //if (u.Language != null) cmd.AddParameter("Language", u.Language); else cmd.AddParameter("Language", "");
            //if (u.Country != null) cmd.AddParameter("Country", u.Country); else cmd.AddParameter("Country", "");
            //cmd.AddParameter("isActive", u.IsActive);
            //cmd.AddParameter("Registration_Date", u.Registration_Date);
            //cmd.AddParameter("IsAdministrator", u.IsAdministrator);
            //cmd.AddParameter("IsModerator", u.IsModerator);
            _connection.ExecuteNonQuery(cmd);
        }

        public void SetAdmin(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(User u)
        {
            Command cmd = new Command("UPDATE [dbo].[T_User] SET[Login] = @Login,[Password] = @Password,[Email] = @Email,[UserName] = @UserName,[Language] = @Language" +
                ",[Country] = @Country WHERE ID_User = @Id");
            cmd.AddParameter("Login", u.Login);
            cmd.AddParameter("Password", u.Password);
            cmd.AddParameter("Email", u.Email);
            if (u.Username != null) cmd.AddParameter("UserName", u.Username); else cmd.AddParameter("Username", "");
            if (u.Language != null) cmd.AddParameter("Language", u.Language); else cmd.AddParameter("Language", "");
            if (u.Country != null) cmd.AddParameter("Country", u.Country); else cmd.AddParameter("Country", "");
            cmd.AddParameter("Id", u.ID_User);
            _connection.ExecuteNonQuery(cmd);
        }
        public bool Delete(int iD)
        {
            Command cmd = new Command("DELETE FROM [dbo].[T_User] WHERE ID_User = @Id AND isActive = 0");
            cmd.AddParameter("Id", iD);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        public bool DesactiveUser(int Id)
        {
            Command cmd = new Command("UPDATE [dbo].[T_User] SET[isActive] = 0  WHERE ID_User = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        public bool ActiveUser(int Id)
        {
            Command cmd = new Command("UPDATE [dbo].[T_User] SET[isActive] = 1  WHERE ID_User = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }



    }
}
