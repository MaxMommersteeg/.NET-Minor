using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.Swagger.Model;
using Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Services;
using Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Entities;
using Case2.MaRoWo.OnderhoudBeheer.Service.Domain.Infrastructure;
using Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.Repository;
using Case2.MaRoWo.OnderhoudBeheer.Service.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using Minor.RoWe.Common.Interfaces;
using Minor.RoWe.Eventbus.Publishers;
using Minor.RoWe.Eventbus.Options;
using Minor.RoWe.Eventbus.Connectors;
using Case2.MaRoWo.Logger.Services;
using System.IO;

namespace Case2.MaRoWo.OnderhoudBeheer.Service.Facade
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            Func<IServiceProvider, LogService> logServiceFactory =
                (provider) => new LogService(new DirectoryInfo(Environment.GetEnvironmentVariable("logpath")));

            // Setup database with docker connectionstring
            var dockerConnectionString = Environment.GetEnvironmentVariable("dbconnectionstring");
            services.AddDbContext<OnderhoudBeheerContext>
            (
                options => options.UseSqlServer(dockerConnectionString)
            );

            // DI
            services.AddSingleton<ILogService, LogService>(logServiceFactory);
            services.AddScoped<IRepository<Onderhoudsopdracht, long>, OnderhoudsopdrachtRepository>();

            // Eventbus
            var busOptions = BusOptions.CreateFromEnvironment();
            Func<IServiceProvider, EventPublisher> factory = (supplier) => new EventPublisher(new RabbitMqConnection(busOptions));
            services.AddScoped<IEventPublisher, EventPublisher>(factory);

            services.AddScoped<IOnderhoudsopdrachtService, OnderhoudsopdrachtService>();

            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options => 
            {
                options.SingleApiVersion(new Info 
                {
                    Version = "v1",
                    Title = "OnderhoudBeheer Service",
                    Description = "OnderhoudBeheer Service",
                    TermsOfService = "None"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUi();

            app.UseExceptionHandler("/Onderhoud/Error");
        }
    }
}
