using Case2.MaRoWo.GarageAdministratie.Facade.Controllers;
using Case2.MaRoWo.GarageAdministratie.Facade.Test.Mocks;
using Case2.MaRoWo.GarageAdministratie.Facade.ViewModels;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database.Entities;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database.Repositories;
using Case2.MaRoWo.Logger.Entities;
using Case2.MaRoWo.Logger.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Case2.MaRoWo.GarageAdministratie.Facade.Test.Controllers
{
    [TestClass]
    public class OnderhoudsopdrachtenControllerTest
    {
        private OnderhoudBeheerServiceAgentMock _onderhoudBeheerServiceAgent;
        private OnderhoudBeheerServiceExceptionAgentMock _onderhoudBeheerServiceExceptionAgent;

        [TestInitialize]
        public void Init()
        {
            _onderhoudBeheerServiceAgent = new OnderhoudBeheerServiceAgentMock();
            _onderhoudBeheerServiceExceptionAgent = new OnderhoudBeheerServiceExceptionAgentMock();
        }

        [TestMethod]
        public void IndexCallsRepository()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<Onderhoudsopdracht, long>>(MockBehavior.Strict);
            repositoryMock.Setup(repository => repository.FindAll()).Returns(new List<Onderhoudsopdracht>());

            var loggerMock = new Mock<ILogService>(MockBehavior.Strict);
            loggerMock.Setup(x => x.Log(It.IsAny<LogMessage>()));
            loggerMock.Setup(x => x.LogException(It.IsAny<LogMessage>()));

            var target = new OnderhoudsopdrachtenController(_onderhoudBeheerServiceAgent, repositoryMock.Object, loggerMock.Object);

            // Act
            var result = target.Index();

            // Assert
            repositoryMock.Verify(x => x.FindAll(), Times.Once());
            loggerMock.Verify(x => x.Log(It.IsAny<LogMessage>()), Times.Never());
            loggerMock.Verify(x => x.LogException(It.IsAny<LogMessage>()), Times.Never());
            Assert.IsInstanceOfType(result, typeof(IActionResult));
            Assert.IsInstanceOfType((result as ViewResult).Model, typeof(OnderhoudsopdrachtenOverzichtViewModel));
        }

        [TestMethod]
        public void ToevoegenReturnsViewResult()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<Onderhoudsopdracht, long>>(MockBehavior.Strict);

            var loggerMock = new Mock<ILogService>(MockBehavior.Strict);
            loggerMock.Setup(x => x.Log(It.IsAny<LogMessage>()));
            loggerMock.Setup(x => x.LogException(It.IsAny<LogMessage>()));

            OnderhoudsopdrachtenController controller = new OnderhoudsopdrachtenController(_onderhoudBeheerServiceAgent, repositoryMock.Object, loggerMock.Object);

            // Act
            var result = controller.Toevoegen();

            // Assert
            loggerMock.Verify(x => x.Log(It.IsAny<LogMessage>()), Times.Never());
            loggerMock.Verify(x => x.LogException(It.IsAny<LogMessage>()), Times.Never());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void ToevoegenReturnsIActionResultWithOnderhoudsopdrachtViewModel()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<Onderhoudsopdracht, long>>(MockBehavior.Strict);

            var loggerMock = new Mock<ILogService>(MockBehavior.Strict);
            loggerMock.Setup(x => x.Log(It.IsAny<LogMessage>()));
            loggerMock.Setup(x => x.LogException(It.IsAny<LogMessage>()));

            OnderhoudsopdrachtenController controller = new OnderhoudsopdrachtenController(_onderhoudBeheerServiceAgent, repositoryMock.Object, loggerMock.Object);

            // Act
            var result = controller.Toevoegen();

            // Assert
            loggerMock.Verify(x => x.Log(It.IsAny<LogMessage>()), Times.Never());
            loggerMock.Verify(x => x.LogException(It.IsAny<LogMessage>()), Times.Never());

            var viewResult = (ViewResult)result;
            var model = viewResult.Model;
            Assert.IsNotNull(model);
            Assert.IsInstanceOfType(model, typeof(OnderhoudsopdrachtViewModel));
        }

        [TestMethod]
        public void SendOnderhoudsopdrachtReturnsIActionResult()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<Onderhoudsopdracht, long>>(MockBehavior.Strict);

            var loggerMock = new Mock<ILogService>(MockBehavior.Strict);
            loggerMock.Setup(x => x.Log(It.IsAny<LogMessage>()));
            loggerMock.Setup(x => x.LogException(It.IsAny<LogMessage>()));

            OnderhoudsopdrachtenController controller = new OnderhoudsopdrachtenController(_onderhoudBeheerServiceAgent, repositoryMock.Object, loggerMock.Object);

            OnderhoudsopdrachtViewModel onderhoudsopdracht = new OnderhoudsopdrachtViewModel()
            {
                Kenteken = "DF-RE-60",
                Kilometerstand = 100000,
                OnderhoudOmschrijving = "Uitlaat is lek",
                IsAPKKeuring = false,
                BestuurderNaam = "Max",
                TelefoonNrBestuurder = "123"
            };

            // Act
            var result = controller.SendOnderhoudsopdracht(onderhoudsopdracht);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IActionResult));

            loggerMock.Verify(x => x.Log(It.IsAny<LogMessage>()), Times.Never());
            loggerMock.Verify(x => x.LogException(It.IsAny<LogMessage>()), Times.Never());
        }

        [TestMethod]
        public void SendOnderhoudsopdrachtWithValidViewModelCallsOnderhoudBeheerService()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<Onderhoudsopdracht, long>>(MockBehavior.Strict);

            var loggerMock = new Mock<ILogService>(MockBehavior.Strict);
            loggerMock.Setup(x => x.Log(It.IsAny<LogMessage>()));
            loggerMock.Setup(x => x.LogException(It.IsAny<LogMessage>()));

            OnderhoudsopdrachtenController controller = new OnderhoudsopdrachtenController(_onderhoudBeheerServiceAgent, repositoryMock.Object, loggerMock.Object);

            OnderhoudsopdrachtViewModel onderhoudsopdracht = new OnderhoudsopdrachtViewModel()
            {
                Kenteken = "DF-RE-60",
                Kilometerstand = 100000,
                OnderhoudOmschrijving = "Uitlaat is lek",
                IsAPKKeuring = false,
                BestuurderNaam = "Rob",
                TelefoonNrBestuurder ="123"
            };

            // Act
            var result = controller.SendOnderhoudsopdracht(onderhoudsopdracht);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, _onderhoudBeheerServiceAgent.AddOnderhoudsopdrachtTimesCalled);
            Assert.IsInstanceOfType(result, typeof(IActionResult));

            loggerMock.Verify(x => x.Log(It.IsAny<LogMessage>()), Times.Never());
            loggerMock.Verify(x => x.LogException(It.IsAny<LogMessage>()), Times.Never());
        }

        [TestMethod]
        public void SendOnderhoudsopdrachtWithInvalidViewModelNotCallsOnderhoudBeheerService()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<Onderhoudsopdracht, long>>(MockBehavior.Strict);

            var loggerMock = new Mock<ILogService>(MockBehavior.Strict);
            loggerMock.Setup(x => x.Log(It.IsAny<LogMessage>()));
            loggerMock.Setup(x => x.LogException(It.IsAny<LogMessage>()));

            OnderhoudsopdrachtenController controller = new OnderhoudsopdrachtenController(_onderhoudBeheerServiceAgent, repositoryMock.Object, loggerMock.Object);
            controller.ModelState.AddModelError("error", "Kilometerstand moet minimaal 0 zijn");

            OnderhoudsopdrachtViewModel onderhoudsopdracht = new OnderhoudsopdrachtViewModel()
            {
                Kenteken = "DF-RE-60",
                Kilometerstand = -1,
                OnderhoudOmschrijving = "Uitlaat is lek",
                IsAPKKeuring = false,
            };

            // Act
            var result = controller.SendOnderhoudsopdracht(onderhoudsopdracht);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull((result as ViewResult).Model);
            Assert.AreEqual(0, _onderhoudBeheerServiceAgent.AddOnderhoudsopdrachtTimesCalled);
            Assert.IsInstanceOfType(result, typeof(IActionResult));

            loggerMock.Verify(x => x.Log(It.IsAny<LogMessage>()), Times.Never());
            loggerMock.Verify(x => x.LogException(It.IsAny<LogMessage>()), Times.Never());
        }

        [TestMethod]
        public void SendOnderhoudsopdrachtWithFailingAgentReturnsMessage()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<Onderhoudsopdracht, long>>(MockBehavior.Strict);

            var loggerMock = new Mock<ILogService>(MockBehavior.Strict);
            loggerMock.Setup(x => x.Log(It.IsAny<LogMessage>()));
            loggerMock.Setup(x => x.LogException(It.IsAny<LogMessage>()));

            OnderhoudsopdrachtenController controller = new OnderhoudsopdrachtenController(_onderhoudBeheerServiceExceptionAgent, repositoryMock.Object, loggerMock.Object);

            OnderhoudsopdrachtViewModel onderhoudsopdracht = new OnderhoudsopdrachtViewModel()
            {
                Kenteken = "DF-RE-60",
                Kilometerstand = 100000,
                OnderhoudOmschrijving = "Uitlaat is lek",
                IsAPKKeuring = false,
                BestuurderNaam = "Rob",
                TelefoonNrBestuurder = "1234"
            };

            // Act
            var result = controller.SendOnderhoudsopdracht(onderhoudsopdracht);

            // Assert
            ViewResult viewResult = (result as ViewResult);
            OnderhoudsopdrachtViewModel resultViewModel = (viewResult.Model as OnderhoudsopdrachtViewModel);
            Assert.AreEqual(1, _onderhoudBeheerServiceExceptionAgent.AddOnderhoudsopdrachtTimesCalled);
            Assert.AreEqual((string)controller.ViewData["FeedbackMessage"], "Sorry, de service is op dit niet beschikbaar. Probeer het later opnieuw.");
            Assert.AreEqual(onderhoudsopdracht.Kenteken, resultViewModel.Kenteken);

            loggerMock.Verify(x => x.Log(It.IsAny<LogMessage>()), Times.Never());
            loggerMock.Verify(x => x.LogException(It.IsAny<LogMessage>()), Times.Once());
        }
    }
}
