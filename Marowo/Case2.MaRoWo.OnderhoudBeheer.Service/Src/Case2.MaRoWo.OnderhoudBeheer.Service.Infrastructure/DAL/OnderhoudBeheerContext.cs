using Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Entities;
using Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.DAL.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.DAL
{
    public class OnderhoudBeheerContext : DbContext
    {       

        public virtual DbSet<Onderhoudsopdracht> Onderhoudsopdrachten { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public OnderhoudBeheerContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="deleteDb"></param>
        public OnderhoudBeheerContext(DbContextOptions options, bool deleteDb) : this(options)
        {
            if (deleteDb)
            {                
                Database.EnsureDeleted();
            }
            Database.EnsureCreated();
        }

        /// <summary>
        /// Create db model
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnderhoudsopdrachtMapping.Map(modelBuilder);
        }
    }
}
