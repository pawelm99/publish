using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ConsoleApp14
{
    class DBKontekst : DbContext
    {
        public DbSet<MyUsers> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
      
            dbContextOptionsBuilder.UseSqlServer(new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString));
            base.OnConfiguring(dbContextOptionsBuilder);
        }
    }
}
