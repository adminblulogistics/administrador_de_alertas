using LD.DataCotizador;
using LD.EntitiesCotizador;
using LD.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Repositories
{
    public class RepositoryCustomerCT : IRepositoryCustomerCT
    {
        private readonly BPCotizadorContext _dbContext;
        public RepositoryCustomerCT(BPCotizadorContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<CUSTOMERS> ObtenerOrganizacionesPorComercial(string idSaleforceComercial, bool? esAgente = null)
        {
            List<CUSTOMERS> listadoClientes = _dbContext.CUSTOMERS.Where(x => x.ID_SALES_PERSON_SF == idSaleforceComercial).
                                                                        OrderByDescending(x => x.NAME)
                                                                        .ToList();
            return listadoClientes;
        }
        public List<CUSTOMERS> ObtenerOrganizacionesPorComerciales(List<string> listIdSF, bool? esAgente = null)
        {
            List<CUSTOMERS> listadoClientes = _dbContext.CUSTOMERS.Where(x => listIdSF.Contains(x.ID_SALES_PERSON_SF)).
                                                                        OrderByDescending(x => x.NAME)
                                                                        .ToList();
            return listadoClientes;
        }
        public CUSTOMERS ObtenerOrganizacionPorId(long id)
        {
            CUSTOMERS cliente = _dbContext.CUSTOMERS.Where(x => x.ID_CUSTOMER == id).FirstOrDefault();
            return cliente;
        }
    }
}
