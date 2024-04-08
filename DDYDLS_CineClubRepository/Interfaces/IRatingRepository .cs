using System;
using System.Collections.Generic;
using System.Text;

namespace DDYDLS_CineClubDAL.Interfaces
{
    public interface IRatingRepository<Rating>
    {
        IEnumerable<Rating> GetAll();
        Rating GetOne(int Id);
        void Insert(Rating r);
        void Update(Rating r);
        bool Delete(int Id);
        public int AvgRate(int iD);

        public int RatebyIdMovieAndIdUser (int  movieId, int userId);

        public IEnumerable<Rating> RatingsbyIdMovie(int ID_Movie);
    }
}
