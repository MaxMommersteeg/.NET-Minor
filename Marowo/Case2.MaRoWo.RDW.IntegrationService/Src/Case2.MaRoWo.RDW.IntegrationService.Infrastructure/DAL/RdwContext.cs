using Case2.MaRoWo.RDW.IntegrationService.Domain.Entities;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.DAL.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Case2.MaRoWo.RDW.IntegrationService.Infrastructure.DAL
{
    public class RdwContext : DbContext
    {
        public virtual DbSet<ApkAanvraagLog> ApkAanvraagLogs { get; set; }

        public RdwContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            ApkAanvraagMapping.Map(modelBuilder);
        } 
    }
}
