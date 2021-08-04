using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp14.Models
{
    public partial class PozycjeZamówienium
    {
        public int Idzamówienia { get; set; }
        public int Idproduktu { get; set; }
        public decimal CenaJednostkowa { get; set; }
        public short Ilość { get; set; }
        public float Rabat { get; set; }

        public virtual Produkty IdproduktuNavigation { get; set; }
        public virtual Zamówienium IdzamówieniaNavigation { get; set; }
    }
}
