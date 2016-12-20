using BlackJackBE.Domain.Entities;
using Minor.WSA.Commons;

public class GameStartedEvent : DomainEvent
{
    public GameStartedEvent()
    {
    }

    public Round round { get; set; }
}