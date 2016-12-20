using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.RoWe.Eventbus.Options
{
    public class BusOptions
    {
        public string ExchangeName { get; set; } = "TestExchange";
        public string QueueName { get; set; } = "TestQueue";
        public string HostName { get; set; } = "localhost";
        public int Port { get; set; } = AmqpTcpEndpoint.UseDefaultPort;

        public string Username { get; set; } = "guest";
        public string Password { get; set; } = "guest"; 

        /// <summary>
        /// 
        /// </summary>
        public BusOptions()
        {
          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static BusOptions CreateFromEnvironment()
        {
            var options = new BusOptions();
            options.ExchangeName = Environment.GetEnvironmentVariable("rabbitmq-exchange") ?? "TestExchange";
            options.QueueName = Environment.GetEnvironmentVariable("rabbitmq-queue") ?? "TestQueue";
            options.HostName = Environment.GetEnvironmentVariable("rabbitmq-host") ?? "localhost";

            var port = Environment.GetEnvironmentVariable("rabbitmq-port");
            options.Port = port != null ? int.Parse(port) : AmqpTcpEndpoint.UseDefaultPort;

            options.Username = Environment.GetEnvironmentVariable("rabbitmq-username") ?? "guest";
            options.Password = Environment.GetEnvironmentVariable("rabbitmq-password") ?? "guest";



            return options;
        }



    }
}
