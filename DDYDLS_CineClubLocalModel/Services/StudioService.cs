using IdentityServer4.Models;
using DDYDLS_CineClubLocalModel.Services.Interfaces;
using DDYDLS_CineClubLocalModel.Models;
using DDYDLS_CineClubLocalModel.Tools;
using System.Collections.Generic;
using System.Linq;
using dal = DDYDLS_CineClubDAL.Models;
using System;
using DDYDLS_CineClubDAL.Interfaces;

namespace DDYDLS_CineClubLocalModel.Services
{
    public class StudioService : Interfaces.IStudioService
    {
        private IStudioRepository<dal.Studio> _StudioRepository;
        public StudioService(IStudioRepository<dal.Studio> StudioRepository)
        {
            _StudioRepository = StudioRepository;
        }

        public bool Delete(int Id)
        {
            return _StudioRepository.Delete(Id);
        }

        public IEnumerable<Studio> GetAll()
        {
            return _StudioRepository.GetAll().Select(s => s.toLocal());
        }

        public Studio GetOne(int Id)
        {
            return _StudioRepository.GetOne(Id).toLocal();
        }

        public bool AddStudio(Studio s)
        {
            
            _StudioRepository.Insert(s.toDal());

            return true;
        }

        public void Update(Studio s)
        {
            _StudioRepository.Update(s.toDal());
        }
        
    }
}
