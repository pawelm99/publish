using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using Web;
using Web.Interface;


namespace WebApplication
{

    public class WebService : System.Web.Services.WebService
    {

        private PersonRepository _personRepository = new PersonRepository();




        public WebService( ) 
        {

            
        }



        [WebMethod]
        public List<Person> GetAllPeople()
        {

            return _personRepository.GetAllPeople();
        }
        [WebMethod]
        public Person GetOsoba(int id)
        {
           
            return _personRepository.GetOsoba(id);
        }

        [WebMethod]
        public List<Person> AddOsoba(string imie, string nazwisko)
        {
            var iloscOsobWLista = _personRepository.GetAllPeople().Count() + 1;
            var osoba = new Person(iloscOsobWLista, imie, nazwisko);
            _personRepository.AddOsoba(osoba);
            return _personRepository.GetAllPeople();
        }

        [WebMethod]
        public List<Person> RemoveOsoba(int id)
        {
            _personRepository.RemoveOsoba(id);
            return _personRepository.GetAllPeople();
        }
    }
}
