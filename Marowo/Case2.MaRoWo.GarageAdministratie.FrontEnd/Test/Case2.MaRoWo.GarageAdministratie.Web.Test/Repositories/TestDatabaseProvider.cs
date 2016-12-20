using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Case2.MaRoWo.GarageAdministratie.Facade.Test.Repositories
{
    public static class TestDatabaseProvider
    {
        public static DbContextOptions<GarageAdministratieContext> CreateInMemoryDatabaseOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<GarageAdministratieContext>();
            builder.UseInMemoryDatabase()
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        public static DbContextOptions<GarageAdministratieContext> CreateMsSQLDatabaseOptions()
        {
            var builder = new DbContextOptionsBuilder<GarageAdministratieContext>();
            builder.UseSqlServer("Server =.\\SQLEXPRESS; Database=marowo-rdw; Trusted_Connection=True;");
            return builder.Options;
        }
    }
}
