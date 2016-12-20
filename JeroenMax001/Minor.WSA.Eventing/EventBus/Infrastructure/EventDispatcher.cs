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
using System.Collections.Generic;
using EventAuditLog;

namespace EventBus.Infrastructure
{
    public abstract class EventDispatcher : IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private Dictionary<string, MethodInfoParameterType> _methodTypeList;
        private readonly string _queueName;

        public readonly BusOptions BusOptions;

        public AuditLogAgentCommandOptions AgentOptions { get; private set; }

        public EventDispatcher(IAuditLog auditLog, BusOptions busOptions = null)
        {
            BusOptions = busOptions ?? new BusOptions();

            

            _methodTypeList = MapSuitableMethods();

            var factory = new ConnectionFactory() { HostName = BusOptions.HostName };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _queueName = _channel.QueueDeclare().QueueName;

            // Declare exchange
            _channel.ExchangeDeclare(BusOptions.ExchangeName, ExchangeType.Topic);

            _channel.QueueBind
            (
                queue: _queueName, 
                exchange: BusOptions.ExchangeName, 
                routingKey: BusOptions.RoutingKey, 
                arguments: null
            );

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += Consumer_Received;

            _channel.BasicConsume
            (
                queue: _queueName, 
                noAck: false, 
                consumer: consumer
            );
        }

        protected virtual void Consumer_Received(object sender, BasicDeliverEventArgs bdea)
        {
            var body = bdea.Body;
            var jsonMessage = Encoding.Unicode.GetString(body);

            var routingKey = bdea.RoutingKey;

            var methodInfoParameterType = _methodTypeList[bdea.BasicProperties.Type];
            var eventType = methodInfoParameterType.ParameterType;
            if(eventType == null)
            {
                return;
            }

            // Create correct object from type
            var deserializedEventObject = JsonConvert.DeserializeObject(jsonMessage, eventType);

            try
            {
                RedirectEvent(methodInfoParameterType.MethodInfo, (DomainEvent)deserializedEventObject);

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

        private Dictionary<string, MethodInfoParameterType> MapSuitableMethods()
        {
            var methodTypeList = new Dictionary<string, MethodInfoParameterType>();
            foreach (var method in GetType().GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public))
            {
                var currentHandleAttributes = method.GetCustomAttributes<HandleAttribute>();
                if (currentHandleAttributes.Count() == 0)
                {
                    continue;
                }
                // Method has handle attribute

                var currentParameters = method.GetParameters();
                if(currentParameters.Count() == 0 || currentParameters.Count() > 1)
                {
                    continue;
                }
                // Parameter count is valid

                // Store MethodInfo and ParameterType
                methodTypeList.Add(currentParameters.First().ParameterType.ToString(), new MethodInfoParameterType(method, currentParameters.First().ParameterType));
            }
            return methodTypeList;
        }

        private void RedirectEvent(MethodInfo methodInfo, DomainEvent domainEvent)
        {
            var temp = domainEvent;
            methodInfo?.Invoke(this, new[] { temp });
        }

        public void UpdateFromAuditLog(AuditLogAgentCommandOptions agentOptions = null)
        {
            AgentOptions = agentOptions ?? new AuditLogAgentCommandOptions();

            using (var agent = new AuditLogAgent(this, _methodTypeList, BusOptions))
            {
                agent.RetrieveAuditLog(agentOptions);
            }
        }

        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
        }
    }
}
