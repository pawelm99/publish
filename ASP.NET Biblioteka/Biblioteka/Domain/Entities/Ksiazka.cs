using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ksiazka
    {
        public int Id { get; set; }
        public string nazwa { get; set; }
        public string autor { get; set; }

        [DataType(DataType.Date)]
        public DateTime dataWydania { get; set; }
        public string opis { get; set; }
    }

    public class KsiazkaDBContext : DbContext
    {
        public DbSet<Ksiazka> Ksiazka { get; set; }
    }
}
