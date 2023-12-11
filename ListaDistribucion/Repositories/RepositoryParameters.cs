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
    public partial class RepositoryParameters: IRepositoryParameters
    {

        private readonly ListaDistribucionContext _dbContext;
        public RepositoryParameters(ListaDistribucionContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<SYSTEM_PARAMS> obtenerParametros()
        {
            List<SYSTEM_PARAMS> listParametros = _dbContext.SYSTEM_PARAMS.ToList();

            return listParametros;
        }

        public SYSTEM_PARAMS obtenerParametrosSistemaPorDescripcion(string parametro)
        {
            SYSTEM_PARAMS parametroSistema = _dbContext.SYSTEM_PARAMS.Where(x => x.DESCRIPTION == parametro).FirstOrDefault();

            return parametroSistema;
        }

        public string obtenerParametroValor(string parametro)
        {
            SYSTEM_PARAMS parametroSistema = _dbContext.SYSTEM_PARAMS.Where(x => x.DESCRIPTION == parametro).FirstOrDefault();

            return parametroSistema.VALUE;
        }

        public Respuesta actualizarParametro(SYSTEM_PARAMS parametro)
        {
            Respuesta respuesta = new Respuesta();

            SYSTEM_PARAMS parametroActualizar = _dbContext.SYSTEM_PARAMS.Where(x => x.ID_SYSTEM_PARAMS == parametro.ID_SYSTEM_PARAMS).FirstOrDefault();

            if (parametroActualizar != null)
            {
                parametroActualizar.VALUE = parametro.VALUE;
                _dbContext.SaveChanges();

                respuesta.ProcesoExitoso = true;
                respuesta.MensajeRespuesta = "";
            }

            return respuesta;
        }
    }
}
