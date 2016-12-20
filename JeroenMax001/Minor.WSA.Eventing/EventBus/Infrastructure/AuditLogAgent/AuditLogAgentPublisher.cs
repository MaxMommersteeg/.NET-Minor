using System;
using RabbitMQ.Client;
using Common.Infrastructure;
using System.Text;
using Newtonsoft.Json;
using Common.Command;

internal class AuditLogAgentPublisher
{
    private IModel _channel;
    private IConnection _connection;
    public BusOptions BusOptions { get; private set; }


    public AuditLogAgentPublisher(IConnection connection, IModel channel)
    {
        _connection = connection;
        _channel = channel;
    }

    internal void Publish(string recieveQueueName, AuditLogAgentCommandOptions agentoptions, BusOptions busOptions = null)
    {
        BusOptions = busOptions ?? new BusOptions();

        _channel.QueueDeclare(queue: BusOptions.AuditLogQueueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);



        var auditLogCommand = new AuditLogRetrieveCommand()
        {
            StartDate = agentoptions.StartDate,
            EndDate = agentoptions.EndDate,
            RoutingKeyFilter = agentoptions.RoutingKeyFilter,
            RecieveQueue = recieveQueueName
        };

        var serializedAuditLogCommand = JsonConvert.SerializeObject(auditLogCommand);
        var body = Encoding.Unicode.GetBytes(serializedAuditLogCommand);

        var properties = _channel.CreateBasicProperties();
        properties.Persistent = true;

        _channel.BasicPublish(exchange: "",
                             routingKey: BusOptions.AuditLogQueueName,
                             basicProperties: properties,
                             body: body);

    }
}