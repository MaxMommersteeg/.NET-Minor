using System;

namespace Minor.WSA.Common
{
    public abstract class DomainEvent
    {
        public DateTime Timestamp { get; set; }
        public string RoutingKey { get; set; }

        public DomainEvent(string routingKey)
        {
            Timestamp = DateTime.Now;
            RoutingKey = routingKey;
        }
    }
}
