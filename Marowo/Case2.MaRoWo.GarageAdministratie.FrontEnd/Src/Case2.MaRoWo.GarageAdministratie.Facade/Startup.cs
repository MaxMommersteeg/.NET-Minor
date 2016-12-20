using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database.Repositories;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database.Entities;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Agents.RdwIntegrationService;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Agents.OnderhoudBeheerService;
using Case2.MaRoWo.GarageAdministratie.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Case2.MaRoWo.GarageAdministratie.Facade.Configuration;
using Case2.MaRoWo.Logger.Services;
using System.IO;

namespace Case2.MaRoWo.GarageAdministratie.Facade
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

            if (env.IsDevelopment())
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddOptions();
            
            // Add settings from configuration
            services.Configure<WebAppConfig>(Configuration);
            services.Configure<WebAppConfig>(settings =>
            {
                settings.BedrijfsNaam = Environment.GetEnvironmentVariable("bedrijfsnaam");
                settings.BedrijfsPlaats = Environment.GetEnvironmentVariable("bedrijf-plaats");
                settings.InstantieType = Environment.GetEnvironmentVariable("instantie-type");
                settings.KvkNummer = Environment.GetEnvironmentVariable("kvk-nummer");
            });

            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            // Setup database with docker connectionstring
            var dockerConnectionString = Environment.GetEnvironmentVariable("dbconnectionstring");
            services.AddDbContext<GarageAdministratieContext>
            (
                options => options.UseSqlServer(dockerConnectionString)
            );

            // DI
            Func<IServiceProvider, LogService> logServiceFactory =
                (provider) => new LogService(new DirectoryInfo(Environment.GetEnvironmentVariable("logpath")));

            Func<IServiceProvider, RdwIntegrationServiceAgent> rdwIntegrationServiceAgentsupplier =
            (
                p => new RdwIntegrationServiceAgent
                (
                    new Uri(Environment.GetEnvironmentVariable("rdw-integration-service"))
                )
            );

            Func<IServiceProvider, OnderhoudBeheerServiceAgent> onderhoudBeheerServiceAgentSupplier =
            (
                p => new OnderhoudBeheerServiceAgent
                (
                    new Uri(Environment.GetEnvironmentVariable("onderhoud-beheer-service"))
                )
            );

            services.AddSingleton<ILogService, LogService>(logServiceFactory);
            services.AddScoped<IRdwIntegrationServiceAgent, RdwIntegrationServiceAgent>(rdwIntegrationServiceAgentsupplier);
            services.AddScoped<IOnderhoudBeheerServiceAgent, OnderhoudBeheerServiceAgent>(onderhoudBeheerServiceAgentSupplier);
            services.AddScoped<IRepository<Onderhoudsopdracht, long>, OnderhoudsopdrachtenRepository>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Main/Error");
            }

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Onderhoudsopdrachten}/{action=Index}/{id?}");
            });

         
        }
    }
}
