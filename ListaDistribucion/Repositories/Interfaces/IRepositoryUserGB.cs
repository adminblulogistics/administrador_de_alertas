using LD.EntitiesGB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Repositories.Interfaces
{
    public interface IRepositoryUserGB
    {
        #region Usuarios
        GB_user obtenerUsuarioPorId(int idUser);
        List<GB_user> obtenerUsuarios(List<int> listId);
        GB_user obtenerUsuarioPorValores(long? documento, string email, string username);
        string ObtenerCorreosPersonasInside(string code);
        #endregion

        #region Roles
        List<GB_role> obtenerRolesPorUsuario(int idUsuario);
        List<GB_role> obtenerRolesUsuarios();
        List<GB_userRole> obtenerAsignacionesDeRol();
        List<GB_userRole> obtenerUsuariosPorRol(string[] nombreRoles);
        #endregion

        #region Modulos
        List<GB_module> obtenerModulosPorUsuarioRol(int idUsuario, int idRol);
        #endregion
    }
}
