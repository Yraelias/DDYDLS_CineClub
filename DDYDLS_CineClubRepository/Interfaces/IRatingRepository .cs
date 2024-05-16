using System;
using System.Collections.Generic;
using System.Text;

namespace DDYDLS_CineClubDAL.Interfaces
{
    public interface IRatingRepository<Ratings>
    {
        IEnumerable<Ratings> GetAll();
        Ratings GetOne(int Id);
        void AddOrUpdate(Ratings r);
        void Update(Ratings r);
        bool Delete(int Id);
        public int AvgRate(int iD);

        public int RatebyIdMovieAndIdUser (int  movieId, int userId);

        public IEnumerable<Ratings> RatingsbyIdMovie(int ID_Movie);

        IEnumerable<Ratings> RatingsbyUser(int ID_User);
        IEnumerable<Ratings> RatingsbyUserbyYear(int ID_User, int Month);
        IEnumerable<Ratings> RatingsbyUserbyMonth(int ID_User, int Month, int Year);
        IEnumerable<Ratings> RatingsForCineclub(int ID_Cineclub);
    }
}
