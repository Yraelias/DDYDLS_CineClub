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
        IEnumerable<Rating> GetRatingbyMovie(int MovieID);
        IEnumerable<Rating> RatingsbyUser(int ID_User);
        IEnumerable<Rating> RatingsbyUserbyYear(int ID_User, int Year);
        IEnumerable<Rating> RatingsbyUserbyMonth(int ID_User, int Month, int Year);
    }
}
