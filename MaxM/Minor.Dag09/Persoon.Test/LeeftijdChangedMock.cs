using PersoonOefening;
namespace Persoon.Test
{
    internal class LeeftijdChangedMock
    {
        public bool LeeftijdChangedCalled { get; private set; }
        public LeeftijdChangedEventArgs LeeftijdChangedEventArgs { get; private set; }

        internal void LeeftijdChangedHandled(object sender, LeeftijdChangedEventArgs leeftijdChangedEventArgs)
        {
            LeeftijdChangedCalled = true;
            LeeftijdChangedEventArgs = leeftijdChangedEventArgs;
        }
    }
}
