using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Interface
{
    public interface IPersonRepository
    {
        List<Person> GetAllPeople();
        Person GetOsoba(int id);
        void AddOsoba(Person osoba);
        void UpdateOsoba(Person osoba);
        void RemoveOsoba(int id);
    }
}
