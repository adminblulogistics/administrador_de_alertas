﻿using LD.Entities;
using LD.EntitiesLD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Repositories.Interfaces
{
    public interface IRepositoryContact
    {
        List<CONTACTS> ObtenerContactosPorOrganizacionId(long id);
        List<CONTACTS> ObtenerContactosListId(long id, long[] ids);
        CONTACTS ObtenerContactoPorId(long id);
        Respuesta actualizarContacto(CONTACTS contacto);
        Respuesta insertarContacto(CONTACTS contacto);
        Respuesta eliminarContacto(CONTACTS contacto);
        Respuesta validarContactoExistente(CONTACTS contacto);
        Respuesta eliminarContactosPorOrganizacion(int id);
    }
}
