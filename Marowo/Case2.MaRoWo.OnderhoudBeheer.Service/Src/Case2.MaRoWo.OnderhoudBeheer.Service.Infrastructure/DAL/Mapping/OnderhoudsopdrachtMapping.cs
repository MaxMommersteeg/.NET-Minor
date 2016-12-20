using Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.DAL.Mapping
{
    public class OnderhoudsopdrachtMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Onderhoudsopdracht>().HasKey(x => x.Id);
            modelBuilder.Entity<Onderhoudsopdracht>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Onderhoudsopdracht>().Property(x => x.Kenteken).IsRequired();
            modelBuilder.Entity<Onderhoudsopdracht>().Property(x => x.Kilometerstand).IsRequired();
            modelBuilder.Entity<Onderhoudsopdracht>().Property(x => x.OnderhoudsBeschrijving).IsRequired();
            modelBuilder.Entity<Onderhoudsopdracht>().Property(x => x.HasApk).IsRequired();
            modelBuilder.Entity<Onderhoudsopdracht>().Property(x => x.OpdrachtAangemaakt).IsRequired();

            modelBuilder.Entity<Onderhoudsopdracht>().Property(x => x.OpdrachtStatus).IsRequired();
            modelBuilder.Entity<Onderhoudsopdracht>().Property(x => x.OpdrachtStatusBeschrijving).IsRequired();

            modelBuilder.Entity<Onderhoudsopdracht>().Property(x => x.Bestuurder).IsRequired();
            modelBuilder.Entity<Onderhoudsopdracht>().Property(x => x.TelefoonNrBestuurder).IsRequired();

            modelBuilder.Entity<Onderhoudsopdracht>().Property(x => x.OpdrachtStatusBeschrijving).HasMaxLength(50);
            modelBuilder.Entity<Onderhoudsopdracht>().Property(x => x.Bestuurder).HasMaxLength(300);
            modelBuilder.Entity<Onderhoudsopdracht>().Property(x => x.TelefoonNrBestuurder).HasMaxLength(150);
            modelBuilder.Entity<Onderhoudsopdracht>().Property(x => x.Kenteken).HasMaxLength(50);
        }
    }
}

