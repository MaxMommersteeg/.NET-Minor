using Case2.MaRoWo.Logger.Services;
using Case2.MaRoWo.RDW.IntegrationService.Domain.Entities;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Agents;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Converters;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.DAL;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Managers;
using Case2.MaRoWo.RDW.IntegrationService.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Minor.RoWe.Common.Interfaces;
using Minor.RoWe.Eventbus.Connectors;
using Minor.RoWe.Eventbus.Options;
using Minor.RoWe.Eventbus.Publishers;
using Swashbuckle.Swagger.Model;
using System;
using System.IO;

namespace Case2.MaRoWo.RDW.IntegrationService.Facade
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();

            Func<IServiceProvider, LogService> logServiceFactory =
                (provider) => new LogService(new DirectoryInfo(Environment.GetEnvironmentVariable("logpath")));

            Func<IServiceProvider, RabbitMqConnection> rabbitMqConnectionFactory =
                (provider) => new RabbitMqConnection(BusOptions.CreateFromEnvironment());

            Func<IServiceProvider, RdwApkAgent> rwdAgentFactory =
                (provider) => new RdwApkAgent(Environment.GetEnvironmentVariable("rdw-requesturl"));
            Func<IServiceProvider, RdwApkManager> apkManagerFactory =
                provider =>
                    new RdwApkManager(
                        provider.GetService<IRdwApkAgent>(),
                        provider.GetService<IKeuringsVerzoekConverter>(),
                        provider.GetService<IRepository<ApkAanvraagLog, long>>(),
                        Environment.GetEnvironmentVariable("keuringsverzoek-xmlns"),
                        Environment.GetEnvironmentVariable("keuringsverzoek-apk"),
                        provider.GetService<IEventPublisher>()
                )
            ;

            services.AddSingleton<ILogService, LogService>(logServiceFactory);
            services.AddScoped<IRabbitMqConnection, RabbitMqConnection>(rabbitMqConnectionFactory);
            services.AddScoped<IEventPublisher, EventPublisher>();
            services.AddScoped<IRdwApkAgent, RdwApkAgent>(rwdAgentFactory);
            services.AddScoped<IRdwApkManager, RdwApkManager>(apkManagerFactory);
            services.AddScoped<IKeuringsVerzoekConverter, KeuringsVerzoekConverter>();

            // Setup database with docker connectionstring

            var dockerConnectionString = Environment.GetEnvironmentVariable("dbconnectionstring");
            services.AddDbContext<RdwContext>
            (
                options => options.UseSqlServer(dockerConnectionString)
            );

            services.AddScoped<IRepository<ApkAanvraagLog, long>, ApkAanvraagLogRepository>();
            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "RDW Integration Service",
                    Description = "RDW Integration Service",
                    TermsOfService = "None"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUi();

            app.UseExceptionHandler("/Apk/Error");
        }
    }
}
