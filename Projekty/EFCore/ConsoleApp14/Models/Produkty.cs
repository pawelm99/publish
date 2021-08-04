using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp14.Models
{
    public partial class Produkty
    {
        public Produkty()
        {
            PozycjeZamówienia = new HashSet<PozycjeZamówienium>();
        }

        public int Idproduktu { get; set; }
        public string NazwaProduktu { get; set; }
        public int? Iddostawcy { get; set; }
        public int? Idkategorii { get; set; }
        public string IlośćJednostkowa { get; set; }
        public decimal? CenaJednostkowa { get; set; }
        public short? StanMagazynu { get; set; }
        public short? IlośćZamówiona { get; set; }
        public short? StanMinimum { get; set; }
        public bool Wycofany { get; set; }

        public virtual Dostawcy IddostawcyNavigation { get; set; }
        public virtual Kategorie IdkategoriiNavigation { get; set; }
        public virtual ICollection<PozycjeZamówienium> PozycjeZamówienia { get; set; }
    }
}
