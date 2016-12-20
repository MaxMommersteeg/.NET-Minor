using System;
using Common.Infrastructure;
using RabbitMQ.Client;
using Common.Event;
using System.Collections.Generic;
using RabbitMQ.Client.Events;
using System.Text;
using EventBus.Infrastructure;
using Newtonsoft.Json;
using System.Reflection;
using System.Diagnostics;
using System.Threading;

public class AuditLogAgent :IDisposable
{
    private IConnection _connection;
    private IModel _channel;
    private EventDispatcher _eventDispatcher;
    private Dictionary<string, MethodInfoParameterType> _methodTypeList;

    public AuditLogAgentCommandOptions AgentOptions { get; set; }
    public List<DomainEvent> auditLogEventsRecieved { get; set; }
    public string _recieveQueueName { get; set; }

    public BusOptions BusOptions { get; set; }

    public AuditLogAgent(EventDispatcher eventDispatcher, Dictionary<string, MethodInfoParameterType> methodTypeList, BusOptions busOptions)
    {
        _eventDispatcher = eventDispatcher;
        _methodTypeList = methodTypeList;
        BusOptions = busOptions ?? new BusOptions();

        auditLogEventsRecieved = new List<DomainEvent>();
        ListenToAuditLogQueue();
    }

    private void ListenToAuditLogQueue()
    {
        var factory = new ConnectionFactory() { HostName = BusOptions.HostName };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();



        _recieveQueueName = _channel.QueueDeclare(queue: "AuditLogRecieveQueue",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

        _channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += Consumer_Received;

        _channel.BasicConsume(queue: _recieveQueueName,
                             noAck: false,
                             consumer: consumer);

    }

    protected virtual void Consumer_Received(object sender, BasicDeliverEventArgs bdea)
    {
        var body = bdea.Body;
        var jsonMessage = Encoding.Unicode.GetString(body);

        var routingKey = bdea.RoutingKey;

        var methodInfoParameterType = _methodTypeList[bdea.BasicProperties.Type];
        var eventType = methodInfoParameterType.ParameterType;
        if (eventType == null)
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

    private void RedirectEvent(MethodInfo methodInfo, DomainEvent domainEvent)
    {
        var temp = domainEvent;
        methodInfo?.Invoke(_eventDispatcher, new[] { temp });
    }

    public void RetrieveAuditLog( AuditLogAgentCommandOptions agentOptions = null)
    {
        AgentOptions = agentOptions ?? new AuditLogAgentCommandOptions();
        var factory = new ConnectionFactory() { HostName = new BusOptions().HostName };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            var eventPublishService = new AuditLogAgentPublisher(connection, channel);
            eventPublishService.Publish(_recieveQueueName,AgentOptions);
        }
    }

    public void Dispose()
    {
        _channel?.Dispose();
        _connection?.Dispose();
    }
}