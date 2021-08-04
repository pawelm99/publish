using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp14.Models
{
    public partial class Dostawcy
    {
        public Dostawcy()
        {
            Produkties = new HashSet<Produkty>();
        }

        public int Iddostawcy { get; set; }
        public string NazwaFirmy { get; set; }
        public string Przedstawiciel { get; set; }
        public string StanowiskoPrzedstawiciela { get; set; }
        public string Adres { get; set; }
        public string Miasto { get; set; }
        public string Region { get; set; }
        public string KodPocztowy { get; set; }
        public string Kraj { get; set; }
        public string Telefon { get; set; }
        public string Faks { get; set; }
        public string StronaMacierzysta { get; set; }

        public virtual ICollection<Produkty> Produkties { get; set; }
    }
}
