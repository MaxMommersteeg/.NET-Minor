using Common.Infrastructure;
using Common.Event;
using RabbitMQ.Client;

namespace EventBus.Infrastructure
{
    public class EventPublisher : IEventPublisher
    {
        public void Publish(DomainEvent domainEvent)
        {
            var factory = new ConnectionFactory() { HostName = new BusOptions().HostName };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var eventPublishService = new EventPublishService(connection, channel);
                eventPublishService.Publish(domainEvent);
            }
        }
    }
}
