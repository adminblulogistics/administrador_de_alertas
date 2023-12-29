using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NCrontab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Services.Chrontab
{
    public abstract class ScheduledProcessor : ScopedProcessor
    {
        private  CrontabSchedule _schedule;
        private DateTime _nextRun;
        protected string Schedule;

        protected ScheduledProcessor(IServiceScopeFactory serviceScopeFactory, IConfiguration config) : base(serviceScopeFactory)
        {
            Schedule = config["chrontab:schedule"]; 
            _schedule = CrontabSchedule.Parse(Schedule);
            _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                var now = DateTime.Now;
                if (now > _nextRun)
                {
                    await Process();
                    _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
                }
                await Task.Delay(15000, stoppingToken); //15 seconds delay
            }
            while (!stoppingToken.IsCancellationRequested);
        }
    }
}
