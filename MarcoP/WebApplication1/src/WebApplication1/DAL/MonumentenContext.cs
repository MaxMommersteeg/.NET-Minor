using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.DAL
{
    public class MonumentenContext : DbContext
    {
        public MonumentenContext(DbContextOptions<MonumentenContext> options)
            : base (options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Monument> Monumenten { get; set; }
    }
}
