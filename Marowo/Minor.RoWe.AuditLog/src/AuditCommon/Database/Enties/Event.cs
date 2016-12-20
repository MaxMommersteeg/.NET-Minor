using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.RoWe.AuditCommon.Database.Enties
{
    public class Event
    {

        public int Id { get; set; }
        public string Json { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string RoutingKey { get; set; }
    }
}
