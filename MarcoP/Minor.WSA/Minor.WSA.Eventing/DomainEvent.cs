using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.WSA.Eventing
{
    public abstract class DomainEvent
    {
        // TimeStamp	    (DateTime)
        // RoutingKey       (solutionName.MicroServiceName.EventName)
        // CorrelationID    (GUID)
    }
}
