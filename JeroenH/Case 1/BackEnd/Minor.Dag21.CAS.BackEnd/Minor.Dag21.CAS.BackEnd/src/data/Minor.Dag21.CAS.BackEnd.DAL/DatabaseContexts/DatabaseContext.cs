using Microsoft.EntityFrameworkCore;
using Minor.Dag21.CAS.BackEnd.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag21.CAS.BackEnd.DAL.DatabaseContexts
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Cursus> Cursus { get; set; }
        public virtual DbSet<CursusInstantie> CursusInstantie { get; set; }

        public virtual DbSet<Cursist> Cursist { get; set; }



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
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=CASDB_JeroenH;Trusted_Connection=True;");
            }
        }
    }
}