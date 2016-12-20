using EventBus.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EventAuditLog.Test
{
    [TestClass]
    public class EventAuditLogTest
    {
        [TestMethod]
        public void EventAuditLogRecieveTest()
        {
            //Arrange
            // Arrange
            var eventPublisher = new EventPublisher();
            var gameRoomEvent = new GameRoomEventMock("Minor.WSA.GameRoom.Created")
            {
                GameRoomId = 1,
                GameRoomName = "Chess-01"
            };

            using (var eventAuditLog = new AuditLog())
            {
                //Act
                eventPublisher.Publish(gameRoomEvent);

                Thread.Sleep(1000);


                //Assert
                Assert.AreEqual(1, eventAuditLog._eventList.Count);
                Assert.AreEqual(gameRoomEvent.GetType().FullName, eventAuditLog._eventList.First().Type);
                Assert.AreEqual(gameRoomEvent.RoutingKey, eventAuditLog._eventList.First().RoutingKey);

                var deserializedEventObject = (GameRoomEventMock)JsonConvert.DeserializeObject(eventAuditLog._eventList.First().EventMessage, typeof(GameRoomEventMock));

                Assert.AreEqual(gameRoomEvent.GameRoomId, deserializedEventObject.GameRoomId);
                Assert.AreEqual(gameRoomEvent.GameRoomName, deserializedEventObject.GameRoomName);
                Assert.AreEqual(gameRoomEvent.CorrelationId, deserializedEventObject.CorrelationId);
            }

        }

        [TestMethod]
        public void EventAuditLogMultipleRecieveTest()
        {
            //Arrange
            // Arrange
            var eventPublisher = new EventPublisher();
            GameRoomEventMock gameRoomEvent = new GameRoomEventMock("Minor.WSA.GameRoom.Created")
            {
                GameRoomId = 1,
                GameRoomName = "Chess-01"
            };

            var target = new List<GameRoomEventMock>();
            target.Add(gameRoomEvent);
            target.Add(gameRoomEvent);


            using (var eventAuditLog = new AuditLog())
            {
                //Act
                eventPublisher.Publish(gameRoomEvent);
                eventPublisher.Publish(gameRoomEvent);

                Thread.Sleep(1000);


                //Assert
                Assert.AreEqual(target.Count, eventAuditLog._eventList.Count);

                foreach (var mockEvent in eventAuditLog._eventList)
                {
                    Assert.AreEqual(gameRoomEvent.GetType().FullName, eventAuditLog._eventList.First().Type);
                    Assert.AreEqual(gameRoomEvent.RoutingKey, eventAuditLog._eventList.First().RoutingKey);

                    var result = (GameRoomEventMock)JsonConvert.DeserializeObject(mockEvent.EventMessage, typeof(GameRoomEventMock));


                    Assert.AreEqual(gameRoomEvent.GameRoomId, result.GameRoomId);
                    Assert.AreEqual(gameRoomEvent.GameRoomName, result.GameRoomName);
                    Assert.AreEqual(gameRoomEvent.CorrelationId, result.CorrelationId);

                }

            }

        }
    }
}
