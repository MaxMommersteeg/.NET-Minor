using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.EventListeners.Dispathers;
using Case2.MaRoWo.Logger.Entities;
using Case2.MaRoWo.Logger.Services;
using Microsoft.EntityFrameworkCore;
using Minor.RoWe.Eventbus.Connectors;
using Minor.RoWe.Eventbus.Options;
using System;
using System.Threading;

namespace Case2.MaRoWo.GarageAdministratie.Infrastructure.EventListeners
{
    public class MaRoWoEventListener
    {
        private BusOptions _options;
        private string _dbConnectionString;
        private ILogService _service;

        public MaRoWoEventListener(BusOptions options, string dbConnectionString, ILogService service)
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
            var builder = new DbContextOptionsBuilder<GarageAdministratieContext>();
            builder.UseSqlServer(_dbConnectionString);
            var options = builder.Options;

            while (true)
            {
                try
                {
                    using (var rabbit = new RabbitMqConnection(_options))
                    using (var dispatcher = new OnderhoudOpdrachtenDispatcher(rabbit, options))
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
