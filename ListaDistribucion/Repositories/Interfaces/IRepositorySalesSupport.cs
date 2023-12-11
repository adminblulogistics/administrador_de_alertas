using LD.EntitiesCotizador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Repositories.Interfaces
{
    public interface IRepositorySalesSupport
    {
        List<SALES_SUPPORTS> obtenerComercialesPorSaleSupport(int idUser);
    }
}
