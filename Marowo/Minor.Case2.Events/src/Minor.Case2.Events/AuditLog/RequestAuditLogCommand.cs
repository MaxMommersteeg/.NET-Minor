using Minor.RoWe.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Case2.Events.AuditLog
{
    public class RequestAuditLogCommand : DomainEvent
    {
        public new string RoutingKey { get; set; } = "Minor.Case2.MaRoWo.RequestAuditLog";
        public string Queueu { get; set; }
        public string ExchangeName { get; set; }
        
    }
}
