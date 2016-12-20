using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Models
{
    public class MonumentContext : DbContext
    {
        public MonumentContext (DbContextOptions<MonumentContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Monument> Monument { get; set; }
    }
}
