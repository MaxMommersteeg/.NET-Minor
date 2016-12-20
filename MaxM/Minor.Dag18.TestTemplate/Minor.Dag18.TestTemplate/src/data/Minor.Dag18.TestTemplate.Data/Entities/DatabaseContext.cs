using Microsoft.EntityFrameworkCore;

namespace Minor.Dag18.TestTemplate.Data.Entities
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Entity> Entity { get; set; }

        public DatabaseContext()
        {
            Database.EnsureCreated();
        }
        public DatabaseContext(DbContextOptions options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=DATABASENAME;Trusted_Connection=True;");
            }
        }
    }
}