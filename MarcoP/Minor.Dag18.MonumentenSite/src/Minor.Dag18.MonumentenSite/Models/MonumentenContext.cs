using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Minor.Dag18.MonumentenSite.Models
{
    public class MonumentenContext : DbContext
    {
        public MonumentenContext (DbContextOptions<MonumentenContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Monument> Monument { get; set; }
    }
}
