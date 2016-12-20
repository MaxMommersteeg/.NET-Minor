using System;

namespace Common.Event
{
    public abstract class DomainEvent
    {
        public DateTime TimeStamp { get; set; }
        public string RoutingKey { get; set; }
        public Guid CorrelationId { get; set; }

        public DomainEvent(string routingKey)
        {
            TimeStamp = DateTime.UtcNow;
            RoutingKey = routingKey;
            CorrelationId = Guid.NewGuid();
        }
    }
}
