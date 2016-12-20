using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag38.HelloAPI.DAL.DatabaseContexts
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Entity> Entity { get; set; }

        public DatabaseContext()
        {
            this.Database.EnsureCreated();
        }
        public DatabaseContext(DbContextOptions options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=DATABASENAME;Trusted_Connection=True;");
            }
        }
    }
}