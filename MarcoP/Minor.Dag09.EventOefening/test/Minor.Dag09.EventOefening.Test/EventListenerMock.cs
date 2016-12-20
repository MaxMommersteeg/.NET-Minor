using System;

namespace Minor.Dag09.EventOefening.Test
{
    internal class EventListenerMock
    {
        public object Sender { get; internal set; }
        public LeeftijdChangedEventArgs EventArgs { get; internal set; }
        public int ReceivedTimes { get; internal set; } = 0;

        internal void Listen(object sender, LeeftijdChangedEventArgs e)
        {
            Sender = sender;
            EventArgs = e;
            ReceivedTimes++;
        }
    }
}