using LD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Services.Interfaces.Notifications
{
    public interface INotificationsService
    {
        Task<Respuesta> NotificationsExecute();

        Task<Respuesta> Notifications();
    }
}
