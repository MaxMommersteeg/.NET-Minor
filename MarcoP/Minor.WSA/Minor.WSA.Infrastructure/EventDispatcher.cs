using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Minor.WSA.Common;
using RabbitMQ.Client.Events;

namespace Minor.WSA.Infrastructure
{
    public abstract class EventDispatcher : IDisposable
    {
        private IConnection _connection;
        private IModel _channel;
        private BusOptions _options;
        public string ExchangeName { get; private set; }
        public Dictionary<string,DispatcherDetails> DispatcherModel { get; private set; }

        public EventDispatcher(BusOptions busOptions = null)
        {
            _options = busOptions ?? BusOptions.GetDefaultOptions();

            var factory = new ConnectionFactory()
            {
                HostName = _options.HostName,
                Port = _options.Port,
                UserName = _options.UserName,
                Password = _options.Password,
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            ExchangeName = _options.ExchangeName;
            _channel.ExchangeDeclare(exchange: ExchangeName,
                                     type: ExchangeType.Topic,
                                     durable: false,
                                     autoDelete: false,
                                     arguments: null);

            BuildDispatcherModel();

            string queueName = null;
            if (_options.QueueName == null)
            {
                queueName = _channel.QueueDeclare().QueueName;
            }
            else
            {
                queueName = _channel.QueueDeclare(queue: _options.QueueName);
            }

            _channel.QueueBind(exchange: ExchangeName,
                               queue: queueName,
                               routingKey: "#",
                               arguments: null);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += Consumer_Received;

            _channel.BasicConsume(queue: queueName,
                                  noAck: true,
                                  consumer: consumer);
        }

        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            string eventTypeName = e.BasicProperties.Type;
            if (DispatcherModel.ContainsKey(eventTypeName))
            {
                DispatcherModel[eventTypeName].Dispatch(this, e);
            }
        }

        private void BuildDispatcherModel()
        {
            DispatcherModel = new Dictionary<string, DispatcherDetails>();
            foreach (var method in GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
            {
                var parameters = method.GetParameters();
                if (parameters.Length == 1)
                {
                    var paramType = parameters.First().ParameterType;
                    
                    if (typeof(DomainEvent).IsAssignableFrom(paramType))
                    {
                        DispatcherModel.Add(
                            paramType.FullName,
                            new DispatcherDetails(paramType, method));
                    }
                }
            }
        }

        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
        }
    }
}
