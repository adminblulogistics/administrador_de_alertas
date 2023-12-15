using LD.EntitiesCotizador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Repositories.Interfaces
{
    public interface IRepositoryCustomerCT
    {
        List<CUSTOMERS> ObtenerOrganizacionesPorComercial(string idSaleforceComercial, bool? esAgente = null);
        List<CUSTOMERS> ObtenerOrganizacionesPorComerciales(List<string> listIdSF, bool? esAgente = null);
        CUSTOMERS ObtenerOrganizacionPorId(long id);
        bool validarExistenciaOrganizacion(long id);
    }
}
