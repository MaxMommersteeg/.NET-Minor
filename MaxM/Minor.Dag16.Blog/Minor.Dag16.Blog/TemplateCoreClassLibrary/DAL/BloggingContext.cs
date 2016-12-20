using Microsoft.EntityFrameworkCore;
using TemplateCoreClassLibrary.Entities;

namespace TemplateCoreClassLibrary.DAL
{
    public class BloggingContext : DbContext
    {
        public BloggingContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public BloggingContext(DbContextOptions<BloggingContext> options) : base (options)
        {

        }

        public DbSet<Blog> Blogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=BlogsDB;Trusted_Connection=True;");
            }
        }
    }
}
