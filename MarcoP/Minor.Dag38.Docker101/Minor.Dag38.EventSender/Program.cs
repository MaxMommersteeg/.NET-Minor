using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minor.Dag38.EventSender
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory { HostName = "rabbitHutch" };
            using (var connnection = factory.CreateConnection())
            using (var channel = connnection.CreateModel())
            {
                channel.QueueDeclare(queue: "mijnHuisdier", 
                                     durable: false, 
                                     autoDelete: false,
                                     exclusive: false, 
                                     arguments: null);

                string message = "Hello, Google";
                byte[] body = Encoding.Unicode.GetBytes(message);

                channel.BasicPublish("", "mijnHuisdier", null, body);
                Console.WriteLine("sent: {0}", message);
            }
        }
    }
}
