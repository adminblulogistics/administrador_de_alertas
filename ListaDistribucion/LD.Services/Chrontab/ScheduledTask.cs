using LD.Services.Interfaces.Notifications;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Services.Chrontab
{
    public class ScheduledTask : ScheduledProcessor
    {
        private readonly IConfiguration _config;

        public ScheduledTask(IServiceScopeFactory scopeFactory, IConfiguration config) : base(scopeFactory, config)
        {
            _config = config;
        }

        //proceso automatico
        public override async Task ProcessInScope(IServiceProvider serviceProvider)
        {
            Console.Out.WriteLine("Task: Alertas");

            Console.Out.WriteLine("Task: In Process");
            using (var scope = serviceProvider.CreateScope())
            {
                var _notificationsService = scope.ServiceProvider.GetRequiredService<INotificationsService>();

                await _notificationsService.Notifications();
            }
            Console.Out.WriteLine("Task: Completed");

        }
    }
}
