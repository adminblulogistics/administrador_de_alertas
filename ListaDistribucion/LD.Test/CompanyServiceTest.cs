using LD.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Test
{
    [TestClass]
    public partial class CompanyServiceTest
    {
        private readonly Mock<IRepositoryCompany> _repositoryCompany = new Mock<IRepositoryCompany>();

        [TestMethod]
        public void obtenerCompanias()
        {
            LD.Services.Interfaces.Companys.ICompanyService companyService = new LD.Services.Companys.CompanyService(_repositoryCompany.Object);
            var lstReturn = companyService.obtenerCompanias();
            Assert.IsTrue(lstReturn.Count > 0);
        }
        [TestMethod]
        public void obtenerCompaniasPorId()
        {
            LD.Services.Interfaces.Companys.ICompanyService companyService = new LD.Services.Companys.CompanyService(_repositoryCompany.Object);
            var lstReturn = companyService.obtenerCompaniasPorId(1);
            Assert.IsNotNull(lstReturn);
        }
    }
}
