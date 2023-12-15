using LD.DataLD;
using LD.EntitiesLD;
using LD.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Repositories
{
    public class RepositoryCompany : IRepositoryCompany
    {
        private readonly ListaDistribucionContext _dbContext;
        public RepositoryCompany(ListaDistribucionContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<COMPANIES> obtenerCompanias()
        {
            List<COMPANIES> listadoCompanias = _dbContext.COMPANIES.ToList();
            return listadoCompanias;
        }
        public COMPANIES obtenerCompaniasPorId(int id = 0)
        {
            COMPANIES compania = _dbContext.COMPANIES.Where(x => x.ID_COMPANY == id).FirstOrDefault();
            return compania;
        }
    }
}
