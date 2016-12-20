using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dag34.Minor.Chatservice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "rabbit" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var chatservice = new Chatservice(connection,channel);
                chatservice.Chatwindow();
            }
                
            Console.ReadLine();
        }
    }
}
