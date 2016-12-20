using BackendService.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendService.DAL.DatabaseContexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            Database.EnsureCreated();
        }
        public DatabaseContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Cursus> Cursussen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=CASE-ONE-CASDB-MAXM;Trusted_Connection=True;");
            }
        }
    }
}