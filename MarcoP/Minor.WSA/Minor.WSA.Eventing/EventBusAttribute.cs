using System;

namespace Minor.WSA.Eventing
{
    internal class EventBusAttribute : Attribute
    {
        public string ExchangeName { get; set; }
        public string HostName { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string QueueName { get; set; }
        public string Username { get; set; }
    }
}