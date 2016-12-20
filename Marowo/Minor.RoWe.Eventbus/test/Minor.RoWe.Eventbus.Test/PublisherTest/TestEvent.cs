using Minor.RoWe.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.RoWe.Eventbus.Test.PublisherTest
{
    public class TestEvent : DomainEvent
    {
        public string TestString { get; set; }

    }
}
