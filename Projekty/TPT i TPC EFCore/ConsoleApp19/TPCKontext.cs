using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
   public  class TPCKontext : DbContext
    {
        public DbSet<Osoba> People { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            var pollInterval = ConfigurationManager.AppSettings["pollInterval"];
            dbContextOptionsBuilder.UseSqlServer(new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectBase_TPC"].ConnectionString));

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pracownik>().ToTable("Pracownik");

            modelBuilder.Entity<Klient>().ToTable("Klient");
        }

    }
}
