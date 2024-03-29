﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Biblioteka.Data
{
    public class BibliotekaContext : DbContext
    {
        public BibliotekaContext (DbContextOptions<BibliotekaContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Entities.Ksiazka> Ksiazka { get; set; }
    }
}
