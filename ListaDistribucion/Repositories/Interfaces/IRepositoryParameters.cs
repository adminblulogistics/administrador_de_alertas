using LD.Entities;
using LD.EntitiesLD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Repositories.Interfaces
{
    public interface IRepositoryParameters
    {
        List<SYSTEM_PARAMS> obtenerParametros();
        SYSTEM_PARAMS obtenerParametrosSistemaPorDescripcion(string parametro);
        string obtenerParametroValor(string parametro);
        Respuesta actualizarParametro(SYSTEM_PARAMS parametro);
    }
}
