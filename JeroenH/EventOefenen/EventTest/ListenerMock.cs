using EventOefenen;

namespace EventTest
{
    internal class ListenerMock
    {
        public bool LeeftijdChangedHasBeenCalled { get; internal set; }
        public LeeftijdChangedEventArgs LeeftijdChangedEventArgs { get; private set; }

        public void LeeftijdChanged(object sender, LeeftijdChangedEventArgs e)
        {
            LeeftijdChangedHasBeenCalled = true;
            LeeftijdChangedEventArgs = e;

            

        }

    }
}