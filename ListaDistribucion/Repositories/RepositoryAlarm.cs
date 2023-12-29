using LD.DataLD;
using LD.Entities;
using LD.EntitiesLD;
using LD.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Repositories
{
    public class RepositoryAlarm : IRepositoryAlarm
    {
        private readonly ListaDistribucionContext _dbContext;
        public RepositoryAlarm(ListaDistribucionContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<ALARMS> obtenerAlarmas()
        {
            return _dbContext.ALARMS.ToList();
        }

        public List<CONTACT_ALARMS> obtenerAlarmasPorContact(long idContact)
        {
            return _dbContext.CONTACT_ALARMS.Where(w=>w.ID_CONTACT== idContact).ToList();
        }

        public Respuesta insertAlarmaContacto(CONTACT_ALARMS ContactAlarma)
        {
            Respuesta respuesta = new Respuesta();
           
            _dbContext.CONTACT_ALARMS.Add(ContactAlarma);
            _dbContext.SaveChanges();

            respuesta.ProcesoExitoso = true;
            respuesta.Id = ContactAlarma.ID_CONTACT_ALARMS;

            return respuesta;
        }

        public ALARMS obtenerAlarmaPorId(int id)
        {
            return _dbContext.ALARMS.Where(w => w.ID_ALARM == id).FirstOrDefault();
        }
        public ALARMS obtenerAlarmaPorCode(string code)
        {
            return _dbContext.ALARMS.Where(w => w.EVENTCODE == code).FirstOrDefault();
        }
        public Respuesta eliminarAlarmasPorContacto(long id)
        {
            _dbContext.CONTACT_ALARMS.RemoveRange(_dbContext.CONTACT_ALARMS.Where(w => w.ID_CONTACT == id));
            _dbContext.SaveChanges();
            Respuesta respuesta = new Respuesta { ProcesoExitoso = true };
            return respuesta;
        }
        public Respuesta eliminarAlarmasPorOrganizacionContacto(long id)
        {
            _dbContext.CONTACT_ALARMS.RemoveRange(_dbContext.CONTACT_ALARMS.Where(w => w.ID_ORGANIZATION == id));
            _dbContext.SaveChanges();
            Respuesta respuesta = new Respuesta { ProcesoExitoso = true };
            return respuesta;
        }

        public List<CONTACT_ALARMS> obtenerAlarmasPorOrganizacionEvent(long id, string eventType)
        {
            return _dbContext.CONTACT_ALARMS.Where(w => w.ID_ORGANIZATION == id && w.EVENTCODE == eventType).ToList(); 
        }
        public Respuesta actualizarAlarma(ALARMS alarma)
        {
            Respuesta respuesta = new Respuesta();

            _dbContext.ALARMS.Update(alarma);
            _dbContext.SaveChanges();

            respuesta.ProcesoExitoso = true;
            return respuesta;
        }
    }
}
