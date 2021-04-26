using ConsoleDi.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Threading.Tasks;

namespace ConsoleDi
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = BuildConfiguration();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            Log.Information("App start");

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(context.Configuration, services);
                })
                .UseSerilog()
                .Build();

            try
            {
                await host.Services.GetRequiredService<App>().Run();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "App error");
            }

            Log.Information("App exit");
        }

        private static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddScoped<App>();
            services.AddTransient<IExampleService, ExampleService>();
        }

        public static IConfiguration BuildConfiguration() =>
            new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();
    }
}
