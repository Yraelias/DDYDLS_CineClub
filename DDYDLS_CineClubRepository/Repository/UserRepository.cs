using DDYDLS_CineClubDAL.Interfaces;
using DDYDLS_CineClubDAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDYDLS_CineClubDAL.Repository
{
    public class UserRepository : CineclubContext, IUserRepository<User>
    {
        private readonly CineclubContext _dbContext;
        public UserRepository(IConfiguration config, CineclubContext dbContext) : base(config)
        {
            _dbContext = dbContext;
        }
        public bool? CheckUser(User u)
        {
           var user = _dbContext.T_User.FirstOrDefault(u => u.Email == u.Email && u.Password == u.Password);
            if (user != null)
            {
                if (user.IsActive)
                {
                    return true;
                }
                else return false;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<User> GetAll()
        {
           return _dbContext.T_User.ToList();
        }

        public User GetByEmail(string email)
        {
            return _dbContext.T_User.First(u => u.Email == email);
        }

        public User GetOne(int Id)
        {
            return _dbContext.T_User.Find(Id);
        }

        public void Insert(User u)
        {
            _dbContext.Add(u);
            _dbContext.SaveChanges();
        }

        public void SetAdmin(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(User u)
        {
            _dbContext.Update(u);
            _dbContext.SaveChanges();
        }
        public bool Delete(int iD)
        {
            var userToDelete = _dbContext.T_User.Find(iD);
            if (userToDelete != null)
            {
                _dbContext.T_User.Remove(userToDelete);
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DesactiveUser(int Id)
        {
            var user = _dbContext.T_User.Find(Id);
            if (user != null)
            {
                user.IsActive = false; 
                _dbContext.SaveChanges(); 
                return true;
            }
            else
            {
                return false; 
            }
        }

        public bool ActiveUser(int Id)
        {
            var user = _dbContext.T_User.Find(Id);
            if (user != null)
            {
                user.IsActive = true;
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool changePassword(int Id, string password)
        {
            var user = _dbContext.T_User.Find(Id);
            if (user != null)
            {
                user.Password = password;
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool changeUsername(int Id, string username)
        {
            var user = _dbContext.T_User.Find(Id);
            if (user != null)
            {
                user.Username = username;
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
