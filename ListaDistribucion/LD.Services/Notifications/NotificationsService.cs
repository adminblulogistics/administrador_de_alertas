using LD.Entities;
using LD.Entities.Enumerations;
using LD.Entities.xmlCargoWise;
using LD.Services.Interfaces.Alarms;
using LD.Services.Interfaces.Auditoria;
using LD.Services.Interfaces.Contact;
using LD.Services.Interfaces.FTP;
using LD.Services.Interfaces.Notifications;
using LD.Services.Interfaces.Organizations;
using LD.Services.Interfaces.SendEmails;
using LD.Services.Interfaces.Users;
using LD.Services.Interfaces.xmlCargoWise;
using Microsoft.AspNetCore.Hosting;
using NCrontab;
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
        private readonly IFTPManager _FtpManager;
        private readonly IXMLCargoWiseService _XmlCargoWiseService;
        private readonly IUserService _userService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IOrganizationService _organizationService;
        private readonly IContactService _contactService;
        private readonly IAuditoriaService _auditoriaService;

        public NotificationsService(IAlarmService alarmService, ISendEmailsService sendEmailsService, IFTPManager FtpManager, IXMLCargoWiseService XmlCargoWiseService, IHostingEnvironment hostingEnvironment, 
            IUserService userService, IOrganizationService organizationService, IContactService contactService, IAuditoriaService auditoriaService)
        {
            _alarmService = alarmService;
            _sendEmailsService = sendEmailsService;
            _FtpManager = FtpManager;
            _XmlCargoWiseService = XmlCargoWiseService;
            _hostingEnvironment = hostingEnvironment;
            _userService = userService;
            _organizationService = organizationService;
            _contactService = contactService;
            _auditoriaService = auditoriaService;
        }
        public async Task<Respuesta> Notifications()
        {
            Respuesta respuesta = new Respuesta();
            DateTime now;
            var lstAlarm = _alarmService.obtenerAlarmas();

            foreach (var alarm in lstAlarm)
            {
                
                if (!string.IsNullOrEmpty(alarm.SCHEDULE) && alarm.ACTIVE)
                {
                    CrontabSchedule _schedule = CrontabSchedule.TryParse(alarm.SCHEDULE);                    
                    if (_schedule != null)
                    {
                        var _nextRun = alarm.NEXT_DATE_EXECUTE != null ? alarm.NEXT_DATE_EXECUTE : DateTime.Now;
                        if (DateTime.Now > _nextRun)
                        {
                            switch (alarm.EVENTCODE)
                            {
                                case nameof(Enumeraciones.Alarmas.ETAPOD):
                                    respuesta = await NotificationsETA();
                                    break;
                                case nameof(Enumeraciones.Alarmas.ONBOARD):
                                    break;
                            }
                            if (respuesta.ProcesoExitoso)
                            {
                                alarm.LAST_TIME_EXECUTE = alarm.NEXT_DATE_EXECUTE;
                                alarm.NEXT_DATE_EXECUTE = _schedule.GetNextOccurrence(DateTime.Now);
                                _alarmService.actualizarAlarma(alarm);
                            }
                        }

                    }
                }
            }
            respuesta.ProcesoExitoso = true;
            respuesta.MensajeRespuesta = "Proceso ejecutandose";
            respuesta.CodRespuesta = "200";
            return respuesta;
        }

        public async Task<Respuesta> NotificationsETA()
        {
            Respuesta respuesta = new Respuesta();
            var alarm = _alarmService.obtenerAlarmaPorCode(nameof(Enumeraciones.Alarmas.ETAPOD));
            if (alarm != null && alarm.ACTIVE)
            {
                respuesta = _FtpManager.obtenerListaArchivos("_CETA_");

                if (respuesta.ProcesoExitoso)
                {
                    foreach (var fil in (List<UniversalInterchange>)respuesta.ObjetoRespuesta)
                    {
                        string enviarA = string.Empty;
                        string copia = string.Empty;
                        string asunto = string.Empty;
                        string cuerpoCorreo = string.Empty;
                        long idOrg = 0;
                        Consol infoConsol = new Consol();

                        infoConsol = _XmlCargoWiseService.ConvertInfoConsol(fil, "COL");
                        if (infoConsol != null)
                        {
                            try
                            {
                                foreach (var ship in infoConsol.Shipments)
                                {
                                    string plantilla = "ETA.html";
                                    var contentRootPath = _hostingEnvironment.WebRootPath;
                                    string pathComplete = contentRootPath + @"/mailings/" + plantilla;
                                    cuerpoCorreo = System.IO.File.ReadAllText(pathComplete);

                                    cuerpoCorreo = cuerpoCorreo.Replace("@NameClient", ship.SendersLocalClient.Name);
                                    cuerpoCorreo = cuerpoCorreo.Replace("@NroConsol", infoConsol.NroConsol);
                                    cuerpoCorreo = cuerpoCorreo.Replace("@NroShipment", ship.NroShipment);
                                    cuerpoCorreo = cuerpoCorreo.Replace("@HouseNumber", ship.HouseNumber);
                                    cuerpoCorreo = cuerpoCorreo.Replace("@NameConsignor", ship.Consignor.Name);
                                    cuerpoCorreo = cuerpoCorreo.Replace("@NameConsignee", ship.Consignee.Name);
                                    cuerpoCorreo = cuerpoCorreo.Replace("@OrderReference", ship.OrderReference);

                                    var NameTrasnport = ship.TransportLeg.Where(w => w.TransportMode == nameof(Enumeraciones.TransportMode.Sea)).FirstOrDefault();
                                    cuerpoCorreo = cuerpoCorreo.Replace("@NamePuertoCargue", NameTrasnport != null ? NameTrasnport.PortOfLoading.Name : "");
                                    cuerpoCorreo = cuerpoCorreo.Replace("@NamePuertoDescargue", NameTrasnport != null ? NameTrasnport.PortOfDischarge.Name : "");

                                    var etd = ship.ETD != null ? ship.ETD.Substring(0, 10) : "";
                                    cuerpoCorreo = cuerpoCorreo.Replace("@ETD", etd);

                                    cuerpoCorreo = cuerpoCorreo.Replace("@ETAInicialCOIO", infoConsol.ETAInicialCOIO);
                                    cuerpoCorreo = cuerpoCorreo.Replace("@NewETA", infoConsol.ETA);
                                    cuerpoCorreo = cuerpoCorreo.Replace("@CambioETA", infoConsol.CambioETA);

                                    var codeJob = ship.JobCosting != null ? ship.JobCosting.OperationsStaff.Code : "";
                                    copia = _userService.ObtenerCorreosPersonasInside("COL", codeJob);
                                    cuerpoCorreo = cuerpoCorreo.Replace("@CorreosPersonasInside", copia);

                                    var organizacion = _organizationService.obtenerOrganizacionCustomerPorCodeCW(ship.SendersLocalClient.Code);
                                    if (organizacion != null)
                                    {
                                        idOrg = organizacion.ID_CUSTOMER;
                                        var alarmas = _alarmService.obtenerAlarmasPorOrganizacionEvent(organizacion.ID_CUSTOMER, nameof(Enumeraciones.Alarmas.ETAPOD));
                                        if (alarmas.Any())
                                        {
                                            var idsContact = alarmas.Select(s => s.ID_CONTACT).ToArray();
                                            var contactos = _contactService.ObtenerContactosListId(organizacion.ID_CUSTOMER, idsContact);
                                            if (contactos.Any())
                                            {
                                                foreach (var em in contactos)
                                                {
                                                    enviarA += em.EMAIL_CONTACT+";";
                                                }
                                            }                                                
                                        }
                                    }

                                    if (ship.Consignor.Name == "CHOZONCHN2")
				                    {
					                    asunto = $"Cambio ETA  PO: {ship.OrderReference} - Consol: {infoConsol.NroConsol} - HBL: {ship.HouseNumber} - Shipper: CHONGQING ZONGSHEN WEIRUI IMPORT AND EXPORT TRADING CO., LTD. - Customer: {ship.SendersLocalClient.Name}";
                                    }
                                    else
                                    {
					                    asunto = $"Cambio ETA  PO: {ship.OrderReference} - Consol: {infoConsol.NroConsol} - HBL: {ship.HouseNumber} - Shipper: {ship.Consignor.Name} - Customer: {ship.SendersLocalClient.Name}";
                                    }
                                    respuesta = _sendEmailsService.EnviarCorreo(asunto, enviarA, cuerpoCorreo, emailsCC:copia);
                                    if (respuesta.ProcesoExitoso)
                                    {
                                        _auditoriaService.insertarAuditoriaStatusAlarm(new EntitiesLD.STATUS_ALARMS_LOG
                                        {
                                            ID_ORGANIZATION = organizacion.ID_CUSTOMER,
                                            ID_ALARMA = alarm.ID_ALARM,
                                            ID_STATUS_SEND = (int)Enumeraciones.STATUS_SEND.OK,
                                            RECIPIENTS = enviarA,
                                            MESSAGE_SEND = cuerpoCorreo                                            
                                        });
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                respuesta.ProcesoExitoso = false;
                                respuesta.CodRespuesta = "Error enviando alerta CambioETA";
                                respuesta.MensajeRespuesta = string.Format("{0} - {1}", ex.Message, ex.StackTrace);
                                _auditoriaService.insertarAuditoriaStatusAlarm(new EntitiesLD.STATUS_ALARMS_LOG
                                {
                                    ID_ORGANIZATION = idOrg,
                                    ID_ALARMA = alarm.ID_ALARM,
                                    ID_STATUS_SEND = (int)Enumeraciones.STATUS_SEND.ERR,
                                    MESSAGE_ERROR = string.Format("{0} - {1}", ex.Message, ex.StackTrace),
                                    RECIPIENTS = enviarA,
                                    MESSAGE_SEND = cuerpoCorreo
                                });
                            }

                        }

                    }
                }
            }
            return respuesta;
        }
    }
}
