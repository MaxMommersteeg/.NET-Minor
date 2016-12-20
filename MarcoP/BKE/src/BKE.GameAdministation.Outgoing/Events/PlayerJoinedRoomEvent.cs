using BKE.Common;

namespace BKE.GameAdministation.Events
{
    public class PlayerJoinedRoomEvent : DomainEvent
    {
        public string RoomName { get; set; }
        public long PlayerID { get; set; }
        public string Colour { get; set; }
    }
}