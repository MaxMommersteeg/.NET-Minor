using RabbitMQ.Client.Events;
using System.Collections.Generic;

namespace EventAuditLog
{
    public interface IAuditLog
    {
        List<AuditEvent> _eventList { get; }

        void Dispose();
        void InitialiseAuditCommandHandler();
        void AuditLog_Consumer_Received(object sender, BasicDeliverEventArgs bdea);

    }
}