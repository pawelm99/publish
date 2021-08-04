using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp14.Models
{
    public partial class Kategorie
    {
        public Kategorie()
        {
            Produkties = new HashSet<Produkty>();
        }

        public int Idkategorii { get; set; }
        public string NazwaKategorii { get; set; }
        public string Opis { get; set; }
        public byte[] Rysunek { get; set; }

        public virtual ICollection<Produkty> Produkties { get; set; }
    }
}
