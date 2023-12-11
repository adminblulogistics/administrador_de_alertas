using LD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Integrations.SaleForce
{
    public interface IIntegrationSalesForce
    {
        Respuesta ConsultarUsuarioSF(string correo = "");
    }
}
