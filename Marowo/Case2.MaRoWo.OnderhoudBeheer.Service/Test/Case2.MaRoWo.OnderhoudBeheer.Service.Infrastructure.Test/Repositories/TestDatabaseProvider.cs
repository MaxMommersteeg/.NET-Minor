using Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.Test.Repositories
{
    public static class TestDatabaseProvider
    {
        public static DbContextOptions<OnderhoudBeheerContext> CreateInMemoryDatabaseOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<OnderhoudBeheerContext>();
            builder.UseInMemoryDatabase()
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }


        public static DbContextOptions<OnderhoudBeheerContext> CreateMsSQLDatabaseOptions()
        {
            var builder = new DbContextOptionsBuilder<OnderhoudBeheerContext>();
            builder.UseSqlServer("Server =.\\SQLEXPRESS; Database=marowo-onderhoudbeheer; Trusted_Connection=True;");
            return builder.Options;
        }
    }
}
