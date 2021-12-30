
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class BlogggerContext : DbContext
    {
        public BlogggerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

        public override int SaveChanges()
        {
            var entites = ChangeTracker
                .Entries()
                .Where(x => x.Entity is AuditableEntity && 
                (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entityEntry in entites)
            {
                ((AuditableEntity)entityEntry.Entity).LastModifed = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    ((AuditableEntity)entityEntry.Entity).Created = DateTime.UtcNow;
                }
            }

            return base.SaveChanges();
        }
    }
}
