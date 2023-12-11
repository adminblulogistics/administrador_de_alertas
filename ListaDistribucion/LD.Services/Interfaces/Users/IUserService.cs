using LD.Entities;
using LD.Entities.Dtos;
using LD.EntitiesCotizador;
using LD.EntitiesGB;
using LD.EntitiesLD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Services.Interfaces.Users
{
    public interface IUserService
    {
        #region Usuarios
        GB_user obtenerUsuarioGBPorId(int idUser);
        List<USERDto> obtenerUsuarios();
        (GB_user, bool) obtenerUsuarioGBPorValores(long? documento, string email, string username);
        Respuesta insertarUsuario(ADDITIONAL_USER_INFORMATION usuario);
        Respuesta actualizarUsuario(ADDITIONAL_USER_INFORMATION usuario);
        USERDto obtenerUsuarioPorID(int idUser);
        List<USERDto> obtenerComercialesPorSaleSupport(int idUser);

        ADDITIONAL_USER_INFORMATION obtenerUsuarioLDPorID(int idUser);
        ADDITIONAL_USER_INFORMATION obtenerUsuarioLDPorAlisasSF(string aliasSaleF);
        #endregion

        #region Roles
        List<GB_role> obtenerRolesPorUsuario(int idUsuario);
        List<GB_role> obtenerRolesUsuarios();
        List<GB_userRole> obtenerAsignacionesDeRol();
        List<GB_userRole> obtenerUsuariosPorRol(string[] nombreRoles);
        Respuesta actualizarRolDefecto(USERDto usuario);
        List<USERDto> obtenerUsuariosPorRol(string rol, string filtro, int idCompania);
        #endregion

        #region Modulos
        List<GB_module> obtenerModulosPorUsuarioRol(int idUsuario, int idRol);
        #endregion
    }
}
