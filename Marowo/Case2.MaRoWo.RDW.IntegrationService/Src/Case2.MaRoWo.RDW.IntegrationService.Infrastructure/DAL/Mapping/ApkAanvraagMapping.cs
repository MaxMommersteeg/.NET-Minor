using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Case2.MaRoWo.RDW.IntegrationService.Domain.Entities;

namespace Case2.MaRoWo.RDW.IntegrationService.Infrastructure.DAL.Mapping
{
    public class ApkAanvraagMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApkAanvraagLog>().HasKey(x => x.Id);
            modelBuilder.Entity<ApkAanvraagLog>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<ApkAanvraagLog>().Property(x => x.CorrelationId).IsRequired();
        }
    }
}
