using Minor.WSA.Common;

namespace EventbusSender
{
    internal class HoopVanZegenEvent : DomainEvent
    {
        public HoopVanZegenEvent() : base("EventbusSender.HoopVanZegenEvent") { }
        public string Name { get; set; }
    }
}