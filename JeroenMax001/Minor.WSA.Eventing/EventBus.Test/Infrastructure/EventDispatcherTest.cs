using Common.Event;
using Common.Infrastructure;
using EventAuditLog;
using EventBus.Infrastructure;
using EventBus.Test.Infrastructure.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace EventBus.Test.Infrastructure
{
    [TestClass]
    public class EventDispatcherTest
    {
        [TestMethod]
        public void EventDispatcherBusOptionsNullExpectDefaultTest()
        {
            // Arrange
            using (var auditLog = new AuditLog())
            using (var eventDispatcher = new EventDispatcherMock(auditLog))
            {
                // Act
                var expectedBusOptions = new BusOptions();

                // Assert
                Assert.AreEqual(expectedBusOptions.ExchangeName, eventDispatcher.BusOptions.ExchangeName);
                Assert.AreEqual(expectedBusOptions.HostName, eventDispatcher.BusOptions.HostName);
                Assert.AreEqual(expectedBusOptions.Port, eventDispatcher.BusOptions.Port);
                Assert.AreEqual(expectedBusOptions.UserName, eventDispatcher.BusOptions.UserName);
                Assert.AreEqual(expectedBusOptions.Password, eventDispatcher.BusOptions.Password);

                Assert.IsNotNull(eventDispatcher.BusOptions);
            }
        }

        [TestMethod]
        public void EventDispatcherBusOptionsNotNullExpectGivenValuesTest()
        {
            // Arrange
            var expectedBusOptions = new BusOptions
            {
                ExchangeName = "Exchange",
                HostName = "localhost",
                UserName = "Username",
                Password = "Password",
                Port = 123987
            };

            // Act
            using (var auditLog = new AuditLog())
            using (var eventDispatcher = new EventDispatcherMock(auditLog,expectedBusOptions))
            {
                // Assert
                Assert.AreEqual(expectedBusOptions.ExchangeName, eventDispatcher.BusOptions.ExchangeName);
                Assert.AreEqual(expectedBusOptions.HostName, eventDispatcher.BusOptions.HostName);
                Assert.AreEqual(expectedBusOptions.Port, eventDispatcher.BusOptions.Port);
                Assert.AreEqual(expectedBusOptions.UserName, eventDispatcher.BusOptions.UserName);
                Assert.AreEqual(expectedBusOptions.Password, eventDispatcher.BusOptions.Password);
            }
        }

        [TestMethod]
        public void EventDispatcherSendReceiveTest()
        {
            // Arrange
            var eventPublisher = new EventPublisher();
            var gameRoomEvent = new GameRoomEventMock("Minor.WSA.GameRoom.Created");
            gameRoomEvent.GameRoomId = 1;
            gameRoomEvent.GameRoomName = "Chess-01";

            using (var auditLog = new AuditLog())
            using (var eventDispatcherMock = new EventDispatcherMock(auditLog))
            {
                // Act
                eventPublisher.Publish(gameRoomEvent);

                Thread.Sleep(1000);

                // Assert
                Assert.AreEqual(1, eventDispatcherMock.GameRoomCreatedCalled);
                Assert.AreEqual(gameRoomEvent.GameRoomId, eventDispatcherMock.GameRoomEventMock.GameRoomId);
                Assert.AreEqual(gameRoomEvent.GameRoomName, eventDispatcherMock.GameRoomEventMock.GameRoomName);
                Assert.AreEqual(gameRoomEvent.RoutingKey, eventDispatcherMock.GameRoomEventMock.RoutingKey);
                Assert.AreEqual(gameRoomEvent.CorrelationId, eventDispatcherMock.GameRoomEventMock.CorrelationId);
            }
        }
    }
}
