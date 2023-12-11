using LD.Entities;
using LD.Entities.Dtos;
using LD.EntitiesLD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Repositories.Interfaces
{
    public interface IRepositoryUserLD
    {
        List<ADDITIONAL_USER_INFORMATION> obtenerUsuariosLD();
        ADDITIONAL_USER_INFORMATION obtenerUsuarioLDPorID(int? id);
        ADDITIONAL_USER_INFORMATION obtenerUsuarioLDPorAlisasSF(string aliasSaleF);
        Respuesta insertarUsuario(ADDITIONAL_USER_INFORMATION usuario);
        Respuesta actualizarUsuario(ADDITIONAL_USER_INFORMATION usuario);
        Respuesta actualizarRolDefecto(USERDto usuario);

    }
}
