using Common.Command;
using Common.Event;
using Common.Infrastructure;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventAuditLog
{
    public class AuditLog : IDisposable, IAuditLog
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _queueName;

        public readonly BusOptions BusOptions;
        public List<AuditLogRetrieveCommand> auditLogCommandsRecieved;

        public List<AuditEvent> _eventList { get; private set; }

        public AuditLog(BusOptions busOptions = null)
        {
            BusOptions = busOptions ?? new BusOptions();
            _eventList = new List<AuditEvent>();

            var factory = new ConnectionFactory() { HostName = BusOptions.HostName };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _queueName = _channel.QueueDeclare().QueueName;

            // Declare exchange
            _channel.ExchangeDeclare(BusOptions.ExchangeName, ExchangeType.Topic);

            _channel.QueueBind
            (
                queue: "",
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

            //AuditLogInitaliseCommandListening
            InitialiseAuditCommandHandler();



        }

        protected virtual void Consumer_Received(object sender, BasicDeliverEventArgs bdea)
        {
            var body = bdea.Body;
            var jsonMessage = Encoding.Unicode.GetString(body);
            //Opslaan
            _eventList.Add(new AuditEvent()
            {
                Type = bdea.BasicProperties.Type,
                RoutingKey = bdea.RoutingKey,
                EventMessage = jsonMessage,
                Timestamp = DateTimeOffset.FromUnixTimeSeconds(bdea.BasicProperties.Timestamp.UnixTime).UtcDateTime
            });

            try
            {


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

        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
        }

        public void InitialiseAuditCommandHandler()
        {


            auditLogCommandsRecieved = new List<AuditLogRetrieveCommand>();
            _channel.QueueDeclare(queue: BusOptions.AuditLogQueueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            _channel.BasicQos(0, 1, false);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += AuditLog_Consumer_Received;

            _channel.BasicConsume
            (
                queue: BusOptions.AuditLogQueueName,
                noAck: false,
                consumer: consumer
            );

        }

        public void AuditLog_Consumer_Received(object sender, BasicDeliverEventArgs bdea)
        {
            var body = bdea.Body;
            var jsonMessage = Encoding.Unicode.GetString(body);


            //Opslaan
            try
            {
                var deserializedEventObject = (AuditLogRetrieveCommand)JsonConvert.DeserializeObject(jsonMessage, typeof(AuditLogRetrieveCommand));
                if(deserializedEventObject == null)
                {
                    throw new UnexpectedCommandTypeRecievedException();
                }
                auditLogCommandsRecieved.Add(deserializedEventObject);

                _channel.QueueDeclare(queue: "AuditLogRecieveQueue",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);


                foreach (var domainEvent in _eventList)
                {
                    //var serializedDomainEvent = JsonConvert.SerializeObject(domainEvent);
                    var serializedDomainEventByteArray = Encoding.Unicode.GetBytes(domainEvent.EventMessage);

                    var basicProperties = _channel.CreateBasicProperties();
                    basicProperties.Type = domainEvent.GetType().ToString();
                    basicProperties.Timestamp = new AmqpTimestamp(DateTimeOffset.UtcNow.ToUnixTimeSeconds());

                    _channel.BasicPublish
                    (
                        exchange: "",
                        routingKey: deserializedEventObject.RecieveQueue,
                        basicProperties: basicProperties,
                        body: serializedDomainEventByteArray
                    );
                }   

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
    }


}
