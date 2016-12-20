using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.RoWe.Eventbus.Connectors;
using Minor.RoWe.Eventbus.Options;
using Minor.RoWe.Eventbus.Publishers;
using System;
using System.Diagnostics;
using System.Threading;

namespace Minor.RoWe.Eventbus.Test.PublisherTest
{
    [TestClass]
    public class EventPublisherTest
    {
        [TestInitialize]
        public void Startup()
        {

            using (var p = Process.Start("./DockerStart.bat"))
            {
                Thread.Sleep(10000);
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            
            using (var p = Process.Start("./DockerEnd.bat"))
            {
                Thread.Sleep(1000);
            }
        }

        [TestMethod]
        public void Test()
        {

            var option = new BusOptions()
            {
                ExchangeName = "Unit Test",
                HostName = "localhost",
                Port = 7000,
                QueueName = "TestQueue"
            };
            var flag = new AutoResetEvent(false);
            using (var connection = new RabbitMqConnection(option))
            using (var publisher = new EventPublisher(connection))
            using (var dis = new DispatcherMock(connection, flag))
            {
                dis.StartListening();
                publisher.Publish(new TestEvent()
                {
                    CorrelationID = new Guid(),
                    RoutingKey = "Test",
                    TimeStamp = DateTime.Now,
                    TestString = "Hello, World!"

                });
                flag.WaitOne();
                Assert.IsTrue(dis.Handled);
                Assert.AreEqual("Hello, World!", dis.Event.TestString);
            }         


        }
    }
}
