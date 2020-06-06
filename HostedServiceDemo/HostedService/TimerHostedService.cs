using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HostedServiceSample.HostedService
{
    public class TimerHostedService : IHostedService
    {
        private readonly ILogger _logger;

        public TimerHostedService(ILogger<TimerHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            new Timer(ExecuteProccess, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }

        private void ExecuteProcess(object state)
        {
            _logger.LogInformation("### Proccess executing ###");
            _logger.LogInformation($"{DateTime.Now}");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("### Proccess stoping ###");
            _logger.LogInformation($"{DateTime.Now}");
            return Task.CompletedTask;
        }
    }
}
