using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.Dag17.NaaktslakkenTDD.DAL;
using Minor.Dag17.NaaktslakkenTDD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag17.NaaktslakkenTDD.Test
{
    [TestClass]
    public class NaaktslakkenRepositoryTest
    {
        private static DbContextOptions<NaaktslakContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<NaaktslakContext>();
            builder.UseInMemoryDatabase()
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        [TestMethod]
        public void Add_Adds()
        {
            var option = CreateNewContextOptions();
            using (var context = new NaaktslakContext(option))
            {
                IRepository<Naaktslak, long> repository
                    = new NaaktslakRepository(context);

                repository.Add(new Naaktslak());
            }

            using (var context = new NaaktslakContext(option))
            {
                Assert.AreEqual(1, context.Naaktslakken.Count());
            }
        }

        [TestMethod]
        public void MyTestMethod()
        {
            var option = CreateNewContextOptions();
            using (var context = new NaaktslakContext(option))
            {
                context.Naaktslakken.Add(new Naaktslak());


                Assert.AreEqual(1, context.Naaktslakken.Count());
            }

        }
    }
}
