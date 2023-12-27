using LD.DataLD;
using LD.Entities;
using LD.EntitiesLD;
using LD.Repositories;
using LD.Repositories.Interfaces;
using LD.Services.Interfaces.Alarms;
using LD.Services.Interfaces.Auditoria;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace LD.Test
{
    public partial class ContactServiceTest
    {

        [TestInitialize]
        public void IniciarData()
        {
            _repositoryContact.Setup(x => x.validarContactoExistente(It.IsAny<CONTACTS>())).Returns(respuesta);
            _repositoryContact.Setup(x => x.actualizarContacto(It.IsAny<CONTACTS>())).Returns(respuesta);
            _alarmService.Setup(x => x.eliminarAlarmasPorContacto(It.IsAny<long>())).Returns(respuesta);
            _auditoriaService.Setup(x => x.insertarAuditoria(It.IsAny<ACTIVITY_LOG>())).Returns(respuesta);
            _repositoryContact.Setup(x => x.eliminarContacto(It.IsAny<CONTACTS>())).Returns(respuesta);
            _repositoryContact.Setup(x => x.insertarContacto(It.IsAny<CONTACTS>())).Returns(respuesta);
            _repositoryContact.Setup(x => x.ObtenerContactoPorId(It.IsAny<long>())).Returns(Contacto);
            _repositoryContact.Setup(x => x.ObtenerContactosPorOrganizacionId(It.IsAny<long>())).Returns(lstcontactos);
            _repositoryContact.Setup(x => x.eliminarContactosPorOrganizacion(It.IsAny<int>())).Returns(respuesta);
            _repositoryContact.Setup(x => x.ObtenerContactosListId(It.IsAny<long>(), It.IsAny<long[]>())).Returns(lstcontactos);

        }
        protected CONTACTS ContactoValidar = new CONTACTS
        {
            ID_CONTACT = 3,
            NAME_CONTACT = "Diego",
            LASTNAME_CONTACT = "Rodiguez",
            EMAIL_CONTACT = "diego.rodriguez@prueba.com",
            ID_ORGANIZATION_BODEGA = 3,
            PHONE_CONTACT = "4367893",
            DATE_CREATED = DateTime.Now,
            DATE_UPDATE = DateTime.Now,
            ID_ORGANIZATION_BODEGANavigation = new ADDITIONAL_ORGANIZATION_INFORMATION
            {
                ID_ORGANIZATION = 3,
                ID_ORGANIZATION_BODEGA = 3,
                ID_SERVICE_CLIENT = 3
            }
        };
        protected CONTACTS Contacto = new CONTACTS
        {
            ID_CONTACT = 4,
            NAME_CONTACT = "Andres",
            LASTNAME_CONTACT = "Rodiguez",
            EMAIL_CONTACT = "andres.rodriguez@prueba.com",
            ID_ORGANIZATION_BODEGA = 4,
            PHONE_CONTACT = "23451234",
            DATE_CREATED = DateTime.Now,
            DATE_UPDATE = DateTime.Now,
            ID_ORGANIZATION_BODEGANavigation = new ADDITIONAL_ORGANIZATION_INFORMATION
            {
                ID_ORGANIZATION = 4,
                ID_ORGANIZATION_BODEGA = 4,
                ID_SERVICE_CLIENT = 4
            }
        };
        protected Respuesta respuesta = new Respuesta
        {
            ProcesoExitoso = true,
            Id = 3,
            MensajeRespuesta = "El contacto ya esta registrado",
        };
        protected  List<CONTACTS> lstcontactos = new List<CONTACTS>
            {
               new CONTACTS
               {
                   ID_CONTACT=1,
                   NAME_CONTACT= "Juan",
                   LASTNAME_CONTACT = "Perez",
                   EMAIL_CONTACT = "juan.perez@prueba.com",
                   ID_ORGANIZATION_BODEGA = 1,
                   PHONE_CONTACT = "1234567",
                   DATE_CREATED = DateTime.Now,
                   DATE_UPDATE = DateTime.Now,
                   ID_ORGANIZATION_BODEGANavigation = new ADDITIONAL_ORGANIZATION_INFORMATION { ID_ORGANIZATION=1 ,ID_ORGANIZATION_BODEGA = 1,
                   ID_SERVICE_CLIENT=1}
               },
               new CONTACTS
               {
                   ID_CONTACT=2,
                   NAME_CONTACT= "Cristian",
                   LASTNAME_CONTACT = "Lopez",
                   EMAIL_CONTACT = "cristian.lopez@prueba.com",
                   ID_ORGANIZATION_BODEGA = 2,
                   PHONE_CONTACT = "8889999",
                   DATE_CREATED = DateTime.Now,
                   DATE_UPDATE = DateTime.Now,
                   ID_ORGANIZATION_BODEGANavigation = new ADDITIONAL_ORGANIZATION_INFORMATION { ID_ORGANIZATION=2, ID_ORGANIZATION_BODEGA = 2,
                   ID_SERVICE_CLIENT=2}
               },
               new CONTACTS
               {
                   ID_CONTACT=3,
                   NAME_CONTACT= "Diego",
                   LASTNAME_CONTACT = "Rodiguez",
                   EMAIL_CONTACT = "diego.rodriguez@prueba.com",
                   ID_ORGANIZATION_BODEGA = 3,
                   PHONE_CONTACT = "4367893",
                   DATE_CREATED = DateTime.Now,
                   DATE_UPDATE = DateTime.Now,
                   ID_ORGANIZATION_BODEGANavigation = new ADDITIONAL_ORGANIZATION_INFORMATION { ID_ORGANIZATION=3 ,ID_ORGANIZATION_BODEGA = 3,
                   ID_SERVICE_CLIENT=3}
               }
            };
    }
}