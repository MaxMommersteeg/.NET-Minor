using Minor.WSA.Commons;

namespace Domain.Entities
{
    public class CardDealtEvent : DomainEvent
    {
        public CardDealtEvent()
        {
        }

        public Card Card { get; set; }
    }
}