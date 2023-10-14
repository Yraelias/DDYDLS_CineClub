using DDYDLS_CineClubLocalModel.Models;
using System.Collections.Generic;

namespace DDYDLS_CineClubLocalModel.Services.Interfaces
{
    public interface IRatingService
    {
        Rating GetOne(int Id);
        IEnumerable<Rating> GetAll();
        void Update(Rating g);
        bool AddRating(Rating g);
        bool Delete(int Id);
        
    }
}
