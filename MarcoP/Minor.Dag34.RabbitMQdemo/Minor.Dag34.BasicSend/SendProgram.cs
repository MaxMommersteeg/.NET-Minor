using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minor.Dag34.BasicSend
{
    public class SendProgram
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.ExchangeDeclare("BKEeventbus", ExchangeType.Fanout);
                channel.QueueDeclare(queue: "basic",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = "Hello, Misha";
                byte[] body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "basic",
                                     basicProperties: null,
                                     body: body);

                Console.WriteLine($"We have sent the message: {message}");
            }
        }
    }
}
