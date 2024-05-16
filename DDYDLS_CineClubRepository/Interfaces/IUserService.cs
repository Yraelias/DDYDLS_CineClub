using DDYDLS_CineClubDAL.Models;
using System.Collections.Generic;

namespace DDYDLS_CineClubDAL.Interfaces
{
    public interface IUserService
    {
        bool? CheckUser(User u);
        User GetOne(int Id);
        IEnumerable<User> GetAll();
        void Update(User m);
        void Insert(User m);
        bool Delete(int Id);
        bool Desactive(int Id);
        User GetByEmail(string email);
        bool CheckIfOrganisator(int Id);
        bool CheckIfPlayer(int Id);

        bool ChangePassword(int Id, string password);
        bool ChangeUsername(int Id, string username);

    }
}
