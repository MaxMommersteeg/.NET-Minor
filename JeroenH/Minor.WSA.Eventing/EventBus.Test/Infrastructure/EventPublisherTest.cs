using Common.Infrastructure;
using EventBus.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RabbitMQ.Client;

namespace EventBus.Test.Infrastructure
{
    [TestClass]
    public class EventPublisherTest
    {
        [TestMethod]
        public void EventPublisherBusOptionsNullExpectDefaultTest()
        {
            // Arrange
            var factory = new ConnectionFactory() { HostName = new BusOptions().HostName };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var eventPublishService = new EventPublishService(connection, channel);

                // Act
                var expectedBusOptions = new BusOptions();

                // Assert
                Assert.AreEqual(expectedBusOptions.ExchangeName, eventPublishService.BusOptions.ExchangeName);
                Assert.AreEqual(expectedBusOptions.QueueName, eventPublishService.BusOptions.QueueName);
                Assert.AreEqual(expectedBusOptions.HostName, eventPublishService.BusOptions.HostName);
                Assert.AreEqual(expectedBusOptions.Port, eventPublishService.BusOptions.Port);
                Assert.AreEqual(expectedBusOptions.UserName, eventPublishService.BusOptions.UserName);
                Assert.AreEqual(expectedBusOptions.Password, eventPublishService.BusOptions.Password);
            }
        }
    }
}
