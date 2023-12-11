using LD.EntitiesLD;
using LD.Repositories.Interfaces;
using LD.Services.Interfaces.Companys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Services.Companys
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepositoryCompany _repositoryCompany;
        public CompanyService(IRepositoryCompany repositoryCompany)
        {
            _repositoryCompany = repositoryCompany;
        }
        public List<COMPANIES> obtenerCompanias()
        {
            return _repositoryCompany.obtenerCompanias();
        }
        public COMPANIES obtenerCompaniasPorId(int id = 0)
        {
            return _repositoryCompany.obtenerCompaniasPorId(id);
        }
    }
}
