using System;
using Minor.Dag09.DelegateDemo.NuEcht;

namespace Minor.Dag09.DelegateDemo.Test
{
    internal class ListenerMock
    {
        public bool SwitchHandledHasBeenCalled { get; private set; }
        public SwitchedEventArgs SwitchedEventArgs { get; private set; }

        internal void SwitchHandled(object sender, SwitchedEventArgs e)
        {
            SwitchHandledHasBeenCalled = true;
            SwitchedEventArgs = e;
        }
    }
}