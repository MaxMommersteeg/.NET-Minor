namespace Common.Event
{
    public class GameRoomEvent : DomainEvent
    {
        public GameRoomEvent(string routingKey) : base(routingKey)
        {

        }

        public int GameRoomId { get; set; }
        public string GameRoomName { get; set; }
    }
}
