﻿using IdentityServer4.Models;
using DDYDLS_CineClubLocalModel.Services.Interfaces;
using DDYDLS_CineClubLocalModel.Models;
using DDYDLS_CineClubLocalModel.Tools;
using System.Collections.Generic;
using System.Linq;
#pragma warning disable CS8981 // Le nom de type contient uniquement des caractères ascii en minuscules. De tels noms peuvent devenir réservés pour la langue.
using dal = DDYDLS_CineClubDAL.Models;
#pragma warning restore CS8981 // Le nom de type contient uniquement des caractères ascii en minuscules. De tels noms peuvent devenir réservés pour la langue.
using System;
using DDYDLS_CineClubDAL.Interfaces;

namespace DDYDLS_CineClubLocalModel.Services
{
    public class RatingService : Interfaces.IRatingService
    {
        private IRatingRepository<dal.Rating> _RatingRepository;
        public RatingService(IRatingRepository<dal.Rating> RatingRepository)
        {
            _RatingRepository = RatingRepository;
        }

        public bool Delete(int Id)
        {
            return _RatingRepository.Delete(Id);
        }

        public IEnumerable<Rating> GetAll()
        {
            return _RatingRepository.GetAll().Select(g => g.toLocal());
        }

        public Rating GetOne(int Id)
        {
            return _RatingRepository.GetOne(Id).toLocal();
        }

        public bool AddRating(Rating g)
        {
            
            _RatingRepository.Insert(g.toDal());

            return true;
        }

        public void Update(Rating g)
        {
            _RatingRepository.Update(g.toDal());
        }
        
    }
}