using Minor.RoWe.Eventbus.Dispatchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Minor.RoWe.Eventbus.Connectors;
using Minor.RoWe.Common.Events;
using System.Diagnostics;
using Minor.RoWe.Eventbus.Test.PublisherTest;
using System.Threading;

namespace Minor.RoWe.Eventbus.Test
{
    public class DispatcherMock : EventDispatcher
    {
        private AutoResetEvent _flag;

        public DispatcherMock(IRabbitMqConnection connection, AutoResetEvent flag) : base(connection)
        {
            _flag = flag;
        }

        public bool Handled { get; private set; }
        public TestEvent Event { get; private set; }
        public override string RoutingKey
        {
            get
            {
                return "#";
            }
        }

        public void Handler(TestEvent e)
        {
            Event = e;
            Handled = true;
            _flag.Set();
        }
    }
}
