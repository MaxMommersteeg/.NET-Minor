using Case2.MaRoWo.Logger.Entities;
using Case2.MaRoWo.Logger.Services;
using Case2.MaRoWo.RDW.IntegrationService.Facade.Controllers;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Converters;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Incoming;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Case2.MaRoWo.RDW.IntegrationService.Facade.Test.Controllers {
    [TestClass]
    public class ApkControllerTest
    {
        [TestMethod]
        public void MakeValidApkRequestPostTest() 
        {
            // Arrange
            var managerMock = new Mock<IRdwApkManager>(MockBehavior.Strict);

            var logServiceMock = new Mock<ILogService>(MockBehavior.Strict);
            logServiceMock.Setup(x => x.Log(It.IsAny<LogMessage>()));
            logServiceMock.Setup(x => x.LogException(It.IsAny<LogMessage>()));

            var rwdResult = new KeuringsVerzoekAntwoord();
            managerMock.Setup(x => x.HandleApkKeuringsVerzoek(It.IsAny<ApkKeuringsVerzoekCommand>())).Returns(rwdResult);
            var controller = new ApkController(managerMock.Object, logServiceMock.Object);

            // Act
            var result = controller.Post(new ApkKeuringsVerzoekCommand());

            // Assert
            managerMock.Verify(x => x.HandleApkKeuringsVerzoek(It.IsAny<ApkKeuringsVerzoekCommand>()), Times.Once());
            logServiceMock.Verify(x => x.Log(It.IsAny<LogMessage>()), Times.Never());
            logServiceMock.Verify(x => x.LogException(It.IsAny<LogMessage>()), Times.Never());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }

        [TestMethod]
        public void MakeInvalidApkRequestPostTest() 
        {
            // Arrange
            var managerMock = new Mock<IRdwApkManager>(MockBehavior.Strict);

            var logServiceMock = new Mock<ILogService>(MockBehavior.Strict);
            logServiceMock.Setup(x => x.Log(It.IsAny<LogMessage>()));
            logServiceMock.Setup(x => x.LogException(It.IsAny<LogMessage>()));

            var rwdResult = new KeuringsVerzoekAntwoord();
            managerMock.Setup(x => x.HandleApkKeuringsVerzoek(It.IsAny<ApkKeuringsVerzoekCommand>())).Returns(rwdResult);
            var controller = new ApkController(managerMock.Object, logServiceMock.Object);
            controller.ModelState.AddModelError("error", "testerror");

            // Act
            var result = controller.Post(new ApkKeuringsVerzoekCommand());

            // Assert
            managerMock.Verify(x => x.HandleApkKeuringsVerzoek(It.IsAny<ApkKeuringsVerzoekCommand>()), Times.Never());
            logServiceMock.Verify(x => x.Log(It.IsAny<LogMessage>()), Times.Once());
            logServiceMock.Verify(x => x.LogException(It.IsAny<LogMessage>()), Times.Never());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
    }
}
