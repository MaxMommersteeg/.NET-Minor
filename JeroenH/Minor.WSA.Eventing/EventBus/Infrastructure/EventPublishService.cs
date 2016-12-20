using Common.Infrastructure;
using Common.Event;
using RabbitMQ.Client;
using System;
using Newtonsoft.Json;
using System.Text;

namespace EventBus.Infrastructure
{
    public class EventPublishService : IEventPublisher, IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public readonly BusOptions BusOptions;

        public EventPublishService(IConnection connection, IModel channel, BusOptions busOptions = null)
        {
            _connection = connection;
            _channel = channel;
            if (busOptions == null)
            {
                busOptions = new BusOptions();
            }
            BusOptions = busOptions;

            // Declare exchange
            _channel.ExchangeDeclare(BusOptions.ExchangeName, ExchangeType.Topic);       
        }

        public void Publish(DomainEvent domainEvent)
        {
            var serializedDomainEvent = JsonConvert.SerializeObject(domainEvent);
            var serializedDomainEventByteArray = Encoding.Unicode.GetBytes(serializedDomainEvent);

            var basicProperties = _channel.CreateBasicProperties();
            basicProperties.Type = domainEvent.GetType().ToString();

            // Publish serialized message to exchange, using routingkey from domainEvent
            _channel.BasicPublish
            (
                exchange: BusOptions.ExchangeName,
                routingKey: domainEvent.RoutingKey,
                basicProperties: basicProperties,
                body: serializedDomainEventByteArray
            );
        }

        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
        }
    }
}
