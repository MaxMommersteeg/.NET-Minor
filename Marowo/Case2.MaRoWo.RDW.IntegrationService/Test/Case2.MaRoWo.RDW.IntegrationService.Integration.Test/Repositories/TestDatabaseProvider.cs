using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Case2.MaRoWo.RDW.IntegrationService.Integration.Test.Repositories 
{
    public static class TestDatabaseProvider
    {
        public static DbContextOptions<RdwContext> CreateInMemoryDatabaseOptions() 
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<RdwContext>();
            builder.UseInMemoryDatabase()
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        public static DbContextOptions<RdwContext> CreateMsSQLDatabaseOptions() 
        {
            var builder = new DbContextOptionsBuilder<RdwContext>();
            builder.UseSqlServer("Server =.\\SQLEXPRESS; Database=marowo-rdw; Trusted_Connection=True;");
            return builder.Options;
        }
    }
}
