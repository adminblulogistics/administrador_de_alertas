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
        List<CONTACT_ALARMS> obtenerAlarmasPorContact(int idContact);
        Respuesta insertAlarmaContacto(CONTACT_ALARMS ContactAlarma);
    }
}
