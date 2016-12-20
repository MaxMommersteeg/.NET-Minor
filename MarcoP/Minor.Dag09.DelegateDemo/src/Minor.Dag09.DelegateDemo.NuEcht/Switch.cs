using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag09.DelegateDemo.NuEcht
{
    public class Switch
    {
        public event SwitchedEventHandler Switched;
        private bool _state = false;

        public void SwitchMe()
        {
            _state = !_state;
            OnSwitched(new SwitchedEventArgs(_state));
        }

        protected virtual void OnSwitched(SwitchedEventArgs e)
        {
            SwitchedEventHandler temp = Switched;   // make it thread-safe
            temp?.Invoke(this, e);
        }
    }

}
