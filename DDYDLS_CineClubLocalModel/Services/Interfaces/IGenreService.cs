using DDYDLS_CineClubLocalModel.Models;
using System.Collections.Generic;

namespace DDYDLS_CineClubLocalModel.Services.Interfaces
{
    public interface IGenreService
    {
        Genre GetOne(int Id);
        IEnumerable<Genre> GetAll();
        void Update(Genre g);
        bool AddGenre(Genre g);
        bool Delete(int Id);
        
    }
}
