using Microsoft.EntityFrameworkCore;
using Minor.Dag39.SpelbeheerServiceBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag39.SpelbeheerServiceBackend.DAL.DatabaseContexts
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Spel> Spellen { get; set; }

        public DatabaseContext()
        {
            Database.EnsureCreated();
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