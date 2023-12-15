using LD.DataCotizador;
using LD.EntitiesCotizador;
using LD.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Repositories
{
    public class RepositorySalesSupport: IRepositorySalesSupport
    {
        private readonly BPCotizadorContext _dbContext;
        public RepositorySalesSupport(BPCotizadorContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<SALES_SUPPORTS> obtenerComercialesPorSaleSupport(int idUser)
        {
            return _dbContext.SALES_SUPPORTS.Where(w => w.ID_SALE_SUPPORT == idUser).ToList();
        }
        public List<SALES_SUPPORTS> obtenerSaleSupportPorComercial(int idUser)
        {
            return _dbContext.SALES_SUPPORTS.Where(w => w.ID_COMERCIAL == idUser).ToList();
        }
    }
}
