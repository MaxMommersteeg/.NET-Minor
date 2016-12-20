using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace RPGRepoEFDB
{
    public class RPGContext : DbContext
    {
        private DbContextOptions<RPGContext> _createNewContextOptions;

        public RPGContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public RPGContext(DbContextOptions<RPGContext> options) : base(options)
        {
            //_createNewContextOptions = options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=RPGs;Trusted_Connection=True;");

        }

        public DbSet<RPG> RPGs { get; set; }
    }
}