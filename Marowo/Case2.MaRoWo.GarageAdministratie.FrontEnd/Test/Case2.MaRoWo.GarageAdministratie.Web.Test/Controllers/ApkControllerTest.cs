using Case2.MaRoWo.GarageAdministratie.Facade.Configuration;
using Case2.MaRoWo.GarageAdministratie.Facade.Controllers;
using Case2.MaRoWo.GarageAdministratie.Facade.Test.Mocks;
using Case2.MaRoWo.GarageAdministratie.Facade.Test.Repositories;
using Case2.MaRoWo.GarageAdministratie.Facade.ViewModels;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Agents.RdwIntegrationService;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database.Entities;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database.Repositories;
using Case2.MaRoWo.Logger.Entities;
using Case2.MaRoWo.Logger.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Case2.MaRoWo.GarageAdministratie.Facade.Test.Controllers
{
    [TestClass]
    public class ApkControllerTest
    {
        private DbContextOptions<GarageAdministratieContext> _options;
        private IRdwIntegrationServiceAgent _rdwIntegrationServiceAgent;
        private IRdwIntegrationServiceAgent _rdwIntegrationServiceExceptionAgent;

        [TestInitialize]
        public void Init()
        {
            // Use InMemory database for testing, records are not removed afterwards from Local Database
            //_options = TestDatabaseProvider.CreateInMemoryDatabaseOptions();
            _options = TestDatabaseProvider.CreateMsSQLDatabaseOptions();

            using (var context = new GarageAdministratieContext(_options, true))
            {
        
            }

            _rdwIntegrationServiceAgent = new RdwIntegrationServiceAgentMock();
            _rdwIntegrationServiceExceptionAgent = new RdwIntegrationServiceExceptionAgent();
        }



        [TestMethod]
        public void IndexReturnsViewResult()
        {
            var webConfigMock = new Mock<IOptions<WebAppConfig>>(MockBehavior.Strict);

            // Arrange
            var loggerMock = new Mock<ILogService>(MockBehavior.Strict);
            loggerMock.Setup(x => x.Log(It.IsAny<LogMessage>()));
            loggerMock.Setup(x => x.LogException(It.IsAny<LogMessage>()));

            using (var repo = new OnderhoudsopdrachtenRepository(new GarageAdministratieContext(_options)))
            {

                repo.Insert(new Onderhoudsopdracht()
                {
                    Bestuuder = "Rob",
                    IsAPKKeuring = true,
                    Kenteken = "12-bld-380",
                    Kilometerstand = 123,
                    OnderhoudOmschrijving = "Test",
                    OnderhoudsId = 1,
                    OpdrachtAangemaakt = new DateTime(2016, 2, 3),
                    OpdrachtStatus = 1,
                    OpdrachtStatusBeschrijving = "aangemeld",
                    TelefoonNrBestuuder = "06-123"
                }

                );
                var target = new ApkController(_rdwIntegrationServiceAgent, repo, loggerMock.Object, webConfigMock.Object);


                // Act
                var result = target.Index(1);

                Assert.IsNotNull(result);

                Assert.IsInstanceOfType(result, typeof(ViewResult));

                var model = (result as ViewResult).Model as ApkAanvraagViewModel;

                Assert.AreEqual("Rob", model.EigenaarAuto);
                Assert.AreEqual("12-bld-380", model.Kenteken);

                Assert.AreEqual(123, model.Kilometerstand);
                Assert.AreEqual(1, model.OndehoudsopdrachtId);


                loggerMock.Verify(x => x.Log(It.IsAny<LogMessage>()), Times.Never());
                loggerMock.Verify(x => x.LogException(It.IsAny<LogMessage>()), Times.Never());

            }
        }

        [TestMethod]
        public void SendApkAanvraagWithErrorsReturnsViewResult()
        {
             var webConfigMock = new Mock<IOptions<WebAppConfig>>(MockBehavior.Strict);
            // Arrange
            var loggerMock = new Mock<ILogService>(MockBehavior.Strict);
            loggerMock.Setup(x => x.Log(It.IsAny<LogMessage>()));
            loggerMock.Setup(x => x.LogException(It.IsAny<LogMessage>()));

            using (var repo = new OnderhoudsopdrachtenRepository(new GarageAdministratieContext(_options)))
            {
                var target = new ApkController(_rdwIntegrationServiceAgent, repo, loggerMock.Object, webConfigMock.Object);

                target.ModelState.AddModelError("error", "custom error");
                var model = new ApkAanvraagViewModel();
                model.EigenaarAuto = "Max";

                // Act
                var result = target.SendApkAanvraag(model);

                // Assert
                Assert.IsNotNull(result);
                Assert.IsNotNull((result as ViewResult).Model);
                Assert.AreEqual(model.EigenaarAuto, ((result as ViewResult).Model as ApkAanvraagViewModel).EigenaarAuto);

                loggerMock.Verify(x => x.Log(It.IsAny<LogMessage>()), Times.Never());
                loggerMock.Verify(x => x.LogException(It.IsAny<LogMessage>()), Times.Never());
            }
        }

        [TestMethod]
        public void SendApkAanvraagFailingAgentMessageResult()
        {

            var webConfigMock = new Mock<IOptions<WebAppConfig>>(MockBehavior.Strict);
            webConfigMock.Setup(x => x.Value).Returns(new WebAppConfig());

            // Arrange
            var loggerMock = new Mock<ILogService>(MockBehavior.Strict);
            loggerMock.Setup(x => x.Log(It.IsAny<LogMessage>()));
            loggerMock.Setup(x => x.LogException(It.IsAny<LogMessage>()));

            using (var repo = new OnderhoudsopdrachtenRepository(new GarageAdministratieContext(_options)))
            {
                var target = new ApkController(_rdwIntegrationServiceExceptionAgent, repo, loggerMock.Object, webConfigMock.Object);

                var model = new ApkAanvraagViewModel();
                model.EigenaarAuto = "Max";

                // Act
                var result = target.SendApkAanvraag(model);

                // Assert
                Assert.IsNotNull(result);
                Assert.IsNotNull((result as ViewResult).Model);
                Assert.IsNotNull(target.ViewData["FeedbackMessage"]);
                Assert.AreEqual((string)target.ViewData["FeedbackMessage"], "Sorry, de service is op dit niet beschikbaar. Probeer het later opnieuw.");
                Assert.AreEqual(model.EigenaarAuto, ((result as ViewResult).Model as ApkAanvraagViewModel).EigenaarAuto);

                loggerMock.Verify(x => x.Log(It.IsAny<LogMessage>()), Times.Never());
                loggerMock.Verify(x => x.LogException(It.IsAny<LogMessage>()), Times.Once());
            }
        }
    }
}
