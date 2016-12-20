using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.EventListener;
using Minor.RoWe.Eventbus.Options;
using Case2.MaRoWo.Logger.Services;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Facade
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var options = BusOptions.CreateFromEnvironment();
            var logger = new LogService(new DirectoryInfo(Path.Combine(Environment.GetEnvironmentVariable("logpath"),"RabbitMqLog")));           
            var dbConnectionString =Environment.GetEnvironmentVariable("dbconnectionstring");
            var eventListener = new OnderhoudsBeheerEventListener(options, dbConnectionString, logger);
            eventListener.Start();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
