using LD.Entities;
using LD.EntitiesLD;
using LD.Repositories.Interfaces;
using LD.Services.Interfaces.Alarms;
using LD.Services.Interfaces.Auditoria;
using LD.Services.Interfaces.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LD.Services.Contact
{
    public class ContactService : IContactService
    {
        private readonly IRepositoryContact _repositoryContact;
        private readonly IAlarmService _alarmService;
        private readonly IAuditoriaService _auditoriaService;
        public ContactService(IRepositoryContact repositoryContact, IAlarmService alarmService, IAuditoriaService auditoriaService)
        {
            _repositoryContact = repositoryContact;
            _alarmService = alarmService;
            _auditoriaService = auditoriaService;
        }

        public Respuesta actualizarContacto(CONTACTS contacto)
        {
            return _repositoryContact.actualizarContacto(contacto);
        }

        public Respuesta eliminarContacto(CONTACTS contacto)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = _alarmService.eliminarAlarmasPorContacto(contacto.ID_CONTACT);
                if (respuesta.ProcesoExitoso)
                {
                    _auditoriaService.insertarAuditoria(new ACTIVITY_LOG { ID_CLIENT = contacto.ID_ORGANIZATION_BODEGA, OPERATION = "Elimina Contacto", OLD_VALUE = contacto.NAME_CONTACT + Environment.NewLine + contacto.EMAIL_CONTACT + Environment.NewLine + contacto.PHONE_CONTACT, NEW_VALUE =""});
                    respuesta = _repositoryContact.eliminarContacto(contacto);

                }

                respuesta.ProcesoExitoso = true;
            }
            catch (Exception ex)
            {
                respuesta.ProcesoExitoso = false;
                respuesta.MensajeRespuesta = ex.Message;
            }
            return respuesta;
        }

        public Respuesta insertarContacto(CONTACTS contacto)
        {
            return _repositoryContact.insertarContacto(contacto);
        }
        public Respuesta validarContactoExistente(CONTACTS contacto)
        {
            return _repositoryContact.validarContactoExistente(contacto);
        }

        public CONTACTS ObtenerContactoPorId(long id)
        {
            return _repositoryContact.ObtenerContactoPorId(id);
        }

        public List<CONTACTS> ObtenerContactosPorOrganizacionId(long id)
        {
            return _repositoryContact.ObtenerContactosPorOrganizacionId(id);
        }

        public Respuesta eliminarContactosPorOrganizacion(int id)
        {
            return _repositoryContact.eliminarContactosPorOrganizacion(id);
        }

        public List<CONTACTS> ObtenerContactosListId(long id, long[] ids)
        {
            return _repositoryContact.ObtenerContactosListId(id, ids);
        }
    }
}
