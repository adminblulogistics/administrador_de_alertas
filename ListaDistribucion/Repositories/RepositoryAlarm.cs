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

        public List<CONTACT_ALARMS> obtenerAlarmasPorContact(int idContact)
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

    }
}
