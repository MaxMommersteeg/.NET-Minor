using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.WSA.Eventing
{
    public class EventPublisher : IEventPublisher
    {
        public EventPublisher(BusOptions options = null)
        {

        }
        public void Publish(DomainEvent domainEvent)
        {
            // ...
        }
    }
}
