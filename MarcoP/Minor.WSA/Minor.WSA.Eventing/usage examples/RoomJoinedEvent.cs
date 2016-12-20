namespace Minor.WSA.Eventing
{
    public class RoomJoinedEvent : DomainEvent
    {
        public int RoomId { get; set; }
        public string PlayerID { get; set; }
        public string Colour { get; set; }
    }
}