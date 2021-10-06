using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Rezerwacja
    {
        public int Id { get; set; }
        public int KasiazkaId { get; set; }
        public int UzytkownikId { get; set; }
        public DateTime dataRezerwacji { get; set; }

    }
}
