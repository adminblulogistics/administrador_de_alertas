using LD.Entities;
using LD.EntitiesLD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Repositories.Interfaces
{
    public interface IRepositoryAuditoria
    {
        Respuesta insertarAuditoria(ACTIVITY_LOG log);
        List<ACTIVITY_LOG> obtenerAuditoriaPorOrganizacion(long id);
    }
}
