
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web
{
    public class Person
    {
        

        public Person()
        {
        }

        public Person(int id, string imię, string nazwisko)
        {
            Id = id;
            Imię = imię;
            Nazwisko = nazwisko;
        }

        public int Id { get; set; }
        public string Imię { get; set; }
        public string Nazwisko { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Id: {Id}");
            stringBuilder.AppendLine($"Imię: {Imię}");
            stringBuilder.AppendLine($"Nazwisko: {Nazwisko}");
            return stringBuilder.ToString();
        }
    
    }
}
