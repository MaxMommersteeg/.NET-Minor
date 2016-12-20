
using Minor.RoWe.AuditCommon.Database.Enties;
using Minor.RoWe.AuditCommon.Database.Repositories;
using Minor.RoWe.Common.Events;
using Minor.RoWe.Eventbus.Connectors;
using Minor.RoWe.Eventbus.Dispatchers;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;
using Case2.MaRoWo.Logger.Services;
using Case2.MaRoWo.Logger.Entities;

namespace Minor.RoWe.AuditCommon.Logger
{
    public class AuditLogger : IDisposable
    {
        private IEventRepository _eventRepo;
        private IRabbitMqConnection _connection;
        private readonly ILogService _logger;

        public AuditLogger(IEventRepository eventRepo, IRabbitMqConnection connection, ILogService logger)
        {
            _eventRepo = eventRepo;
            _connection = connection;
            _logger = logger;
            Setup();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _connection?.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Setup()
        {
            var _queue = _connection.Channel.QueueDeclare(queue: _connection.Options.QueueName, durable: true, exclusive: true, autoDelete: false, arguments: null);
            _connection.Channel.QueueBind(queue: _queue,
                                            exchange: _connection.Options.ExchangeName,
                                            routingKey: "#");


            var consumer = new EventingBasicConsumer(_connection.Channel);
            consumer.Received += OnReceivedMessage;
            _connection.Channel.BasicConsume(queue: _queue,
                                 noAck: true,
                                 consumer: consumer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnReceivedMessage(object sender, BasicDeliverEventArgs e)
        {
            // decoding message            
            try
            {
                var json = Encoding.UTF8.GetString(e.Body);
                var domainEvent = JsonConvert.DeserializeObject(json, Type.GetType(e.BasicProperties.Type)) as DomainEvent;

                var wrapper = new Event();                
                wrapper.Date = domainEvent.TimeStamp;
                wrapper.Json = json;
                wrapper.Type = e.BasicProperties.Type;                
                wrapper.RoutingKey = domainEvent.RoutingKey;

                _eventRepo.SaveEvent(wrapper);
            }
            catch (Exception ez)
            {
                _logger.LogException(new LogMessage(ez.Message, ez.StackTrace));
                Console.WriteLine(ez.Message);
            }
        }
    }
}
