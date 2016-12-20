using System;
using Microsoft.EntityFrameworkCore;

namespace RPGRepoEFDB
{
    public class RPGContext : DbContext
    {
        public RPGContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=RPGs;Trusted_Connection=True;");

        }
    }
}