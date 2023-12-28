using LD.Entities;
using LD.EntitiesLD;
using LD.Repositories.Interfaces;
using LD.Services.Interfaces.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Services.Parameters
{    
    public partial class ParametersService : IParametersService
    {
        private readonly IRepositoryParameters _repositoryParameters;
        public ParametersService(IRepositoryParameters repositoryParameters)
        {
            _repositoryParameters = repositoryParameters;
        }

        public SYSTEM_PARAMS obtenerParametrosSistemaPorDescripcion(string parametro)
        {
            return _repositoryParameters.obtenerParametrosSistemaPorDescripcion(parametro);
        }
        public List<SYSTEM_PARAMS> obtenerParametros()
        {            
            return _repositoryParameters.obtenerParametros();
        }
        public Respuesta actualizarParametro(SYSTEM_PARAMS parametro)
        {
            return _repositoryParameters.actualizarParametro(parametro);
        }
    }   
}
