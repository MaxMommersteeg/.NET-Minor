using Common.Event;
using Common.Infrastructure;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Reflection;
using Common.Attributes;
using System.Linq;
using System.Diagnostics;

namespace EventBus.Infrastructure
{
    public abstract class EventDispatcher : IDisposable
    {
        private const string COMMON_ASSEMBLY_NAME = "Common";

        private readonly IConnection _connection;
        private readonly IModel _channel;

        public readonly BusOptions BusOptions;

        public EventDispatcher(BusOptions busOptions = null)
        {
            if(busOptions == null)
            {
                busOptions = new BusOptions();
            }
            BusOptions = busOptions;

            var factory = new ConnectionFactory() { HostName = BusOptions.HostName };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            busOptions.QueueName = _channel.QueueDeclare().QueueName;

            // Declare exchange
            _channel.ExchangeDeclare(BusOptions.ExchangeName, ExchangeType.Topic);

            _channel.QueueBind
            (
                queue: BusOptions.QueueName, 
                exchange: BusOptions.ExchangeName, 
                routingKey: "#", 
                arguments: null
            );

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += Consumer_Received;

            _channel.BasicConsume
            (
                queue: BusOptions.QueueName, 
                noAck: false, 
                consumer: consumer
            );
        }

        protected virtual void Consumer_Received(object sender, BasicDeliverEventArgs bdea)
        {
            var body = bdea.Body;
            var jsonMessage = Encoding.Unicode.GetString(body);

            var routingKey = bdea.RoutingKey;

            Assembly assembly = Assembly.Load(new AssemblyName(COMMON_ASSEMBLY_NAME));
            var eventType = assembly.GetType(bdea.BasicProperties.Type); 

            // Create correct object from type
            var deserializedEventObject = JsonConvert.DeserializeObject(jsonMessage, eventType);

            try
            {
                // Find suitable method and Redirect the event
                FindSuitableMethod(routingKey, (DomainEvent)deserializedEventObject);

                // Send acknowledge
                _channel.BasicAck
                (
                    deliveryTag: bdea.DeliveryTag,
                    multiple: false
                );
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void FindSuitableMethod(string routingKey, DomainEvent receivedObject)
        {
            foreach (var method in GetType().GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public))
            {
                var currentHandleAttributes = method.GetCustomAttributes<HandleAttribute>();
                if (currentHandleAttributes.Count() == 0)
                {
                    continue;
                }

                foreach (var handleAttribute in currentHandleAttributes)
                {
                    if (handleAttribute.RoutingKey == routingKey)
                    {
                        RedirectEvent(method, receivedObject);
                        break;
                    }
                }
            }
        }

        private void RedirectEvent(MethodInfo methodInfo, DomainEvent domainEvent)
        {
            methodInfo?.Invoke(this, new[] { domainEvent });
        }

        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
        }
    }
}
