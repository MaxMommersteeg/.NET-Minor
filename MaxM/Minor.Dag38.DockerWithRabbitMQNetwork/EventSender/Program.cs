using RabbitMQ.Client;

namespace EventSender
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory { HostName = "Rabbithutch" };
            using(var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel())
            {

            }
        }
    }
}
