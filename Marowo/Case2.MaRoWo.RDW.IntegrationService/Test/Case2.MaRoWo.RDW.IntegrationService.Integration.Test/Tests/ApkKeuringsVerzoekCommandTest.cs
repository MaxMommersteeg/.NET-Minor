using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Incoming;
using Case2.MaRoWo.RDW.IntegrationService.Integration.Test.Repositories;
using System;
using Case2.MaRoWo.RDW.IntegrationService.Facade.Controllers;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Managers;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Agents;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Converters;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Repositories;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.DAL;
using Moq;
using System.Linq;
using Minor.RoWe.Common.Interfaces;
using Minor.RoWe.Common.Events;
using Case2.MaRoWo.Logger.Services;
using Case2.MaRoWo.Logger.Entities;

namespace Case2.MaRoWo.RDW.IntegrationService.Integration.Test.Tests
{
    [TestClass]
    public class ApkKeuringsVerzoekCommandTest
    {
        private DbContextOptions _options;
        private List<ApkKeuringsVerzoekCommand> _validApkKeuringsVerzoekCommands;

        [TestInitialize]
        public void Initialize()
        {
            // Use InMemory database for testing, records are not removed afterwards from Local Database
            _options = TestDatabaseProvider.CreateInMemoryDatabaseOptions();
            //_options = TestDatabaseProvider.CreateMsSQLDatabaseOptions();

            _validApkKeuringsVerzoekCommands = new List<ApkKeuringsVerzoekCommand>
            {
                new ApkKeuringsVerzoekCommand
                {
                    Kenteken = "11-AA-ZZ",
                    Kilometerstand = 13000,
                    VoertuigType = "Personenauto",
                    Bedrijfsnaam = "Garage MaRoWo",
                    BedrijfPlaats = "Utrecht",
                    KeuringsinstantieType = "apk",
                    KeuringsDatum = DateTime.UtcNow.Date,
                    EigenaarNaam = "Max",
                    KeuringsinstantieKvkNummer = "19283746501"
                },
                new ApkKeuringsVerzoekCommand
                {
                    Kenteken = "11-AAA-Z",
                    Kilometerstand = 110,
                    VoertuigType = "Personenauto",
                    Bedrijfsnaam = "Garage MaRoWo",
                    BedrijfPlaats = "Utrecht",
                    KeuringsinstantieType = "apk",
                    KeuringsDatum = DateTime.UtcNow.Date,
                    EigenaarNaam = "Wouter",
                    KeuringsinstantieKvkNummer = "19283746501"
                },
                new ApkKeuringsVerzoekCommand
                {
                    Kenteken = "AA-01-BB",
                    Kilometerstand = 90000,
                    VoertuigType = "Personenauto",
                    Bedrijfsnaam = "Garage MaRoWo",
                    BedrijfPlaats = "Utrecht",
                    KeuringsinstantieType = "apk",
                    KeuringsDatum = DateTime.UtcNow.Date,
                    EigenaarNaam = "Rob",
                    KeuringsinstantieKvkNummer = "19283746501"
                }
            };
        }

        [TestMethod]
        public void FacadeToRdwAgent()
        {
            // Arrange
            var logServiceMock = new Mock<ILogService>(MockBehavior.Strict);
            logServiceMock.Setup(x => x.Log(It.IsAny<LogMessage>()));
            logServiceMock.Setup(x => x.LogException(It.IsAny<LogMessage>()));

            var keuringsVerzoekConverter = new KeuringsVerzoekConverter();

            var rdwApkAgentMock = new Mock<IRdwApkAgent>(MockBehavior.Strict);
            rdwApkAgentMock.Setup(x => x.SendApkKeuringsVerzoek(It.IsAny<string>())).Returns("<?xml version=\"1.0\" encoding=\"utf - 8\"?><apkKeuringsverzoekResponseMessage xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><keuringsregistratie correlatieId=\"f7f56961-6928-46ef-9b49-98d611ce2b71\" xmlns=\"http://www.rdw.nl\" xmlns:apk=\"http://www.rdw.nl/apk\"><kenteken>string</kenteken><apk:keuringsdatum>24-11-2016</apk:keuringsdatum><apk:steekproef xsi:nil=\"true\"/></keuringsregistratie></apkKeuringsverzoekResponseMessage>");

            var publisherMock = new Mock<IEventPublisher>(MockBehavior.Strict);
            publisherMock.Setup(x => x.Publish(It.IsAny<DomainEvent>()));
            publisherMock.Setup(x => x.Dispose());
            
            using (var apkAanvraagLogRepo = new ApkAanvraagLogRepository(new RdwContext(_options)))
            using (var rdwApkManager = new RdwApkManager(rdwApkAgentMock.Object, keuringsVerzoekConverter,
                apkAanvraagLogRepo, "keuringsverzoekXmlns", "keuringsverzoekApk", publisherMock.Object))
            using(var apkController = new ApkController(rdwApkManager, logServiceMock.Object))
            {
                // Act - Start at controller
                foreach (var apkKeuringsVerzoekCommand in _validApkKeuringsVerzoekCommands)
                {
                    // Send commands to controller's post method
                    apkController.Post(apkKeuringsVerzoekCommand);
                }

                // Assert

                // See if all commands reached the Agent
                rdwApkAgentMock.Verify(x => x.SendApkKeuringsVerzoek(It.IsAny<string>()), Times.Exactly(3));
                logServiceMock.Verify(x => x.Log(It.IsAny<LogMessage>()), Times.Never());
                logServiceMock.Verify(x => x.LogException(It.IsAny<LogMessage>()), Times.Never());

                var logsStoredInDatabase = apkAanvraagLogRepo.FindAll();

                // One log record should be inserted for each command
                Assert.AreEqual(_validApkKeuringsVerzoekCommands.Count, logsStoredInDatabase.Count());
            }
        }
    }
}
