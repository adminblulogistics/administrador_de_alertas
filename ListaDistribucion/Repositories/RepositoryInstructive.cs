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
    public partial class RepositoryInstructive: IRepositoryInstructive
    {
        private readonly ListaDistribucionContext _dbContext;
        public RepositoryInstructive(ListaDistribucionContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<INSTRUCTIVE> obtenerInstructivos(int? id = null, string tema = "", string descripcion = "", string compania = "", string roles = "", bool? estado = null)
        {
            List<INSTRUCTIVE> instructivos = (
                    from instructivo in _dbContext.INSTRUCTIVE
                    where
                        instructivo.ID_INSTRUCTIVE == (id != null ? id : instructivo.ID_INSTRUCTIVE)
                        && instructivo.TOPIC.Contains(tema)
                        && instructivo.DESCRIPTION.Contains(descripcion)
                        && instructivo.COMPANIES.Contains(compania)
                        && instructivo.ROLES.Contains(roles)
                        && instructivo.IS_ACTIVE == (estado != null ? estado : instructivo.IS_ACTIVE)
                    orderby instructivo.ID_INSTRUCTIVE
                    select instructivo
                ).ToList();
            return instructivos;
        }
        public INSTRUCTIVE obtenerInstructivoPorId(int id)
        {
            INSTRUCTIVE instructivo = _dbContext.INSTRUCTIVE
                .Where(x => x.ID_INSTRUCTIVE == id)
                .FirstOrDefault();

            return instructivo;
        }
        public Respuesta insertarInstructivo(INSTRUCTIVE instructivo)
        {
            Respuesta respuesta = new Respuesta();

            _dbContext.INSTRUCTIVE.Add(instructivo);
            _dbContext.SaveChanges();

            respuesta.ProcesoExitoso = true;

            return respuesta;
        }
        public Respuesta actualizarInstructivo(INSTRUCTIVE instructivo)
        {
            Respuesta respuesta = new Respuesta();

            _dbContext.INSTRUCTIVE.Update(instructivo);
            _dbContext.SaveChanges();

            respuesta.ProcesoExitoso = true;

            return respuesta;
        }
        public Respuesta actualizarInstructivoEliminarArchivo(int idInstructivo, string datoArchivos)
        {
            Respuesta respuesta = new Respuesta();

            INSTRUCTIVE instructive = new INSTRUCTIVE();

            instructive = _dbContext.INSTRUCTIVE.Where(x => x.ID_INSTRUCTIVE == idInstructivo).FirstOrDefault();

            instructive.ATTACHED = datoArchivos;
            _dbContext.SaveChanges();

            respuesta.ProcesoExitoso = true;
            respuesta.Id = idInstructivo;

            return respuesta;
        }
    }
}
