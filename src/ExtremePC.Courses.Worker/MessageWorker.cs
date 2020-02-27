using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExtremePC.Courses.Worker
{
    public class MessageWorker : BackgroundService
    {
        private readonly ILogger<MessageWorker> _logger;

        public MessageWorker(ILogger<MessageWorker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            for (; ; )
            {
                // smarter scheudler like  Hangfire or Quartz.NET


                // algorithm here
                // try to pickup the message
                // map the model
                // use the same service from logic library
                // send the guid, to find later the result
                // mock the e-mail 
                
                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    await Task.Delay(1000, stoppingToken);
                }
                // seconds *  ticks - pickup it every 5 seconds
                Thread.Sleep(5 * 1000);
            }
        }
    }
}
