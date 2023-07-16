using DDYDLS_CineClubLocalModel.Models;
using System.Collections.Generic;

namespace DDYDLS_CineClubLocalModel.Services.Interfaces
{
    public interface IStudioService
    {
        Studio GetOne(int Id);
        IEnumerable<Studio> GetAll();
        void Update(Studio s);
        bool AddStudio(Studio s);
        bool Delete(int Id);
        
    }
}
