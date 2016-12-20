using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.WSA.Infrastructure.Test
{
    public class MyTestDispatcher : EventDispatcher
    {
        public void SomeEventHandler(SomeEvent someEvent)
        {
        }

        public void AnotherEventHandler(AnotherEvent anotherEvent)
        {
        }
    }
}
