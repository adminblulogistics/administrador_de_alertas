using LD.EntitiesLD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Services.Interfaces.Alarms
{
    public interface IAlarmService
    {
        List<ALARMS> obtenerAlarmas();
        List<CONTACT_ALARMS> obtenerAlarmasPorContact(int idContact);
        List<CONTACT_ALARMS> insertAlarmaContacto(CONTACT_ALARMS ContactAlarma);
    }
}
