using LD.Entities;
using LD.EntitiesLD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Test
{
    public partial class CompanyServiceTest
    {
        [TestInitialize]
        public void IniciarData()
        {
            _repositoryCompany.Setup(x => x.obtenerCompanias()).Returns(lstcompanies);
            _repositoryCompany.Setup(x => x.obtenerCompaniasPorId(It.IsAny<int>())).Returns(company);

        }
        protected COMPANIES company = new COMPANIES
        {
            ID_COMPANY = 1,
            NAME = "COMPANY 1",
            ADDRESS = "Calle 170",
            CODE = "AFC",
            PHONE = "1234567",
        };
        protected Respuesta respuesta = new Respuesta
        {
            ProcesoExitoso = true,
            Id = 3,
            MensajeRespuesta = "El contacto ya esta registrado",
        };
        protected List<COMPANIES> lstcompanies = new List<COMPANIES>
        {
            new  COMPANIES
            {
                ID_COMPANY = 1,
                NAME = "COMPANY 1",
                ADDRESS = "Calle 170",
                CODE = "AFC",
                PHONE = "1234567",
            },
            new  COMPANIES
            {
                ID_COMPANY = 2,
                NAME = "COMPANY 2",
                ADDRESS = "Calle 170",
                CODE = "ZXC",
                PHONE = "1234567",
            },
            new  COMPANIES
            {
                ID_COMPANY = 3,
                NAME = "COMPANY 3",
                ADDRESS = "Calle 170",
                CODE = "ERT",
                PHONE = "1234567",
            }
        };
    }
}
