using Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Entities;
using Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Infrastructure;
using Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Services;
using Case2.MaRoWo.OnderhoudBeheer.Service.Incoming.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.RoWe.Common.Events;
using Minor.RoWe.Common.Interfaces;
using Moq;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Test.Services
{
    [TestClass]
    public class OnderhoudsopdrachtServiceTest
    {
        [TestMethod]
        public void AddOnderhoudsopdrachtDependenciesAreCalled()
        {
            // Arrange
            var onderhoudsopdrachtRepoMock = new Mock<IRepository<Onderhoudsopdracht, long>>(MockBehavior.Strict);
            onderhoudsopdrachtRepoMock.Setup(x => x.Insert(It.IsAny<Onderhoudsopdracht>())).Returns(1);

            var eventPublisherMock = new Mock<IEventPublisher>(MockBehavior.Strict);
            eventPublisherMock.Setup(x => x.Publish(It.IsAny<DomainEvent>()));

            var target = new OnderhoudsopdrachtService(onderhoudsopdrachtRepoMock.Object, eventPublisherMock.Object);

            // Act
            target.AddOnderhoudsopdracht(new CreateOnderhoudCommand());

            // Assert
            onderhoudsopdrachtRepoMock.Verify(x => x.Insert(It.IsAny<Onderhoudsopdracht>()), Times.Once());
            eventPublisherMock.Verify(x => x.Publish(It.IsAny<DomainEvent>()), Times.Once());
        }

        [TestMethod]
        public void UpdateOnderhoudsopdrachtDependenciesAreCalled()
        {
            // Arrange
            var onderhoudsopdrachtRepoMock = new Mock<IRepository<Onderhoudsopdracht, long>>(MockBehavior.Strict);
            onderhoudsopdrachtRepoMock.Setup(x => x.Update(It.IsAny<Onderhoudsopdracht>()));

            var eventPublisherMock = new Mock<IEventPublisher>(MockBehavior.Strict);
            eventPublisherMock.Setup(x => x.Publish(It.IsAny<DomainEvent>()));

            var onderhoudopdrachtService = new OnderhoudsopdrachtService(onderhoudsopdrachtRepoMock.Object, eventPublisherMock.Object);

            // Act
            onderhoudopdrachtService.UpdateOnderhoudsopdracht(new UpdateOnderhoudCommand());

            // Assert
            onderhoudsopdrachtRepoMock.Verify(x => x.Update(It.IsAny<Onderhoudsopdracht>()), Times.Once());
            eventPublisherMock.Verify(x => x.Publish(It.IsAny<DomainEvent>()), Times.Once());
        }
    }
}
