using Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.DAL;
using Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.EventListener.Dispatchers;
using Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.EventListener.Services;
using Microsoft.EntityFrameworkCore;
using Minor.Case2.Events.RDWIntegration;
using Minor.RoWe.Eventbus.Connectors;
using Minor.RoWe.Eventbus.Options;
using Minor.RoWe.Eventbus.Publishers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Case2.MaRoWo.Logger.Services;
using Case2.MaRoWo.Logger.Entities;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.EventListener
{
    public class OnderhoudsBeheerEventListener
    {
        private BusOptions _options;
        private string _dbConnectionString;
        private ILogService _service;
        public OnderhoudsBeheerEventListener(BusOptions options, string dbConnectionString, ILogService service)
        {
            _options = options;
            _dbConnectionString = dbConnectionString;
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            var thread = new Thread(new ThreadStart(Run));
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Run()
        {
            var builder = new DbContextOptionsBuilder<OnderhoudBeheerContext>();
            builder.UseSqlServer(_dbConnectionString);
            var options = builder.Options;

            while (true)
            {
                try
                {
                    using (var rabbit = new RabbitMqConnection(_options))
                    using (var publisher = new EventPublisher(rabbit))
                    using (var service = new ApkEventService(options, publisher))
                    using (var dispatcher = new ApkDispatcher(rabbit, service))
                    {
                        dispatcher.StartListening();
                        while (rabbit.Channel.IsOpen)
                        {                           
                            Thread.Sleep(60000);
                        }
                        _service.Log(new LogMessage("Lost connection with RabbitMq"));
                    }
                }
                catch (Exception e)
                {
                    _service.LogException(new LogMessage(e.Message, e.StackTrace));
                    Thread.Sleep(5000);
                }
            }
        }

    }
}
