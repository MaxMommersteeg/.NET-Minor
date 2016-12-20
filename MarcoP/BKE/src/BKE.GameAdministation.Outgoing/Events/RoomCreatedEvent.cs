using BKE.Common;

namespace BKE.GameAdministation.Events
{
    public class RoomCreatedEvent : DomainEvent
    {
        public string RoomName { get; set; }
        public long GameID { get; set; }
    }
}