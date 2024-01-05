using LD.Entities;
using LD.EntitiesLD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Services.Interfaces.Auditoria
{
    public interface IAuditoriaService
    {
        Respuesta insertarAuditoria(ACTIVITY_LOG log);
        List<ACTIVITY_LOG> obtenerAuditoriaPorOrganizacion(long id);
        Respuesta insertarAuditoriaStatusAlarm(STATUS_ALARMS_LOG log);
    }
}
