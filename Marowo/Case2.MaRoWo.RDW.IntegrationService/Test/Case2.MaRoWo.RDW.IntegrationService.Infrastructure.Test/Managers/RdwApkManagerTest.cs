using Case2.MaRoWo.Logger.Entities;
using Case2.MaRoWo.Logger.Services;
using Case2.MaRoWo.RDW.IntegrationService.Domain.Entities;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Agents;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Converters;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Generated;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Incoming;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Managers;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.RoWe.Common.Events;
using Minor.RoWe.Common.Interfaces;
using Moq;
using System;

namespace Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Test.Managers
{
    [TestClass]
    public class RdwApkManagerTest
    {
   
        /// <summary>
        /// Test if null passed to HandleApkKeuringsVerzoek throws argumentnullexception
        /// </summary>
        [TestMethod]
        public void HandleApkKeuringsVerzoekCommandNullThrowsApkKeuringsVerzoekException()
        {
            // Arrange
            var rdwApkAgentMock = new Mock<IRdwApkAgent>(MockBehavior.Strict);
            var verzoekConverterMock = new Mock<IKeuringsVerzoekConverter>(MockBehavior.Strict);
            var logRepoMock = new Mock<IRepository<ApkAanvraagLog, long>>(MockBehavior.Strict);

            var publisherMock = new Mock<IEventPublisher>(MockBehavior.Strict);

            var target = new RdwApkManager(rdwApkAgentMock.Object, 
                verzoekConverterMock.Object, logRepoMock.Object, 
                "http://www.rdw.nl", "http://www.rdw.nl/apk",
                publisherMock.Object
            );
            ApkKeuringsVerzoekCommand apkKeuringsVerzoekCommand = null;

            // Act - Assert
            Assert.ThrowsException<ArgumentNullException>(() => target.HandleApkKeuringsVerzoek(apkKeuringsVerzoekCommand));
        }


