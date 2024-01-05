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
    public class RepositoryAuditoria : IRepositoryAuditoria
    {
        private readonly ListaDistribucionContext _dbContext;
        public RepositoryAuditoria(ListaDistribucionContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Respuesta insertarAuditoria(ACTIVITY_LOG log)
        {
            Respuesta respuesta = new Respuesta();
            log.DATE_OPERATION = DateTime.UtcNow.AddHours(-5);

            _dbContext.ACTIVITY_LOG.Add(log);
            _dbContext.SaveChanges();

            respuesta.ProcesoExitoso = true;
            respuesta.Id = log.ID_LOG;

            return respuesta;
        }

        public List<ACTIVITY_LOG> obtenerAuditoriaPorOrganizacion(long id)
        {
            return _dbContext.ACTIVITY_LOG.Where(w => w.ID_CLIENT == id).ToList();
        }
        public Respuesta insertarAuditoriaStatusAlarm(STATUS_ALARMS_LOG log)
        {
            Respuesta respuesta = new Respuesta();
            log.DATE_CREATED = DateTime.UtcNow.AddHours(-5);

            _dbContext.STATUS_ALARMS_LOG.Add(log);
            _dbContext.SaveChanges();

            respuesta.ProcesoExitoso = true;
            respuesta.Id = log.ID_STATUS;

            return respuesta;
        }
    }
}