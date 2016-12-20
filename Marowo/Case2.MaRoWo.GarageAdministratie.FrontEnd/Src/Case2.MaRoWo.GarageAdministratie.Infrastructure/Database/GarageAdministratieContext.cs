using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Case2.MaRoWo.GarageAdministratie.Infrastructure.Database
{
    public class GarageAdministratieContext : DbContext
    {

        public DbSet<Onderhoudsopdracht> Onderhoudsopdrachten { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public GarageAdministratieContext(DbContextOptions<GarageAdministratieContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="deleteDb"></param>
        public GarageAdministratieContext(DbContextOptions<GarageAdministratieContext> options, bool deleteDb) : base(options)
        {
            if (deleteDb)
            {
                Database.EnsureDeleted();
            }
            Database.EnsureCreated();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
