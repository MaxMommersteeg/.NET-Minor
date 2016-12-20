using System;

namespace Common.Event
{
    public abstract class DomainEvent
    {
        public string RoutingKey { get; set; }
        public Guid CorrelationId { get; set; }

        public DomainEvent(string routingKey)
        {
            RoutingKey = routingKey;
            CorrelationId = Guid.NewGuid();
        }
    }
}
