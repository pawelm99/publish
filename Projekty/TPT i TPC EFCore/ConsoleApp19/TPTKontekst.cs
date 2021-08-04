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
    public class TPTKontekst : DbContext
    {
        public DbSet<Osoba> Osoba { get; set; }
        public DbSet<Klient> Klient { get; set; }
        public DbSet<Pracownik> Pracownik  { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            var pollInterval = ConfigurationManager.AppSettings["pollInterval"];
            dbContextOptionsBuilder.UseSqlServer(new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectBase_TPT"].ConnectionString));

            base.OnConfiguring(dbContextOptionsBuilder);
        }

 


    }
}
