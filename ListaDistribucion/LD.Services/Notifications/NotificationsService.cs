using LD.Entities;
using LD.Services.Interfaces.Alarms;
using LD.Services.Interfaces.Notifications;
using LD.Services.Interfaces.SendEmails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Services.Notifications
{
    public class NotificationsService : INotificationsService
    {
        private readonly IAlarmService _alarmService;
        private readonly ISendEmailsService _sendEmailsService;
        public NotificationsService(IAlarmService alarmService, ISendEmailsService sendEmailsService)
        {
            _alarmService = alarmService;
            _sendEmailsService = sendEmailsService;
        }
        public async Task<Respuesta> Notifications()
        {
            var respuesta = new Respuesta();
            _ = NotificationsExecute();
            respuesta.ProcesoExitoso = true;
            respuesta.MensajeRespuesta = "Proceso ejecutandose";
            respuesta.CodRespuesta = "200";
            return respuesta;
        }

        public async Task<Respuesta> NotificationsExecute()
        {
            var respuesta = new Respuesta();
            var lstAlarm = _alarmService.obtenerAlarmas();
            _ = _sendEmailsService.EnviarCorreo("Prueba de notificacion de alerta", "camilo.gaitan@blulogistics.com;fernanda.pinzon@blulogistics.com;desarrollador.externo3@blulogistics.com", "<!DOCTYPE html><html><head><title>Mi primera alerta</title></head><body><div id=\"una capa\"><h3>Hola mundo!</h3><p>Este es un ejemplo envio de alerta.</p></div></body></html>");

            return respuesta;
        }
    }
}
