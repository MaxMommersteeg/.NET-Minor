using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Minor.RoWe.AuditCommon.Database.Enties;

namespace Minor.RoWe.AuditLog.Database
{
    public class AuditContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        public AuditContext(DbContextOptions<AuditContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
