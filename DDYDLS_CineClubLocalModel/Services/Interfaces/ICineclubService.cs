using DDYDLS_CineClubLocalModel.Models;
using System.Collections.Generic;

namespace DDYDLS_CineClubLocalModel.Services.Interfaces
{
    public interface ICineclubService
    {
        Cineclub GetOne(int Id);
        IEnumerable<Cineclub> GetAll();
        void Update(Cineclub g);
        bool Add(Cineclub g);
        bool Delete(int Id);
        
    }
}
