using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Minor.WSA.Infrastructure.Test
{
    [TestClass]
    public class EventPublisherTest
    {
        [TestMethod]
        public void PublisherPublishes()
        {
            var _options = BusOptions.GetDefaultOptions();
            // Arrange
            var factory = new ConnectionFactory()
            {
                HostName = _options.HostName,
                Port = _options.Port,
                UserName = _options.UserName,
                Password = _options.Password,
            };
            using (var target = new EventPublisher())
            using (var _connection = factory.CreateConnection())
            using (var _channel = _connection.CreateModel())
            {
                var ExchangeName = _options.ExchangeName;

                string queueName = _channel.QueueDeclare().QueueName;

                _channel.QueueBind(exchange: ExchangeName,
                                   queue: queueName,
                                   routingKey: "#",
                                   arguments: null);

                var consumer = new EventingBasicConsumer(_channel);
                bool messageReceived = false;
                BasicDeliverEventArgs eventargs = null;
                consumer.Received += (object sender, BasicDeliverEventArgs e) =>
                {
                    messageReceived = true;
                    eventargs = e;
                };

                _channel.BasicConsume(queue: queueName,
                                      noAck: true,
                                      consumer: consumer);

                // Act
                var evt = new SomeEvent() { SomeNumber = 7, SomeName = "Foo" };
                target.Publish(evt);

                // Assert
                Thread.Sleep(1000);
                Assert.IsTrue(messageReceived);
                Assert.IsNotNull(eventargs);
                Assert.AreEqual("Minor.WSA.Infrastructure.Test.SomeEvent", eventargs.BasicProperties.Type);
                SomeEvent result = (SomeEvent) JsonConvert.DeserializeObject(
                    Encoding.Unicode.GetString(eventargs.Body),
                    evt.GetType());
                Assert.AreEqual(evt.Timestamp, result.Timestamp);
                Assert.AreEqual("Minor.WSA.SomeEvent", result.RoutingKey);
                Assert.AreEqual(7, result.SomeNumber);
                Assert.AreEqual("Foo", result.SomeName);
            }
        }
    }
}
