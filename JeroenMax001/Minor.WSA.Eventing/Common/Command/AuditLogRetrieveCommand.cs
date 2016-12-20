using System;


namespace Common.Command
{
    public class AuditLogRetrieveCommand
    {
        public AuditLogRetrieveCommand()
        {
        }

        public DateTime EndDate { get; set; }
        public string RecieveQueue { get; set; }
        public string RoutingKeyFilter { get; set; }
        public DateTime StartDate { get; set; }
    }
}
