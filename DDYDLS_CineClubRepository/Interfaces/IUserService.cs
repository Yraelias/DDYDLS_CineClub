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
        bool checkIfOrganisator(int Id);
        bool checkIfPlayer(int Id);

    }
}
