using LD.Entities;
using LD.EntitiesLD;
using LD.Repositories.Interfaces;
using LD.Services.Interfaces.Alarms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Services.Alarms
{
    public class AlarmService : IAlarmService
    {
        private readonly IRepositoryAlarm _repositoryAlarm;
        public AlarmService(IRepositoryAlarm repositoryAlarm)
        {
            _repositoryAlarm = repositoryAlarm;
        }

        public Respuesta insertAlarmaContacto(CONTACT_ALARMS ContactAlarma)
        {
            return _repositoryAlarm.insertAlarmaContacto(ContactAlarma);
        }

        public List<ALARMS> obtenerAlarmas()
        {
            return _repositoryAlarm.obtenerAlarmas();
        }
        public ALARMS obtenerAlarmaPorId(int id)
        {
            return _repositoryAlarm.obtenerAlarmaPorId(id);
        }
        public ALARMS obtenerAlarmaPorCode(string code)
        {
            return _repositoryAlarm.obtenerAlarmaPorCode(code);
        }
        public List<CONTACT_ALARMS> obtenerAlarmasPorContact(long idContact)
        {
            return _repositoryAlarm.obtenerAlarmasPorContact(idContact);
        }

        public Respuesta eliminarAlarmasPorContacto(long id)
        {
            return _repositoryAlarm.eliminarAlarmasPorContacto(id);
        }

        public Respuesta eliminarAlarmasPorOrganizacionContacto(long id)
        {
            return _repositoryAlarm.eliminarAlarmasPorOrganizacionContacto(id);
        }

        public List<CONTACT_ALARMS> obtenerAlarmasPorOrganizacionEvent(long id, string eventType)
        {
            return _repositoryAlarm.obtenerAlarmasPorOrganizacionEvent(id, eventType);
        }
    }
}
