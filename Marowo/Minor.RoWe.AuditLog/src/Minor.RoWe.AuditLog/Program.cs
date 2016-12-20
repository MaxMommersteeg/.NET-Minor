using Case2.MaRoWo.Logger.Entities;
using Case2.MaRoWo.Logger.Services;
using Microsoft.EntityFrameworkCore;
using Minor.RoWe.AuditCommon.Database.Repositories;
using Minor.RoWe.AuditCommon.Logger;
using Minor.RoWe.AuditLog.Database;
using Minor.RoWe.Eventbus.Connectors;
using Minor.RoWe.Eventbus.Options;
using System;
using System.IO;
using System.Threading;

namespace Minor.RoWe.AuditLogService
{
    public class Program
    {

        public static void Main(string[] args)
        {           
            var busoption = BusOptions.CreateFromEnvironment();
            var builder = new DbContextOptionsBuilder<AuditContext>();
            builder.UseSqlServer(Environment.GetEnvironmentVariable("dbconnectionstring"));
            var options = builder.Options;
            var eventRepo = new EventRepository(options);
            var logService = new LogService(new DirectoryInfo(Path.Combine(Environment.GetEnvironmentVariable("logpath"),"RabbitMqLog")));

            while(true)
            {
                try
                {
                    using (var rabbit = new RabbitMqConnection(busoption))
                    using (var logger = new AuditLogger(eventRepo, rabbit, logService))
                    {
                        while (rabbit.Channel.IsOpen)
                        {
                            Thread.Sleep(60000);
                        }
                        logService.Log(new LogMessage("Lost connection with RabbitMq"));
                    }
                }
                catch (Exception e)
                {
                    logService.LogException(new LogMessage(e.Message, e.StackTrace));
                    Thread.Sleep(5000);
                }
            }
        }
    }
}
