using Minor.WSA.Common;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace Minor.WSA.Infrastructure
{
    public class EventPublisher : IEventPublisher, IDisposable
    {
        private IConnection _connection;
        private IModel _channel;
        private string _exchangeName;
        private BusOptions _options;

        public EventPublisher(BusOptions options = null)
        {
            _options = options ?? BusOptions.GetDefaultOptions();

            var factory = new ConnectionFactory()
            {
                HostName = _options.HostName,
                Port     = _options.Port,
                UserName = _options.UserName,
                Password = _options.Password,
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _exchangeName = _options.ExchangeName;
            _channel.ExchangeDeclare(exchange: _exchangeName,
                                     type: ExchangeType.Topic,
                                     durable: false,
                                     autoDelete: false,
                                     arguments: null);
        }

        public void Publish(DomainEvent domainEvent)
        {
            var props = _channel.CreateBasicProperties();
            props.Type = domainEvent.GetType().FullName;

            string message = JsonConvert.SerializeObject(domainEvent);
            byte[] body = Encoding.Unicode.GetBytes(message);

            _channel.BasicPublish(exchange: _exchangeName,
                                  routingKey: domainEvent.RoutingKey,
                                  basicProperties: props,
                                  body: body);
        }

        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
        }

    }
}
