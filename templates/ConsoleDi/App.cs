using ConsoleDi.Services;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ConsoleDi
{
    public class App
    {
        private readonly ILogger logger;
        private readonly IExampleService exampleService;

        public App(ILogger<App> logger,
            IExampleService exampleService)
        {
            this.logger = logger;
            this.exampleService = exampleService;
        }

        public async Task Run()
        {
            logger.LogInformation("App is running...");
            await exampleService.Run();
        }
    }
}
