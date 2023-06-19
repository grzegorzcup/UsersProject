using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class PostContext : DbContext
    {
        public PostContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }

        public override int SaveChanges()
        {
            var entires = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditableEntity && (e.State == EntityState.Added || e.State ==  EntityState.Modified));

            foreach (var entire in entires)
            {
                ((AuditableEntity)entire.Entity).LastModified = DateTime.UtcNow;

                if (entire.State == EntityState.Added)
                {
                    ((AuditableEntity)entire.Entity).Created = DateTime.UtcNow;
                }
            }
            return base.SaveChanges();
        }
    }
}
