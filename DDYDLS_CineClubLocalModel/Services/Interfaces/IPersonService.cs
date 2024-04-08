using DDYDLS_CineClubLocalModel.Models;
using System.Collections.Generic;

namespace DDYDLS_CineClubLocalModel.Services.Interfaces
{
    public interface IPersonService
    {
        Person GetOne(int Id);
        IEnumerable<Person> GetAll();
        void Update(Person p);
        bool AddPerson(Person p);
        bool Delete(int Id);
        
    }
}
