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

        public List<CONTACT_ALARMS> insertAlarmaContacto(CONTACT_ALARMS ContactAlarma)
        {
            throw new NotImplementedException();
        }

        public List<ALARMS> obtenerAlarmas()
        {
            return _repositoryAlarm.obtenerAlarmas();
        }

        public List<CONTACT_ALARMS> obtenerAlarmasPorContact(int idContact)
        {
            return _repositoryAlarm.obtenerAlarmasPorContact(idContact);
        }
    }
}
