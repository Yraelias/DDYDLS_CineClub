using IdentityServer4.Models;
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
    public class PersonService : Interfaces.IPersonService
    {
        private IPersonRepository<dal.Person> _personRepository;
        public PersonService(IPersonRepository<dal.Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public bool Delete(int Id)
        {
            return _personRepository.Delete(Id);
        }

        public IEnumerable<Person> GetAll()
        {
            return _personRepository.GetAll().Select(p => p.toLocal());
        }

        public Person GetOne(int Id)
        {
            return _personRepository.GetOne(Id).toLocal();
        }

        public bool AddPerson(Person p)
        {
            
            _personRepository.Insert(p.toDal());

            return true;
        }

        public void Update(Person p)
        {
            _personRepository.Update(p.toDal());
        }
        
    }
}
