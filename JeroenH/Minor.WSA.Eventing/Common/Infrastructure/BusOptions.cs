namespace Common.Infrastructure
{
    public class BusOptions
    {
        public string ExchangeName { get; set; } = "Minor.WSA";
        public string QueueName { get; set; }
        public string HostName { get; set; } = "localhost";
        public int Port { get; set; } = 15672;
        public string UserName { get; set; } = "guest";
        public string Password { get; set; } = "guest";
    }
}
