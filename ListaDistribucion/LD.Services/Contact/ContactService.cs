using LD.Entities;
using LD.EntitiesLD;
using LD.Repositories.Interfaces;
using LD.Services.Interfaces.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Services.Contact
{
    public class ContactService : IContactService
    {
        private readonly IRepositoryContact _repositoryContact;
        public ContactService(IRepositoryContact repositoryContact)
        {
            _repositoryContact = repositoryContact;
        }

        public Respuesta actualizarContacto(CONTACTS contacto)
        {
            return _repositoryContact.actualizarContacto(contacto);
        }

        public Respuesta eliminarContacto(CONTACTS contacto)
        {
            return _repositoryContact.eliminarContacto(contacto);
        }

        public Respuesta insertarContacto(CONTACTS contacto)
        {
            return _repositoryContact.insertarContacto(contacto);
        }

        public CONTACTS ObtenerContactoPorId(long id)
        {
            return _repositoryContact.ObtenerContactoPorId(id);
        }

        public List<CONTACTS> ObtenerContactosPorOrganizacionId(long id)
        {
            return _repositoryContact.ObtenerContactosPorOrganizacionId(id);
        }
    }
}
