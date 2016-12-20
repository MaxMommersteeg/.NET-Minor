using Minor.WSA.Common;

namespace Minor.WSA.Infrastructure.Test
{
    public class AnotherEvent : DomainEvent
    {
        public AnotherEvent() : base("Minor.WSA.AnotherEvent")
        {
        }
    }
}