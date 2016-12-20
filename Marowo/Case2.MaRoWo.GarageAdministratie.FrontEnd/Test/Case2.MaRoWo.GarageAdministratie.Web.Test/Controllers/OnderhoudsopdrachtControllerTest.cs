using Case2.MaRoWo.GarageAdministratie.Facade.Controllers;
using Case2.MaRoWo.GarageAdministratie.Facade.Test.Mocks;
using Case2.MaRoWo.GarageAdministratie.Facade.Test.Repositories;
using Case2.MaRoWo.GarageAdministratie.Facade.ViewModels;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database.Entities;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Case2.MaRoWo.GarageAdministratie.Facade.Test.Controllers
{
    [TestClass]
    public class OnderhoudsopdrachtControllerTest
    {
        private DbContextOptions<GarageAdministratieContext> _options;


        [TestInitialize]
        public void Init()
        {
            // Use InMemory database for testing, records are not removed afterwards from Local Database
            //_options = TestDatabaseProvider.CreateInMemoryDatabaseOptions();
            _options = TestDatabaseProvider.CreateMsSQLDatabaseOptions();
        }

        [TestCleanup]
        public void CleanUp()
        {
            using (var context = new GarageAdministratieContext(_options))
            {
                context.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public void IndexReturnsIActionResult()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<Onderhoudsopdracht, long>>(MockBehavior.Strict);
            repositoryMock.Setup(repository => repository.Exists(It.IsAny<long>())).Returns(false);
            OnderhoudBeheerServiceAgentMock onderhoudsbeheerServiceAgentMock = new OnderhoudBeheerServiceAgentMock();
            long onderhoudsId = 1;

            OnderhoudsopdrachtController controller = new OnderhoudsopdrachtController(onderhoudsbeheerServiceAgentMock, repositoryMock.Object);

            // Act
            var result = controller.Index(onderhoudsId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IActionResult));
        }

        [TestMethod]
        public void IndexWithNotExistingOnderhoudsIdReturnsRedirectToActionResult()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<Onderhoudsopdracht, long>>(MockBehavior.Strict);
            repositoryMock.Setup(repository => repository.Exists(It.IsAny<long>())).Returns(false);
            OnderhoudBeheerServiceAgentMock onderhoudsbeheerServiceAgentMock = new OnderhoudBeheerServiceAgentMock();
            long onderhoudsId = 1;

            OnderhoudsopdrachtController controller = new OnderhoudsopdrachtController(onderhoudsbeheerServiceAgentMock, repositoryMock.Object);

            // Act
            var result = controller.Index(onderhoudsId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void IndexReturnsViewResultWithOnderhoudsopdrachtViewModel()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<Onderhoudsopdracht, long>>(MockBehavior.Strict);
            repositoryMock.Setup(repository => repository.Exists(It.IsAny<long>())).Returns(true);
            repositoryMock.Setup(repository => repository.Find(It.IsAny<long>())).Returns(new Onderhoudsopdracht());
            OnderhoudBeheerServiceAgentMock onderhoudsbeheerServiceAgentMock = new OnderhoudBeheerServiceAgentMock();
            long onderhoudsId = 1;

            OnderhoudsopdrachtController controller = new OnderhoudsopdrachtController(onderhoudsbeheerServiceAgentMock, repositoryMock.Object);

            // Act
            ViewResult result = (ViewResult)controller.Index(onderhoudsId);

            // Assert
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(OnderhoudsopdrachtViewModel));
        }

       [TestMethod]
        public void IndexWithOnderhoudsOpdrachtIdCallsRepository()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<Onderhoudsopdracht, long>>(MockBehavior.Strict);
            repositoryMock.Setup(repository => repository.Exists(It.IsAny<long>())).Returns(true);
            repositoryMock.Setup(repository => repository.Find(It.IsAny<long>())).Returns(new Onderhoudsopdracht());
            OnderhoudBeheerServiceAgentMock onderhoudsbeheerServiceAgentMock = new OnderhoudBeheerServiceAgentMock();
            long onderhoudsId = 1;

            OnderhoudsopdrachtController controller = new OnderhoudsopdrachtController(onderhoudsbeheerServiceAgentMock, repositoryMock.Object);

            // Act
            ViewResult result = (ViewResult)controller.Index(onderhoudsId);

            // Assert
            repositoryMock.Verify(repo => repo.Exists(It.IsAny<long>()), Times.Once());
            repositoryMock.Verify(repo => repo.Find(It.IsAny<long>()), Times.Once());
        }

        [TestMethod]
        public void OnderhoudsopdrachtUpdatenReturnsRedirectToActionResult()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<Onderhoudsopdracht, long>>(MockBehavior.Strict);
            repositoryMock.Setup(repository => repository.Exists(It.IsAny<long>())).Returns(true);
            repositoryMock.Setup(repository => repository.Find(It.IsAny<long>())).Returns(new Onderhoudsopdracht());
            OnderhoudBeheerServiceAgentMock onderhoudsbeheerServiceAgentMock = new OnderhoudBeheerServiceAgentMock();
            long onderhoudsId = 1;

            OnderhoudsopdrachtController controller = new OnderhoudsopdrachtController(onderhoudsbeheerServiceAgentMock, repositoryMock.Object);

            // Act
            var result = controller.OnderhoudsopdrachtUpdaten(onderhoudsId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            Assert.AreEqual("Onderhoudsopdrachten", ((RedirectToActionResult)result).ControllerName);
            Assert.AreEqual("Index", ((RedirectToActionResult)result).ActionName);
        }

        [TestMethod]
        public void OnderhoudsopdrachtUpdatenCallsOnderhoudsBeheerServiceAgent()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<Onderhoudsopdracht, long>>(MockBehavior.Strict);
            repositoryMock.Setup(repository => repository.Exists(It.IsAny<long>())).Returns(true);
            repositoryMock.Setup(repository => repository.Find(It.IsAny<long>())).Returns(new Onderhoudsopdracht());
            OnderhoudBeheerServiceAgentMock onderhoudsbeheerServiceAgentMock = new OnderhoudBeheerServiceAgentMock();
            long onderhoudsId = 1;

            OnderhoudsopdrachtController controller = new OnderhoudsopdrachtController(onderhoudsbeheerServiceAgentMock, repositoryMock.Object);

            // Act
            var result = controller.OnderhoudsopdrachtUpdaten(onderhoudsId);

            // Assert
            Assert.AreEqual(1, onderhoudsbeheerServiceAgentMock.UpdateOnderhoudsopdrachtTimesCalled);
        }

        [TestMethod]
        public void OnderhoudsopdrachtUpdatenCallsWithNotExistingOnderhoudsIdNotCallsOnderhoudsBeheerServiceAgent()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<Onderhoudsopdracht, long>>(MockBehavior.Strict);
            repositoryMock.Setup(repository => repository.Exists(It.IsAny<long>())).Returns(false);
            repositoryMock.Setup(repository => repository.Find(It.IsAny<long>())).Returns(new Onderhoudsopdracht());
            OnderhoudBeheerServiceAgentMock onderhoudsbeheerServiceAgentMock = new OnderhoudBeheerServiceAgentMock();
            long onderhoudsId = 1;

            OnderhoudsopdrachtController controller = new OnderhoudsopdrachtController(onderhoudsbeheerServiceAgentMock, repositoryMock.Object);

            // Act
            var result = controller.OnderhoudsopdrachtUpdaten(onderhoudsId);

            // Assert
            Assert.AreEqual(0, onderhoudsbeheerServiceAgentMock.UpdateOnderhoudsopdrachtTimesCalled);
        }

        [TestMethod]
        public void OnderhoudsopdrachtUpdatenCallsWithNotExistingOnderhoudsIdReturnsRedirectToActionResult()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<Onderhoudsopdracht, long>>(MockBehavior.Strict);
            repositoryMock.Setup(repository => repository.Exists(It.IsAny<long>())).Returns(false);
            repositoryMock.Setup(repository => repository.Find(It.IsAny<long>())).Returns(new Onderhoudsopdracht());
            OnderhoudBeheerServiceAgentMock onderhoudsbeheerServiceAgentMock = new OnderhoudBeheerServiceAgentMock();
            long onderhoudsId = 1;

            OnderhoudsopdrachtController controller = new OnderhoudsopdrachtController(onderhoudsbeheerServiceAgentMock, repositoryMock.Object);

            // Act
            var result = controller.OnderhoudsopdrachtUpdaten(onderhoudsId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            Assert.AreEqual("Onderhoudsopdrachten", ((RedirectToActionResult)result).ControllerName);
            Assert.AreEqual("Index", ((RedirectToActionResult)result).ActionName);
        }

        [TestMethod]
        public void OnderhoudsopdrachtAfmeldenReturnsRedirectToActionResult()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<Onderhoudsopdracht, long>>(MockBehavior.Strict);
            repositoryMock.Setup(repository => repository.Exists(It.IsAny<long>())).Returns(true);
            repositoryMock.Setup(repository => repository.Find(It.IsAny<long>())).Returns(new Onderhoudsopdracht());
            OnderhoudBeheerServiceAgentMock onderhoudsbeheerServiceAgentMock = new OnderhoudBeheerServiceAgentMock();
            long onderhoudsId = 1;

            OnderhoudsopdrachtController controller = new OnderhoudsopdrachtController(onderhoudsbeheerServiceAgentMock, repositoryMock.Object);

            // Act
            var result = controller.OnderhoudsopdrachtAfmelden(onderhoudsId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            Assert.AreEqual("Onderhoudsopdrachten",((RedirectToActionResult)result).ControllerName);
            Assert.AreEqual("Index", ((RedirectToActionResult)result).ActionName);
        }

        [TestMethod]
        public void OnderhoudsopdrachtAfmeldenCallsOnderhoudsBeheerServiceAgent()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<Onderhoudsopdracht, long>>(MockBehavior.Strict);
            repositoryMock.Setup(repository => repository.Exists(It.IsAny<long>())).Returns(true);
            repositoryMock.Setup(repository => repository.Find(It.IsAny<long>())).Returns(new Onderhoudsopdracht());
            OnderhoudBeheerServiceAgentMock onderhoudsbeheerServiceAgentMock = new OnderhoudBeheerServiceAgentMock();
            long onderhoudsId = 1;

            OnderhoudsopdrachtController controller = new OnderhoudsopdrachtController(onderhoudsbeheerServiceAgentMock, repositoryMock.Object);

            // Act
            var result = controller.OnderhoudsopdrachtAfmelden(onderhoudsId);

            // Assert
            Assert.AreEqual(1, onderhoudsbeheerServiceAgentMock.OnderhoudsopdrachtAfmeldenTimesCalled);
        }

        [TestMethod]
        public void OnderhoudsopdrachtAfmeldenCallsWithNotExistingOnderhoudsIdNotCallsOnderhoudsBeheerServiceAgent()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<Onderhoudsopdracht, long>>(MockBehavior.Strict);
            repositoryMock.Setup(repository => repository.Exists(It.IsAny<long>())).Returns(false);
            repositoryMock.Setup(repository => repository.Find(It.IsAny<long>())).Returns(new Onderhoudsopdracht());
            OnderhoudBeheerServiceAgentMock onderhoudsbeheerServiceAgentMock = new OnderhoudBeheerServiceAgentMock();
            long onderhoudsId = 1;

            OnderhoudsopdrachtController controller = new OnderhoudsopdrachtController(onderhoudsbeheerServiceAgentMock, repositoryMock.Object);

            // Act
            var result = controller.OnderhoudsopdrachtAfmelden(onderhoudsId);

            // Assert
            Assert.AreEqual(0, onderhoudsbeheerServiceAgentMock.OnderhoudsopdrachtAfmeldenTimesCalled);
        }

        [TestMethod]
        public void OnderhoudsopdrachtAfmeldenCallsWithNotExistingOnderhoudsIdReturnsRedirectToActionResult()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<Onderhoudsopdracht, long>>(MockBehavior.Strict);
            repositoryMock.Setup(repository => repository.Exists(It.IsAny<long>())).Returns(false);
            repositoryMock.Setup(repository => repository.Find(It.IsAny<long>())).Returns(new Onderhoudsopdracht());
            OnderhoudBeheerServiceAgentMock onderhoudsbeheerServiceAgentMock = new OnderhoudBeheerServiceAgentMock();
            long onderhoudsId = 1;

            OnderhoudsopdrachtController controller = new OnderhoudsopdrachtController(onderhoudsbeheerServiceAgentMock, repositoryMock.Object);

            // Act
            var result = controller.OnderhoudsopdrachtAfmelden(onderhoudsId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }
    }
}
