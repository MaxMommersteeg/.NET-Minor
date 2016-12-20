using Minor.RoWe.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Case2.Events.RDWIntegration
{
    public class ApkAfgemeldEvent : DomainEvent
    {
        public long OnderhoudsBeurtId { get; set; }
        public string Kenteken { get; set; }
        public bool HasSteekProef { get; set; }
        public DateTime SteekProefDatum { get; set; }

    }
}
