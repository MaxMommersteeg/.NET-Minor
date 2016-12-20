using Case2.MaRoWo.Logger.Entities;
using Case2.MaRoWo.Logger.Services;
using Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Services;
using Case2.MaRoWo.OnderhoudBeheer.Service.Facade.Controllers;
using Case2.MaRoWo.OnderhoudBeheer.Service.Incoming.Commands;
using Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.DAL;
using Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.Repository;
using Case2.MaRoWo.OnderhoudBeheer.Service.Integration.Test.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.RoWe.Common.Events;
using Minor.RoWe.Common.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Integration.Test.Tests 
{
    [TestClass]
    public class CreateOnderhoudCommandTest
    {
        private DbContextOptions _options;
        private List<CreateOnderhoudCommand> _validCreateOnderhoudCommands;

        [TestInitialize]
        public void Initialize() 
        {
            // Use InMemory database for testing, records are not removed afterwards from Local Database
            //_options = TestDatabaseProvider.CreateInMemoryDatabaseOptions();
            _options = TestDatabaseProvider.CreateMsSQLDatabaseOptions();
            using (var context = new OnderhoudBeheerContext(_options, true))
            {
                // recreate the database
            }

            _validCreateOnderhoudCommands = new List<CreateOnderhoudCommand> 
            {
                new CreateOnderhoudCommand
                {
                    Kenteken = "11-AA-ZZ",
                    Kilometerstand = 13000,
                    HasApk = true,
                    OnderhoudsBeschrijving = "Beide achterlichten vervangen",
                    OpdrachtAangemaakt = DateTime.UtcNow,
                    Bestuurder = "Max",
                    TelefoonNrBestuurder = "12893712983"
                },
                new CreateOnderhoudCommand
                {
                    Kenteken = "ZZ-111-B",
                    Kilometerstand = 200,
                    HasApk = false,
                    OnderhoudsBeschrijving = "Accu vervangen",
                    OpdrachtAangemaakt = DateTime.UtcNow,
                    Bestuurder = "Rob",
                    TelefoonNrBestuurder = "013-11213-1-3"

                },
                new CreateOnderhoudCommand
                {
                    Kenteken = "RR-01-BB",
                    Kilometerstand = 600,
                    HasApk = false,
                    OnderhoudsBeschrijving = "Koppakking vervangen",
                    OpdrachtAangemaakt = DateTime.UtcNow,
                    Bestuurder = "Wouter",
                    TelefoonNrBestuurder = "+49 123 312 123"
                },
            };
        }

        [TestMethod]
        public void FacadeToDomainService() 
        {
            // Arrange
            var eventPublisherMock = new Mock<IEventPublisher>(MockBehavior.Strict);
            eventPublisherMock.Setup(x => x.Publish(It.IsAny<DomainEvent>()));

            using(var onderhoudsopdrachtRepo = new OnderhoudsopdrachtRepository(new OnderhoudBeheerContext(_options))) 
            {
                var onderhoudsopdrachtService = new OnderhoudsopdrachtService(onderhoudsopdrachtRepo, eventPublisherMock.Object);

                var logServiceMock = new Mock<ILogService>(MockBehavior.Strict);
                logServiceMock.Setup(x => x.Log(It.IsAny<LogMessage>()));
                logServiceMock.Setup(x => x.LogException(It.IsAny<LogMessage>()));

                // Act

                // Facade receives valid CreateOnderhoudCommand
                var onderhoudController = new OnderhoudController(onderhoudsopdrachtService, logServiceMock.Object);
                // Post multiple CreateOnderhoudCommands to the controller using Post method
                foreach(var createOnderhoudCommand in _validCreateOnderhoudCommands) 
                {
                    // Post will pass CreateOnderhoudCommands to DomainService (OnderhoudsopdrachtService)
                    onderhoudController.Post(createOnderhoudCommand);
                }

                // Results stored in database
                var storedInDatabase = onderhoudsopdrachtRepo.FindAll();

                // Assert

                // Test if repository saved correct entity
                Assert.AreEqual(3, storedInDatabase.Count());
                CollectionAssert.AllItemsAreNotNull(storedInDatabase.ToList());
                // Check if all can be found by Id. Id's are starting at 1 and Database is re-created for every test.
                for(var i = 1; i < _validCreateOnderhoudCommands.Count + 1; i++) 
                {
                    var currentItem = storedInDatabase.Where(x => x.Id == i).FirstOrDefault();
                    Assert.IsNotNull(currentItem);
                }

                // Test if Publisher has been called exactly 3 times
                eventPublisherMock.Verify(x => x.Publish(It.IsAny<DomainEvent>()), Times.Exactly(_validCreateOnderhoudCommands.Count));

                logServiceMock.Verify(x => x.Log(It.IsAny<LogMessage>()), Times.Never());
                logServiceMock.Verify(x => x.LogException(It.IsAny<LogMessage>()), Times.Never());
            }
        }
    }
}
