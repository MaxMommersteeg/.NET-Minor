using Case2.MaRoWo.Logger.Entities;
using Case2.MaRoWo.Logger.Services;
using Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Services;
using Case2.MaRoWo.OnderhoudBeheer.Service.Facade.Controllers;
using Case2.MaRoWo.OnderhoudBeheer.Service.Facade.ResultModels;
using Case2.MaRoWo.OnderhoudBeheer.Service.Incoming.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Facade.Test.Controllers
{
    [TestClass]
    public class OnderhoudControllerTest
    {
        [TestMethod]
        public void ValidAddOnderhoudsopdrachtPostTest()
        {
            // Arrange
            var logServiceMock = new Mock<ILogService>(MockBehavior.Strict);
            logServiceMock.Setup(x => x.Log(It.IsAny<LogMessage>()));
            logServiceMock.Setup(x => x.LogException(It.IsAny<LogMessage>()));

            var onderhoudsopdrachtServiceMock = new Mock<IOnderhoudsopdrachtService>(MockBehavior.Strict);
            onderhoudsopdrachtServiceMock.Setup(x => x.AddOnderhoudsopdracht(It.IsAny<CreateOnderhoudCommand>()));

            var controller = new OnderhoudController(onderhoudsopdrachtServiceMock.Object, logServiceMock.Object);

            // Act
            var result = controller.Post(new CreateOnderhoudCommand());

            // Assert
            onderhoudsopdrachtServiceMock.Verify(x => x.AddOnderhoudsopdracht(It.IsAny<CreateOnderhoudCommand>()), Times.Once());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkResult));

            logServiceMock.Verify(x => x.Log(It.IsAny<LogMessage>()), Times.Never());
            logServiceMock.Verify(x => x.LogException(It.IsAny<LogMessage>()), Times.Never());
        }

        [TestMethod]
        public void InvalidAddOnderhoudsopdrachtPostTest()
        {
            // Arrange
            var onderhoudsopdrachtServiceMock = new Mock<IOnderhoudsopdrachtService>(MockBehavior.Strict);
            onderhoudsopdrachtServiceMock.Setup(x => x.AddOnderhoudsopdracht(It.IsAny<CreateOnderhoudCommand>()));

            var logServiceMock = new Mock<ILogService>(MockBehavior.Strict);
            logServiceMock.Setup(x => x.Log(It.IsAny<LogMessage>()));
            logServiceMock.Setup(x => x.LogException(It.IsAny<LogMessage>()));

            var controller = new OnderhoudController(onderhoudsopdrachtServiceMock.Object, logServiceMock.Object);
            controller.ModelState.AddModelError("error", "testerror");

            // Act
            var result = controller.Post(new CreateOnderhoudCommand());

            // Assert
            onderhoudsopdrachtServiceMock.Verify(x => x.AddOnderhoudsopdracht(It.IsAny<CreateOnderhoudCommand>()), Times.Never());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

            var invalidRequest = (result as BadRequestObjectResult).Value as InvalidRequest;
            Assert.AreEqual("Request bevat: 1 fouten", invalidRequest.Message);

            logServiceMock.Verify(x => x.Log(It.IsAny<LogMessage>()), Times.Once());
            logServiceMock.Verify(x => x.LogException(It.IsAny<LogMessage>()), Times.Never());
        }

        [TestMethod]
        public void ValidAddOnderhoudsopdrachtPostDomainServiceExceptionTest()
        {
            // Arrange
            var onderhoudsopdrachtServiceMock = new Mock<IOnderhoudsopdrachtService>(MockBehavior.Strict);
            onderhoudsopdrachtServiceMock.Setup(x => x.AddOnderhoudsopdracht(It.IsAny<CreateOnderhoudCommand>())).Throws<Exception>();

            var logServiceMock = new Mock<ILogService>(MockBehavior.Strict);
            logServiceMock.Setup(x => x.Log(It.IsAny<LogMessage>()));
            logServiceMock.Setup(x => x.LogException(It.IsAny<LogMessage>()));

            var controller = new OnderhoudController(onderhoudsopdrachtServiceMock.Object, logServiceMock.Object);

            // Act
            var result = controller.Post(new CreateOnderhoudCommand());

            // Assert
            onderhoudsopdrachtServiceMock.Verify(x => x.AddOnderhoudsopdracht(It.IsAny<CreateOnderhoudCommand>()), Times.Once());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

            var invalidRequest = (result as BadRequestObjectResult).Value as InvalidRequest;
            Assert.AreEqual("Er ging iets mis. Onderhoud niet geplaatst.", invalidRequest.Message);
            Assert.AreEqual(0, invalidRequest.InvalidProperties.Count());

            logServiceMock.Verify(x => x.Log(It.IsAny<LogMessage>()), Times.Never());
            logServiceMock.Verify(x => x.LogException(It.IsAny<LogMessage>()), Times.Once());
        }

        [TestMethod]
        public void ValidUpdateOnderhoudsopdrachtPutTest()
        {
            // Arrange
            var logServiceMock = new Mock<ILogService>(MockBehavior.Strict);
            logServiceMock.Setup(x => x.Log(It.IsAny<LogMessage>()));
            logServiceMock.Setup(x => x.LogException(It.IsAny<LogMessage>()));

            var onderhoudsopdrachtServiceMock = new Mock<IOnderhoudsopdrachtService>(MockBehavior.Strict);
            onderhoudsopdrachtServiceMock.Setup(x => x.UpdateOnderhoudsopdracht(It.IsAny<UpdateOnderhoudCommand>()));

            var controller = new OnderhoudController(onderhoudsopdrachtServiceMock.Object, logServiceMock.Object);

            // Act
            var result = controller.Put(new UpdateOnderhoudCommand());

            // Assert
            onderhoudsopdrachtServiceMock.Verify(x => x.UpdateOnderhoudsopdracht(It.IsAny<UpdateOnderhoudCommand>()), Times.Once());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkResult));

            logServiceMock.Verify(x => x.Log(It.IsAny<LogMessage>()), Times.Never());
            logServiceMock.Verify(x => x.LogException(It.IsAny<LogMessage>()), Times.Never());
        }

        [TestMethod]
        public void InvalidUpdateOnderhoudsopdrachtPutTest()
        {
            // Arrange
            var onderhoudsopdrachtServiceMock = new Mock<IOnderhoudsopdrachtService>(MockBehavior.Strict);
            onderhoudsopdrachtServiceMock.Setup(x => x.UpdateOnderhoudsopdracht(It.IsAny<UpdateOnderhoudCommand>()));

            var logServiceMock = new Mock<ILogService>(MockBehavior.Strict);
            logServiceMock.Setup(x => x.Log(It.IsAny<LogMessage>()));
            logServiceMock.Setup(x => x.LogException(It.IsAny<LogMessage>()));

            var controller = new OnderhoudController(onderhoudsopdrachtServiceMock.Object, logServiceMock.Object);
            controller.ModelState.AddModelError("error", "testerror");

            // Act
            var result = controller.Put(new UpdateOnderhoudCommand());

            // Assert
            onderhoudsopdrachtServiceMock.Verify(x => x.UpdateOnderhoudsopdracht(It.IsAny<UpdateOnderhoudCommand>()), Times.Never());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

            var invalidRequest = (result as BadRequestObjectResult).Value as InvalidRequest;
            Assert.AreEqual("Request bevat: 1 fouten", invalidRequest.Message);

            logServiceMock.Verify(x => x.Log(It.IsAny<LogMessage>()), Times.Once());
            logServiceMock.Verify(x => x.LogException(It.IsAny<LogMessage>()), Times.Never());
        }

        [TestMethod]
        public void ValidUpdateOnderhoudsopdrachtPutDomainServiceExceptionTest()
        {
            // Arrange
            var onderhoudsopdrachtServiceMock = new Mock<IOnderhoudsopdrachtService>(MockBehavior.Strict);
            onderhoudsopdrachtServiceMock.Setup(x => x.UpdateOnderhoudsopdracht(It.IsAny<UpdateOnderhoudCommand>())).Throws<Exception>();

            var logServiceMock = new Mock<ILogService>(MockBehavior.Strict);
            logServiceMock.Setup(x => x.Log(It.IsAny<LogMessage>()));
            logServiceMock.Setup(x => x.LogException(It.IsAny<LogMessage>()));

            var controller = new OnderhoudController(onderhoudsopdrachtServiceMock.Object, logServiceMock.Object);

            // Act
            var result = controller.Put(new UpdateOnderhoudCommand());

            // Assert
            onderhoudsopdrachtServiceMock.Verify(x => x.UpdateOnderhoudsopdracht(It.IsAny<UpdateOnderhoudCommand>()), Times.Once());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

            var invalidRequest = (result as BadRequestObjectResult).Value as InvalidRequest;
            Assert.AreEqual("Er ging iets mis. Onderhoud niet geupdated.", invalidRequest.Message);
            Assert.AreEqual(0, invalidRequest.InvalidProperties.Count());

            logServiceMock.Verify(x => x.Log(It.IsAny<LogMessage>()), Times.Never());
            logServiceMock.Verify(x => x.LogException(It.IsAny<LogMessage>()), Times.Once());
        }

        [TestMethod]
        public void ValidOnderhoudsopdrachtAfmeldenTest()
        {
            // Arrange
            var logServiceMock = new Mock<ILogService>(MockBehavior.Strict);
            logServiceMock.Setup(x => x.Log(It.IsAny<LogMessage>()));
            logServiceMock.Setup(x => x.LogException(It.IsAny<LogMessage>()));

            var onderhoudsopdrachtServiceMock = new Mock<IOnderhoudsopdrachtService>(MockBehavior.Strict);
            onderhoudsopdrachtServiceMock.Setup(x => x.OnderhoudsopdrachtAfmelden(It.IsAny<OnderhoudAfmeldenCommand>()));

            var controller = new OnderhoudController(onderhoudsopdrachtServiceMock.Object, logServiceMock.Object);

            // Act
            var result = controller.OnderhoudsopdrachtAfmelden(new OnderhoudAfmeldenCommand());

            // Assert
            onderhoudsopdrachtServiceMock.Verify(x => x.OnderhoudsopdrachtAfmelden(It.IsAny<OnderhoudAfmeldenCommand>()), Times.Once());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkResult));

            logServiceMock.Verify(x => x.Log(It.IsAny<LogMessage>()), Times.Never());
            logServiceMock.Verify(x => x.LogException(It.IsAny<LogMessage>()), Times.Never());
        }

        [TestMethod]
        public void InvalidOnderhoudsopdrachtAfmeldenTest()
        {
            // Arrange
            var onderhoudsopdrachtServiceMock = new Mock<IOnderhoudsopdrachtService>(MockBehavior.Strict);
            onderhoudsopdrachtServiceMock.Setup(x => x.OnderhoudsopdrachtAfmelden(It.IsAny<OnderhoudAfmeldenCommand>()));

            var logServiceMock = new Mock<ILogService>(MockBehavior.Strict);
            logServiceMock.Setup(x => x.Log(It.IsAny<LogMessage>()));
            logServiceMock.Setup(x => x.LogException(It.IsAny<LogMessage>()));

            var controller = new OnderhoudController(onderhoudsopdrachtServiceMock.Object, logServiceMock.Object);
            controller.ModelState.AddModelError("error", "testerror");

            // Act
            var result = controller.OnderhoudsopdrachtAfmelden(new OnderhoudAfmeldenCommand());

            // Assert
            onderhoudsopdrachtServiceMock.Verify(x => x.OnderhoudsopdrachtAfmelden(It.IsAny<OnderhoudAfmeldenCommand>()), Times.Never());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

            var invalidRequest = (result as BadRequestObjectResult).Value as InvalidRequest;
            Assert.AreEqual("Request bevat: 1 fouten", invalidRequest.Message);

            logServiceMock.Verify(x => x.Log(It.IsAny<LogMessage>()), Times.Once());
            logServiceMock.Verify(x => x.LogException(It.IsAny<LogMessage>()), Times.Never());
        }

        [TestMethod]
        public void ValidOnderhoudsopdrachtAfmeldenDomainServiceExceptionTest()
        {
            // Arrange
            var onderhoudsopdrachtServiceMock = new Mock<IOnderhoudsopdrachtService>(MockBehavior.Strict);
            onderhoudsopdrachtServiceMock.Setup(x => x.OnderhoudsopdrachtAfmelden(It.IsAny<OnderhoudAfmeldenCommand>())).Throws<Exception>();

            var logServiceMock = new Mock<ILogService>(MockBehavior.Strict);
            logServiceMock.Setup(x => x.Log(It.IsAny<LogMessage>()));
            logServiceMock.Setup(x => x.LogException(It.IsAny<LogMessage>()));

            var controller = new OnderhoudController(onderhoudsopdrachtServiceMock.Object, logServiceMock.Object);

            // Act
            var result = controller.OnderhoudsopdrachtAfmelden(new OnderhoudAfmeldenCommand());

            // Assert
            onderhoudsopdrachtServiceMock.Verify(x => x.OnderhoudsopdrachtAfmelden(It.IsAny<OnderhoudAfmeldenCommand>()), Times.Once());

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

            var invalidRequest = (result as BadRequestObjectResult).Value as InvalidRequest;
            Assert.AreEqual("Er ging iets mis. Onderhoud niet afgemeld.", invalidRequest.Message);
            Assert.AreEqual(0, invalidRequest.InvalidProperties.Count());

            logServiceMock.Verify(x => x.Log(It.IsAny<LogMessage>()), Times.Never());
            logServiceMock.Verify(x => x.LogException(It.IsAny<LogMessage>()), Times.Once());
        }
    }
}
