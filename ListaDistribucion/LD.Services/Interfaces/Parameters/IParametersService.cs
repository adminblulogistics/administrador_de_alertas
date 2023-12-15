using LD.Entities;
using LD.EntitiesLD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Services.Interfaces.Parameters
{
    public interface IParametersService
    {
        SYSTEM_PARAMS obtenerParametrosSistemaPorDescripcion(string parametro);
        List<SYSTEM_PARAMS> obtenerParametros();
        Respuesta actualizarParametro(SYSTEM_PARAMS parametro);
    }
}
