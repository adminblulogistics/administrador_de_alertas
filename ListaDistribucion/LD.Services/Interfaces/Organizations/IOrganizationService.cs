using LD.Entities;
using LD.Entities.Dtos;
using LD.EntitiesCotizador;
using LD.EntitiesLD;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Services.Interfaces.Organizations
{
    public interface IOrganizationService
    {
        List<ORGANIZATIONDto> obtenerOrganizacionesPorUsuario(int iduserComercial, int iduserSaleSupport, int iduserEjecutivo, int idSession, bool? esAgente = null);
        List<ORGANIZATIONDto> obtenerOrganizacionesPorSaleSupport(ADDITIONAL_USER_INFORMATION user, bool? esAgente = null);
        ORGANIZATIONDto obtenerOrganizacionPorId(long id);
        CUSTOMERS obtenerOrganizacionCustomerPorId(long id);
        CUSTOMERS obtenerOrganizacionCustomerPorCodeCW(string codeCW);
        ADDITIONAL_ORGANIZATION_INFORMATION obtenerInfoAdicionalLDPorID(long id);
        Respuesta insertarInfoAdicionalLD(ADDITIONAL_ORGANIZATION_INFORMATION orgInfoAdd);
        Respuesta actualizarInfoAdicionalLD(ADDITIONAL_ORGANIZATION_INFORMATION orgInfoAdd);
        Respuesta saveContact(int idContacto, int idOrg, string nombre, string telefono, string email);
        Respuesta saveOrganization(int idOrganization, int idEjecutivo);
        ADDITIONAL_ORGANIZATION_INFORMATION obtenerInfoAdicionalLDPorIDEjecutivo(int id);
        Respuesta ValidarExcelMasivo(IFormFile archivo);
        List<ACTIVITY_LOG> obtenerLogsPorIdOrganizacion(long id);
    }
}
