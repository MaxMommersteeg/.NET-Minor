using System;

namespace Minor.Dag09.DelegateDemo.NuEcht
{
    public delegate void SwitchedEventHandler(object sender, SwitchedEventArgs e);

    public class SwitchedEventArgs : EventArgs
    {
        public bool State { get; }

        public SwitchedEventArgs(bool state)
        {
            State = state;
        } 
    }
}