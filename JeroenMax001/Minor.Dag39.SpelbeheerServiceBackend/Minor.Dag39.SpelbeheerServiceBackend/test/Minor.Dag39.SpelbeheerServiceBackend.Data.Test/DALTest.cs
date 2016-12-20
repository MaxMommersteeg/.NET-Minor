using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Minor.Dag39.SpelbeheerServiceBackend.DAL.DatabaseContexts;
using Minor.Dag39.SpelbeheerServiceBackend.DAL.DAL;
using Minor.Dag39.SpelbeheerServiceBackend.Domain;
using RawRabbit.vNext;
using Minor.Dag39.SpelbeheerServiceBackend.Outgoing;
using System.Threading;

namespace Minor.Dag39.SpelbeheerServiceBackend.Data.Test
{
    [TestClass]
    public class DALTest
    {
        private DbContextOptions _options;
        private static DbContextOptions<DatabaseContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<DatabaseContext>();
            builder.UseInMemoryDatabase()
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        [TestInitialize]
        public void Init()
        {
            _options = CreateNewContextOptions();
        }

        [TestMethod]
        public void TestAdd()
        {

            using (var repo = new SpelRepository(new DatabaseContext(_options)))
            {
                repo.Insert(new Spel()
                {
                    SpelId = 1,
                    SpelerIds = new List<Speler> {
                        new Speler() { SpelerId=1 },
                        new Speler() { SpelerId=2 },
                        new Speler() { SpelerId=3 }
                    },
                    SpelNaam = "lala"
                });
            }


            using (var repo = new SpelRepository(new DatabaseContext(_options)))
            {
                Assert.AreEqual(1, repo.Count());
            }
        }

        [TestMethod]
        public async void TestAddReceive()
        {
            var client = BusClientFactory.CreateDefault();
            client.SubscribeAsync<SpelGestartEvent>(async (msg, context) =>
            {
                Assert.AreEqual(1, msg.SpelId);
            });

            Thread.Sleep(500);

            Spel spel = new Spel()
            {
                SpelId = 1,
                SpelerIds = new List<Speler> {
                        new Speler() { SpelerId=1 },
                        new Speler() { SpelerId=2 },
                        new Speler() { SpelerId=3 }
                    },
                SpelNaam = "lala"
            };
            await client.PublishAsync(new SpelGestartEvent { SpelerIds = spel.SpelerIds.Select(x => x.SpelerId).ToArray(), SpelId = spel.SpelId });


        }

    }
}
