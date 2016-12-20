using System;

namespace Common.Infrastructure
{
    public class AuditLogAgentCommandOptions
    {
        public DateTime StartDate { get; set; } = DateTime.MinValue;
        public DateTime EndDate { get; set; } = DateTime.MaxValue;
        public string RoutingKeyFilter { get; set; }

    }
}