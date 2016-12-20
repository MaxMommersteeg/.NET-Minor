using Minor.WSA.Common;

namespace Minor.WSA.Infrastructure.Test
{
    public class SomeEvent : DomainEvent
    {
        public SomeEvent() : base("Minor.WSA.SomeEvent")
        {
        }

        public int SomeNumber { get; set; }
        public string SomeName { get; set; }
    }
}