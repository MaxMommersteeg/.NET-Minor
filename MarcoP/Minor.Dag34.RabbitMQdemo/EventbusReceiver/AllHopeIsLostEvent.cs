using Minor.WSA.Common;

namespace EventbusReceiver
{
    internal class AllHopeIsLostEvent : DomainEvent
    {
        public AllHopeIsLostEvent() : base("EventbusSender.AllHopeIsLostEvent") { }
        public string Name { get; set; }
    }
}