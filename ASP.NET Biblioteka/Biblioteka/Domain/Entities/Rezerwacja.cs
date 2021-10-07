using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [DataType(DataType.Date)]
        public DateTime dataRezerwacji { get; set; }

    }
    public class RezerwacjaDBContext : DbContext
    {
        public DbSet<Rezerwacja> Rezerwacja { get; set; }
    }
}
