using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Minor.Dag17.NaaktslakkenTDD.Entities;

namespace Minor.Dag17.NaaktslakkenTDD.DAL
{
    public class NaaktslakContext : DbContext
    {
        public NaaktslakContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Naaktslak> Naaktslakken { get; set; }
    }
}