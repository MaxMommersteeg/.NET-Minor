using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Minor.Dag38.EventListener
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

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += Consumer_Received;

                channel.BasicConsume("mijnHuisdier", true, consumer);
                Console.WriteLine("listening to incoming events...");
                while (true)
                {
                    Thread.Sleep(500);
                    Console.WriteLine(".");
                }
            }
        }

        private static void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body;
            var message = Encoding.Unicode.GetString(body);

            Console.WriteLine($"Received: {message}");
        }
    }
}
