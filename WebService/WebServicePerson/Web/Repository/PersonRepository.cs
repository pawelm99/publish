using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Interface;

namespace Web
{
    public class PersonRepository : IPersonRepository
    {
        private  List<Person> _people = new List<Person>()
        {
            new Person(1,"Tomek","Kowlaski"),
            new Person(2,"Witek","Witkowski"),
            new Person(3,"Jan","Nowak"),
        };



        public void AddOsoba(Person osoba)
        {
            osoba.Id = _people.Count() + 1;
            _people.Add(osoba);
        }

        public Person GetOsoba(int id)
        {
            var perosnSerchId = _people.SingleOrDefault(x => x.Id == id);
            return perosnSerchId;
        }

        public List<Person> GetAllPeople()
        {
            return _people;
        }


        public void UpdateOsoba(Person osoba)
        {
            var update = _people.SingleOrDefault(X => X.Id == osoba.Id);
            update.Imię = osoba.Imię;
            update.Nazwisko = osoba.Nazwisko;

        }

        public void RemoveOsoba(int id)
        {
            var del = _people.SingleOrDefault(x => x.Id == id);
            _people.Remove(del);

        }
    }
}
