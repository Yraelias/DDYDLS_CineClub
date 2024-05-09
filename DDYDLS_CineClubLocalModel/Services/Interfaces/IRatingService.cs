﻿using DDYDLS_CineClubLocalModel.Models;
using System.Collections.Generic;

namespace DDYDLS_CineClubLocalModel.Services.Interfaces
{
    public interface IRatingService
    {
        Ratings GetOne(int Id);
        IEnumerable<Ratings> GetAll();
        void Update(Ratings g);
        bool AddRating(Ratings g);
        bool Delete(int Id);
        IEnumerable<Ratings> GetRatingbyMovie(int MovieID);
        IEnumerable<Ratings> RatingsbyUser(int ID_User);
        IEnumerable<Ratings> RatingsbyUserbyYear(int ID_User, int Year);
        IEnumerable<Ratings> RatingsbyUserbyMonth(int ID_User, int Month, int Year);
    }
}
