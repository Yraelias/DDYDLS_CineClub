﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CineClubDAL.Interfaces
{
    public interface IUserRepository<User>
    {
        IEnumerable<User> GetAll();
        User GetOne(int Id);
        void Insert(User u);
        void Update(User u);
        bool? CheckUser(User u);
        User GetByEmail(string email);
        void SetAdmin(int Id);
        bool DesactiveUser(int Id);
        bool ActiveUser(int Id);
        bool Delete(int Id);
    }
}
