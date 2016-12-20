using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Case2.MaRoWo.GarageAdministratie.Infrastructure.Test.Repositories
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
            builder.UseSqlServer("Server =.\\SQLEXPRESS; Database=marowo-FrontEnd; Trusted_Connection=True;");
            return builder.Options;
        }
    }
}
