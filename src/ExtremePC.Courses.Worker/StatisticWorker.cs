using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExtremePC.Courses.Worker
{
    public class StatisticWorker : BackgroundService
    {
        private readonly ILogger<StatisticWorker> _logger;

        public StatisticWorker(ILogger<StatisticWorker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            for (; ; )
            {
                // smarter scheudler like  Hangfire or Quartz.NET


                // algorithm here
                // check last running date 
                // - if null then calculate for whole period
                // - if not null, then take current values (min, max, count, avg), and calculate only from last date
                // - for each uncalculated entry - check in one run
                // - store new values, so controller can fetchTehem

                // minutes * seconds *  ticks - calculate it every hour
                Thread.Sleep(60 * 60 * 1000);
                
                
                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    await Task.Delay(1000, stoppingToken);
                }
            }
        }
    }
}
