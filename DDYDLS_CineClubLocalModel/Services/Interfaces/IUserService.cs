using DDYDLS_CineClubLocalModel.Models;
using System.Collections.Generic;

namespace DDYDLS_CineClubLocalModel.Services.Interfaces
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
        bool checkIfModerator(int Id);
        bool checkIfPlayer(int Id);
        
    }
}
