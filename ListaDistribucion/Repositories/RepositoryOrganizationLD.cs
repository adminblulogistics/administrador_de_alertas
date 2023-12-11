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
    public partial class RepositoryOrganizationLD: IRepositoryOrganizationLD
    {
        private readonly ListaDistribucionContext _dbContext;
        public RepositoryOrganizationLD(ListaDistribucionContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Respuesta insertarInfoAdicionalLD(ADDITIONAL_ORGANIZATION_INFORMATION orgInfoAdd)
        {
            Respuesta respuesta = new Respuesta();
            orgInfoAdd.DATE_CREATED = DateTime.UtcNow.AddHours(-5);
            _dbContext.ADDITIONAL_ORGANIZATION_INFORMATION.Add(orgInfoAdd);
            _dbContext.SaveChanges();

            respuesta.ProcesoExitoso = true;
            respuesta.Id = orgInfoAdd.ID_ORGANIZATION;

            return respuesta;
        }

        public ADDITIONAL_ORGANIZATION_INFORMATION obtenerInfoAdicionalLDPorID(long id)
        {
            ADDITIONAL_ORGANIZATION_INFORMATION org = _dbContext.ADDITIONAL_ORGANIZATION_INFORMATION.Where(w=>w.ID_ORGANIZATION_BODEGA == id).FirstOrDefault();
            return org;
        }

        public Respuesta actualizarInfoAdicionalLD(ADDITIONAL_ORGANIZATION_INFORMATION orgInfoAdd)
        {
            Respuesta respuesta = new Respuesta();

            ADDITIONAL_ORGANIZATION_INFORMATION orgInfoAddActualizar = _dbContext.ADDITIONAL_ORGANIZATION_INFORMATION
                .Where(x => x.ID_ORGANIZATION_BODEGA == orgInfoAdd.ID_ORGANIZATION_BODEGA)
                .FirstOrDefault();

            orgInfoAddActualizar.ID_SERVICE_CLIENT = orgInfoAdd.ID_SERVICE_CLIENT;
            orgInfoAddActualizar.ID_ORGANIZATION_BODEGA = orgInfoAdd.ID_ORGANIZATION_BODEGA;
            orgInfoAddActualizar.DATE_UPDATE = DateTime.UtcNow.AddHours(-5);

            _dbContext.SaveChanges();

            respuesta.ProcesoExitoso = true;
            respuesta.Id = orgInfoAddActualizar.ID_ORGANIZATION;

            return respuesta;
        }        
    }
}
