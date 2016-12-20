namespace Minor.WSA.Infrastructure
{
    public class BusOptions
    {
        public string ExchangeName { get; set; }
        public string QueueName { get; set; }
        public string HostName { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// Returns a fresh copy of the default bus options, each time this method is called
        /// </summary>
        /// <returns>a fresh copy of the default bus options</returns>
        public static BusOptions GetDefaultOptions()
        {
            return new BusOptions
            {
                ExchangeName = "Minor.WSA.DefaultExchange",
                QueueName = null,
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };
        }
    }
}