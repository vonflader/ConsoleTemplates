using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ConsoleDi.Services
{
    public class ExampleService : IExampleService
    {
        private readonly ILogger<ExampleService> logger;

        public ExampleService(ILogger<ExampleService> logger)
        {
            this.logger = logger;
        }
        public Task Run()
        {
            logger.LogInformation("Hello from ExampleService");
            return Task.CompletedTask;
        }
    }
}
