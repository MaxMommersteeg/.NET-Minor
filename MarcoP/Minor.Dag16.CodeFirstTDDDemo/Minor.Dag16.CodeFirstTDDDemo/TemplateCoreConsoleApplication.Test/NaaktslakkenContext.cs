using Microsoft.EntityFrameworkCore;
using System;

namespace TemplateCoreConsoleApplication.Test
{
    internal class NaaktslakkenContext : DbContext
    {
        public NaaktslakkenContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Naaktslak> Naaktslakken { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Server=.\SQLEXPRESS;Database=NaaktslakkenDB;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}