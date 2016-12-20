using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace Dag34.Minor.Chatservice
{
    public class Chatservice
    {
        public IConnection _connection { get; private set; }
        public IModel _channel { get; private set; }
        public string _queueName { get; private set; }
        public ChatContext _context { get; private set; }

        public Chatservice(IConnection connection,IModel channel)
        {
            _connection = connection;
            _channel = channel;
            _queueName = _channel.QueueDeclare().QueueName;
            _context = new ChatContext();
        }

        public void Chatwindow()
        {
                _channel.ExchangeDeclare("ChatserviceExchange", ExchangeType.Fanout);

                Sending();

                SignUpQueue();

                while (true)
                {
                    Listening();
                }



        }

        public void Sending()
        {
            _channel.QueueBind(queue: _queueName,
                              exchange: "ChatserviceExchange",
                              routingKey: "");

            Console.WriteLine(" [*] Waiting for logs.");
        }

        public void SignUpQueue()
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += Consumer_Received;
            _channel.BasicConsume(queue: _queueName,
                                 noAck: false,
                                 consumer: consumer);
        }

        private void Listening()
        {
           // string message = Console.ReadLine();
            string message = "Testing";


            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "ChatserviceExchange",
                                 routingKey: "",
                                 basicProperties: null,
                                 body: body);
            Console.WriteLine(" [x] Sent {0}", message);
        }

        private void Consumer_Received(object sender, BasicDeliverEventArgs ea)
        {
            var bodyReceive = ea.Body;
            var messageReceive = Encoding.UTF8.GetString(bodyReceive);
            var message = new ChatMessage() { Message = messageReceive };
            _context.Add(message);
            _context.SaveChanges();
            Console.WriteLine(" [x] {0}", messageReceive);
        }
    }


}
