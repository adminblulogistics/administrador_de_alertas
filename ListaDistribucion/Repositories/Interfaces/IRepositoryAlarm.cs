using LD.Entities;
using LD.EntitiesLD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Repositories.Interfaces
{
    public interface IRepositoryAlarm
    {
        List<ALARMS> obtenerAlarmas();
        List<CONTACT_ALARMS> obtenerAlarmasPorContact(long idContact);
        Respuesta insertAlarmaContacto(CONTACT_ALARMS ContactAlarma);
        ALARMS obtenerAlarmaPorId(int id);
        ALARMS obtenerAlarmaPorCode(string code);
        Respuesta eliminarAlarmasPorContacto(long id);
        Respuesta eliminarAlarmasPorOrganizacionContacto(long id);
        List<CONTACT_ALARMS> obtenerAlarmasPorOrganizacionEvent(long id, string eventType);
        Respuesta actualizarAlarma(ALARMS alarma);
    }
}
