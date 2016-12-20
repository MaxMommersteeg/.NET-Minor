using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace EventAuditLog
{
    public class AuditEvent
    {
        public string EventMessage { get; internal set; }
        public string RoutingKey { get; internal set; }
        public DateTime Timestamp { get; internal set; }
        public string Type { get; internal set; }
    }
}
