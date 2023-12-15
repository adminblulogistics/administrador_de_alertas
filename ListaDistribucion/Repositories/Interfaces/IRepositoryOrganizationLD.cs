using LD.Entities;
using LD.EntitiesLD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Repositories.Interfaces
{
    public interface IRepositoryOrganizationLD
    {
        ADDITIONAL_ORGANIZATION_INFORMATION obtenerInfoAdicionalLDPorID(long id);
        Respuesta insertarInfoAdicionalLD(ADDITIONAL_ORGANIZATION_INFORMATION orgInfoAdd);
        Respuesta actualizarInfoAdicionalLD(ADDITIONAL_ORGANIZATION_INFORMATION orgInfoAdd);
        ADDITIONAL_ORGANIZATION_INFORMATION obtenerInfoAdicionalLDPorIDEjecutivo(int id);
    }
}