        /// <summary>
        /// Test if RdwApkAgent gets called when correct parameters are given
        /// </summary>
        [TestMethod]
        public void HandleApkKeuringsVerzoekRdwApkAgentCalledTest()
        {
            // Arrange
            var rdwApkAgentMock = new Mock<IRdwApkAgent>(MockBehavior.Strict);
            var verzoekConverterMock = new Mock<IKeuringsVerzoekConverter>(MockBehavior.Strict);
            var logRepoMock = new Mock<IRepository<ApkAanvraagLog, long>>(MockBehavior.Strict);

            verzoekConverterMock.Setup(l => l.ToKeuringsVerzoekAntwoord(It.IsAny<Keuringsregistratie>())).Returns(new KeuringsVerzoekAntwoord());

            logRepoMock.Setup(l => l.Insert(It.IsAny<ApkAanvraagLog>()));
            logRepoMock.Setup(l => l.Update(It.IsAny<ApkAanvraagLog>()));

            rdwApkAgentMock.Setup(x => x.SendApkKeuringsVerzoek(It.IsAny<string>())).Returns(
                "<?xml version=\"1.0\" encoding=\"utf - 8\"?><apkKeuringsverzoekResponseMessage xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><keuringsregistratie correlatieId=\"f7f56961-6928-46ef-9b49-98d611ce2b71\" xmlns=\"http://www.rdw.nl\" xmlns:apk=\"http://www.rdw.nl/apk\"><kenteken>string</kenteken><apk:keuringsdatum>24-11-2016</apk:keuringsdatum><apk:steekproef xsi:nil=\"true\"/></keuringsregistratie></apkKeuringsverzoekResponseMessage>"
                );

            var publisherMock = new Mock<IEventPublisher>(MockBehavior.Strict);
            publisherMock.Setup(x => x.Publish(It.IsAny<DomainEvent>()));

            var target = new RdwApkManager(rdwApkAgentMock.Object, verzoekConverterMock.Object, logRepoMock.Object, "http://www.rdw.nl", "http://www.rdw.nl/apk", publisherMock.Object);
            var apkKeuringsVerzoekCommand = new ApkKeuringsVerzoekCommand();

            var result = target.HandleApkKeuringsVerzoek(apkKeuringsVerzoekCommand);

            // Act - Assert
            rdwApkAgentMock.Verify(x => x.SendApkKeuringsVerzoek(It.IsAny<string>()), Times.Once());
            verzoekConverterMock.Verify(l => l.ToKeuringsVerzoekAntwoord(It.IsAny<Keuringsregistratie>()), Times.Once());
            logRepoMock.Verify(x => x.Insert(It.IsAny<ApkAanvraagLog>()), Times.Once());
            logRepoMock.Verify(x => x.Update(It.IsAny<ApkAanvraagLog>()), Times.Once());
            publisherMock.Verify(x => x.Publish(It.IsAny<DomainEvent>()), Times.Once());
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ManagerTestCommand()
        {
            var logServiceMock = new Mock<ILogService>(MockBehavior.Strict);
            logServiceMock.Setup(x => x.Log(It.IsAny<LogMessage>()));
            logServiceMock.Setup(x => x.LogException(It.IsAny<LogMessage>()));
            var rdwApkAgentMock = new Mock<IRdwApkAgent>(MockBehavior.Strict);
            var verzoekConverterMock = new Mock<IKeuringsVerzoekConverter>(MockBehavior.Strict);
            var logRepoMock = new Mock<IRepository<ApkAanvraagLog, long>>(MockBehavior.Strict);
            var publisherMock = new Mock<IEventPublisher>(MockBehavior.Strict);
            var target = new RdwApkManager(rdwApkAgentMock.Object, verzoekConverterMock.Object, logRepoMock.Object, "http://www.rdw.nl", "http://www.rdw.nl/apk", publisherMock.Object);

            var apkKeuringsVerzoekCommand = new ApkKeuringsVerzoekCommand()
            {
                BedrijfPlaats = "De heurne",
                Bedrijfsnaam = "Marowo",
                EigenaarNaam = "Henk",
                Kenteken = "bl-bl-31",
                KeuringsDatum = new DateTime(2016, 1, 30),
                KeuringsinstantieKvkNummer = "1234 1234",
                KeuringsinstantieType = "Garage",
                Kilometerstand = 1234,
                VoertuigType = "auto"
            };

            var result = target.CreateRequestFromCommand(apkKeuringsVerzoekCommand);
                     
            Assert.IsNotNull(result);

            Assert.AreEqual("De heurne", result.Keuringsverzoek.Keuringsinstantie.Plaats);
            Assert.AreEqual("Marowo", result.Keuringsverzoek.Keuringsinstantie.Naam);
            Assert.AreEqual("Henk", result.Keuringsverzoek.Voertuig.Naam);
            Assert.AreEqual("bl-bl-31", result.Keuringsverzoek.Voertuig.Kenteken);
            Assert.AreEqual("30-1-2016", result.Keuringsverzoek.Keuringsdatum);
            Assert.AreEqual("1234 1234", result.Keuringsverzoek.Keuringsinstantie.Kvk);
            Assert.AreEqual("Garage", result.Keuringsverzoek.Keuringsinstantie.Type);
            Assert.AreEqual("1234", result.Keuringsverzoek.Voertuig.Kilometerstand);
            Assert.AreEqual("auto", result.Keuringsverzoek.Voertuig.Type);
            Assert.AreEqual("http://www.rdw.nl", result.Keuringsverzoek.Xmlns);
            Assert.AreEqual("http://www.rdw.nl/apk", result.Keuringsverzoek.Apk);

            Assert.AreNotEqual("00000000-0000-0000-0000-000000000000", result.Keuringsverzoek.CorrelatieId);

            logServiceMock.Verify(x => x.Log(It.IsAny<LogMessage>()), Times.Never());
            logServiceMock.Verify(x => x.LogException(It.IsAny<LogMessage>()), Times.Never());
        }
    }
}
