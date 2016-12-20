using Common.Infrastructure;
using EventAuditLog;
using EventBus.Infrastructure;
using EventBus.Test.Infrastructure.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EventBus.Test.Infrastructure
{
    [TestClass]
    public class AuditLogAgentTest
    {
        [TestMethod]
        public void AuditLogAgentOptionsTest()
        {
            //Assert
            var agentOptions = new AuditLogAgentCommandOptions();

            using (var auditLog = new AuditLog())
            using (var eventDispatcher = new EventDispatcherMock(auditLog))
            {
                
                //Act
                eventDispatcher.UpdateFromAuditLog();

                //Assert

                Assert.AreEqual(agentOptions.StartDate, eventDispatcher.AgentOptions.StartDate);
                Assert.AreEqual(agentOptions.EndDate, eventDispatcher.AgentOptions.EndDate);
                Assert.AreEqual(agentOptions.RoutingKeyFilter, eventDispatcher.AgentOptions.RoutingKeyFilter);


            }
        }

        [TestMethod]
        public void AuditLogAgentSendCommand()
        {
            //Assert
            var agentOptions = new AuditLogAgentCommandOptions();

            using (var auditLog = new AuditLog())
            using (var eventDispatcher = new EventDispatcherMock(auditLog))
            {
                //Act
                eventDispatcher.UpdateFromAuditLog();

                Thread.Sleep(1000);

                //Assert
                Assert.AreEqual(1, auditLog.auditLogCommandsRecieved.Count);
                Assert.AreEqual(agentOptions.StartDate, auditLog.auditLogCommandsRecieved.First().StartDate);
                Assert.AreEqual(agentOptions.EndDate, auditLog.auditLogCommandsRecieved.First().EndDate);
                Assert.AreEqual(agentOptions.RoutingKeyFilter, auditLog.auditLogCommandsRecieved.First().RoutingKeyFilter);
            }
        }

        [TestMethod]
        public void AuditLogAgentSendEvents()
        {
            //Assert



            var agentOptions = new AuditLogAgentCommandOptions();


            using (var auditLog = new AuditLog())
            {
                var eventPublisher = new EventPublisher();
                var gameRoomEvent = new GameRoomEventMock("Minor.WSA.GameRoom.Created");
                gameRoomEvent.GameRoomId = 1;
                gameRoomEvent.GameRoomName = "Chess-01";

                eventPublisher.Publish(gameRoomEvent);



                using (var eventDispatcher = new EventDispatcherMock(auditLog))
                {
                    Thread.Sleep(1000);

                    //Act
                    eventDispatcher.UpdateFromAuditLog();
                    Thread.Sleep(1000);


                    //Assert
                    Assert.AreEqual(1, eventDispatcher.GameRoomCreatedCalled);
                }
            }
        }
    }
}
