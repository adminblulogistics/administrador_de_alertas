using LD.DataLD;
using LD.EntitiesLD;
using LD.Repositories;
using LD.Repositories.Interfaces;
using LD.Services.Interfaces.Alarms;
using LD.Services.Interfaces.Auditoria;
using LD.Services.Interfaces.Contact;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace LD.Test
{
    [TestClass]
    public partial class ContactServiceTest
    {
        private readonly Mock<IRepositoryContact> _repositoryContact = new Mock<IRepositoryContact>();
        private readonly Mock<IAlarmService> _alarmService = new Mock<IAlarmService>();
        private readonly Mock<IAuditoriaService> _auditoriaService = new Mock<IAuditoriaService>();

        [TestMethod]
        public void actualizarContacto()
        {
            LD.Services.Interfaces.Contact.IContactService contactService = new LD.Services.Contact.ContactService(_repositoryContact.Object, _alarmService.Object, _auditoriaService.Object);
            var lstReturn = contactService.actualizarContacto(Contacto);
            Assert.IsTrue(lstReturn.Id>0);
        }

        [TestMethod]
        public void eliminarContacto()
        {
            LD.Services.Interfaces.Contact.IContactService contactService = new LD.Services.Contact.ContactService(_repositoryContact.Object, _alarmService.Object, _auditoriaService.Object);
            var lstReturn = contactService.eliminarContacto(Contacto);
            Assert.IsTrue(lstReturn.ProcesoExitoso);
        }
        [TestMethod]
        public void eliminarContactoException()
        {
            LD.Services.Interfaces.Contact.IContactService contactService = new LD.Services.Contact.ContactService(_repositoryContact.Object, _alarmService.Object, null);
            var lstReturn = contactService.eliminarContacto(Contacto);
            Assert.IsFalse(lstReturn.ProcesoExitoso);
        }

        [TestMethod]
        public void insertarContacto()
        {
            LD.Services.Interfaces.Contact.IContactService contactService = new LD.Services.Contact.ContactService(_repositoryContact.Object, _alarmService.Object, _auditoriaService.Object);
            var lstReturn = contactService.insertarContacto(Contacto);
            Assert.IsTrue(lstReturn.Id > 0);
        }

        [TestMethod]
        public void validarContactoExistente()
        {            
            LD.Services.Interfaces.Contact.IContactService contactService  = new LD.Services.Contact.ContactService(_repositoryContact.Object, _alarmService.Object, _auditoriaService.Object);
            var lstReturn = contactService.validarContactoExistente(ContactoValidar);
            Assert.IsTrue(lstReturn.ProcesoExitoso);
        }
        [TestMethod]
        public void ObtenerContactoPorId()
        {
            LD.Services.Interfaces.Contact.IContactService contactService = new LD.Services.Contact.ContactService(_repositoryContact.Object, _alarmService.Object, _auditoriaService.Object);
            var lstReturn = contactService.ObtenerContactoPorId(4);
            Assert.IsNotNull(lstReturn);
        }
        [TestMethod]
        public void ObtenerContactosPorOrganizacionId()
        {
            LD.Services.Interfaces.Contact.IContactService contactService = new LD.Services.Contact.ContactService(_repositoryContact.Object, _alarmService.Object, _auditoriaService.Object);
            var lstReturn = contactService.ObtenerContactosPorOrganizacionId(1);
            Assert.IsTrue(lstReturn.Count > 0);
        }
        [TestMethod]
        public void eliminarContactosPorOrganizacion()
        {
            LD.Services.Interfaces.Contact.IContactService contactService = new LD.Services.Contact.ContactService(_repositoryContact.Object, _alarmService.Object, _auditoriaService.Object);
            var lstReturn = contactService.eliminarContactosPorOrganizacion(1);
            Assert.IsTrue(lstReturn.ProcesoExitoso);
        }
        [TestMethod]
        public void ObtenerContactosListId()
        {
            LD.Services.Interfaces.Contact.IContactService contactService = new LD.Services.Contact.ContactService(_repositoryContact.Object, _alarmService.Object, _auditoriaService.Object);
            var lstReturn = contactService.ObtenerContactosListId(1,new long[] { 1, 2 });
            Assert.IsTrue(lstReturn.Count > 0);
        } 
    }
}