using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database.Entities;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Case2.MaRoWo.GarageAdministratie.Infrastructure.Test.Repositories
{
    [TestClass]
    public class OnderhoudsopdrachtenRepositoryTest
    {
        private DbContextOptions<GarageAdministratieContext> _options;

        [TestInitialize]
        public void Init()
        {
            // Use InMemory database for testing, records are not removed afterwards from Local Database
            //_options = TestDatabaseProvider.CreateInMemoryDatabaseOptions();
            _options = TestDatabaseProvider.CreateMsSQLDatabaseOptions();

            // Act
            using (var context = new GarageAdministratieContext(_options, true))
            {
                context.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public void InsertAddsToDatabase()
        {

            //Arrange
            Onderhoudsopdracht onderhoudsopdracht = new Onderhoudsopdracht()
            {
                Kenteken = "DF-RE-60",
                Kilometerstand = 100000,
                OnderhoudOmschrijving = "Uitlaat is lek",
                IsAPKKeuring = false,
                OnderhoudsId = 1,
                OpdrachtStatus = 1,
                OpdrachtStatusBeschrijving = "test",
                Bestuuder = "Rob",
                TelefoonNrBestuuder = "1234-123123",
                OpdrachtAangemaakt = new DateTime(2016, 11, 11)
            };

            // Act
            using (var repository = new OnderhoudsopdrachtenRepository(new GarageAdministratieContext(_options)))
            {
                repository.Insert(onderhoudsopdracht);
            }

            // Assert
            using (var repository = new OnderhoudsopdrachtenRepository(new GarageAdministratieContext(_options)))
            {
                Assert.AreEqual(1, repository.Count());
            }
        }

        [TestMethod]
        public void FindWithIdFindsOnderhoudsopdracht()
        {
            //Arrange
            Onderhoudsopdracht onderhoudsopdracht = new Onderhoudsopdracht()
            {

                Kenteken = "DF-RE-60",
                Kilometerstand = 100000,
                OnderhoudOmschrijving = "Uitlaat is lek",
                IsAPKKeuring = false,
                OnderhoudsId = 820,
                Bestuuder = "Rob",
                OpdrachtAangemaakt = new DateTime(2016, 12, 12),
                OpdrachtStatus = 1,
                OpdrachtStatusBeschrijving = "Test",
                TelefoonNrBestuuder = "1234-123123"

            };

            // Act
            using (var repository = new OnderhoudsopdrachtenRepository(new GarageAdministratieContext(_options)))
            {
                repository.Insert(onderhoudsopdracht);
            }

            // Assert
            using (var repository = new OnderhoudsopdrachtenRepository(new GarageAdministratieContext(_options)))
            {
                var result = repository.Find(820);
                Assert.IsInstanceOfType(result, typeof(Onderhoudsopdracht));
                Assert.AreEqual(1, onderhoudsopdracht.Id);
                Assert.AreEqual(onderhoudsopdracht.Kenteken, result.Kenteken);
                Assert.AreEqual(onderhoudsopdracht.Kilometerstand, result.Kilometerstand);
                Assert.AreEqual(onderhoudsopdracht.OnderhoudOmschrijving, result.OnderhoudOmschrijving);
                Assert.AreEqual(onderhoudsopdracht.IsAPKKeuring, result.IsAPKKeuring);
            }
        }
    }
}
