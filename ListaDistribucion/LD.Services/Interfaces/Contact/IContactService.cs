using LD.Entities;
using LD.EntitiesLD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Services.Interfaces.Contact
{
    public interface IContactService
    {
        List<CONTACTS> ObtenerContactosPorOrganizacionId(long id);
        CONTACTS ObtenerContactoPorId(long id);
        Respuesta insertarContacto(CONTACTS contacto);
        Respuesta actualizarContacto(CONTACTS contacto);
        Respuesta eliminarContacto(CONTACTS contacto);
    }
}
