using BlackJackBE.Domain.Entities;

public class GameStartedEvent
{
    public GameStartedEvent()
    {
    }

    public Round round { get; set; }
}