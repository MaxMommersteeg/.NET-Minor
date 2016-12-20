namespace Minor.WSA.Eventing
{
    public class BusOptions
    {
        public string ExchangeName { get; set; }
        public string QueueName { get; set; }
        public string HostName { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}