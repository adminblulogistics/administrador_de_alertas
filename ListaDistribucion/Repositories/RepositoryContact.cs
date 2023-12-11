using LD.DataLD;
using LD.Entities;
using LD.EntitiesLD;
using LD.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Repositories
{
    public class RepositoryContact : IRepositoryContact
    {
        private readonly ListaDistribucionContext _dbContext;
        public RepositoryContact(ListaDistribucionContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Respuesta actualizarContacto(CONTACTS contacto)
        {
            Respuesta respuesta = new Respuesta();

            CONTACTS contactoActualizar = _dbContext.CONTACTS
                .Where(x => x.ID_CONTACT == contacto.ID_CONTACT)
                .FirstOrDefault();

            contactoActualizar.NAME_CONTACT = contacto.NAME_CONTACT;
            contactoActualizar.PHONE_CONTACT = contacto.PHONE_CONTACT;
            contactoActualizar.ID_ORGANIZATION_BODEGA = contacto.ID_ORGANIZATION_BODEGA;
            contactoActualizar.EMAIL_CONTACT = contacto.EMAIL_CONTACT;
            contactoActualizar.DATE_UPDATE = DateTime.UtcNow.AddHours(-5);

            _dbContext.SaveChanges();

            respuesta.ProcesoExitoso = true;
            respuesta.Id = contacto.ID_CONTACT;

            return respuesta;
        }

        public Respuesta eliminarContacto(CONTACTS contacto)
        {
            _dbContext.CONTACTS.Remove(contacto);
            _dbContext.SaveChanges();
            Respuesta respuesta = new Respuesta { ProcesoExitoso = true };
            return respuesta;
        }

        public Respuesta insertarContacto(CONTACTS contacto)
        {
            Respuesta respuesta = new Respuesta();
            contacto.DATE_CREATED= DateTime.UtcNow.AddHours(-5);

            _dbContext.CONTACTS.Add(contacto);
            _dbContext.SaveChanges();

            respuesta.ProcesoExitoso = true;
            respuesta.Id = contacto.ID_CONTACT;

            return respuesta;
        }

        public CONTACTS ObtenerContactoPorId(long id)
        {
            return _dbContext.CONTACTS.Where(w => w.ID_CONTACT == id).FirstOrDefault();
        }

        public List<CONTACTS> ObtenerContactosPorOrganizacionId(long id)
        {
            return _dbContext.CONTACTS.Where(w => w.ID_ORGANIZATION_BODEGA == id).ToList();
        }
    }
}
