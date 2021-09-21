using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Web;
using Web.Interface;

namespace WebApplication
{
    /// <summary>
    /// Opis podsumowujący dla WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Aby zezwalać na wywoływanie tej usługi sieci Web ze skryptu za pomocą kodu ASP.NET AJAX, usuń znaczniki komentarza z następującego wiersza. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        private PersonRepository _personRepository;
   


        public WebService()
        {
                _personRepository = new PersonRepository(); 
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
