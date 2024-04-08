using DDYDLS_CineClubDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDYDLS_CineClubDAL.Interfaces
{
    public interface IPersonRepository<Person>
    {
        IEnumerable<Person> GetAll();
        Person GetOne(int Id);
        void Insert(Person p);
        void Update(Person p);
        bool Delete(int Id);
    }
}
