using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Minor.Dag17.FirstASPdemo.Entities;
using Minor.Dag17.FirstASPdemo.Mappings;

namespace Minor.Dag17.FirstASPdemo
{
    public class SlakkenContext : DbContext
    {
        public SlakkenContext(DbContextOptions<SlakkenContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Slak> Slakken { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Slak>(SlakMapping.Map);
        }
    }
}
