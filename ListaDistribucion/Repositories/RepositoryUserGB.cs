using LD.DataGB;
using LD.EntitiesGB;
using LD.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD.Repositories
{
    public partial class RepositoryUserGB: IRepositoryUserGB
    {
        private readonly GB_GLOBALContext _dbContext;
        public RepositoryUserGB(GB_GLOBALContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Usuarios
        public GB_user obtenerUsuarioPorId(int idUser)
        {
            GB_user usuario = _dbContext.GB_user.Where(x => x.use_id == idUser).FirstOrDefault();
            return usuario;
        }

        public List<GB_user> obtenerUsuarios(List<int> listId)
        {
            List<GB_user> usuarios = _dbContext.GB_user.Where(w=> listId.Contains(w.use_id)).ToList();
            return usuarios;
        }

        public GB_user obtenerUsuarioPorValores(long? documento, string email, string username)
        {
            GB_user usuario = (
                    from u
                    in _dbContext.GB_user
                    where
                        u.use_identification == (documento != null ? documento : u.use_identification) &&
                        u.use_mail == (email != "" ? email : u.use_mail) &&
                        u.use_user == (username != "" ? username : u.use_user) &&
                        u.use_active == true
                    select u).FirstOrDefault();
            return usuario;
        }
        #endregion

        #region Roles

        public List<GB_role> obtenerRolesPorUsuario(int idUsuario)
        {
            List<GB_role> roles = (
                    from rol in _dbContext.GB_role
                    join userRol in _dbContext.GB_userRole on rol.rol_id equals userRol.rol_id
                    where userRol.use_id == idUsuario && rol.rol_initials.StartsWith("listdis_")
                    select rol
                ).ToList();

            return roles;
        }

        public List<GB_role> obtenerRolesUsuarios()
        {
            List<GB_role> roles = (
                    from rol in _dbContext.GB_role
                    where rol.rol_initials.StartsWith("listdis_")
                    select rol
                ).ToList();

            return roles;
        }

        public List<GB_userRole> obtenerAsignacionesDeRol()
        {
            List<GB_userRole> roles = (
                    from rol in _dbContext.GB_role
                    join userRol in _dbContext.GB_userRole on rol.rol_id equals userRol.rol_id
                    where rol.rol_initials.StartsWith("listdis_")
                    select userRol
                ).ToList();

            return roles;
        }

        public List<GB_userRole> obtenerUsuariosPorRol(string[] nombreRoles)
        {
            List<GB_userRole> roles = (
                    from rol in _dbContext.GB_role
                    join userRol in _dbContext.GB_userRole on rol.rol_id equals userRol.rol_id
                    where rol.rol_initials.StartsWith("cot_") && (nombreRoles.Contains(rol.rol_name))
                    select userRol
                ).Include(i=>i.use).ToList();

            return roles;
        }

        #endregion

        #region Modulos

         public List<GB_module> obtenerModulosPorUsuarioRol(int idUsuario, int idRol)
        {
            List<GB_module> listadoModulos = (
                from m in _dbContext.GB_module
                where m.mod_initials.StartsWith("listdis_") && m.mod_active == true &&
            (
            from rp in _dbContext.GB_rolePermission
            join mp in _dbContext.GB_modulePermission on rp.modPer_id equals mp.modPer_id
            where rp.rol_id == idRol
            select mp.mod_id
            ).Contains(m.mod_id)
                select m).ToList();
            return listadoModulos;
        }

        public string ObtenerCorreosPersonasInside(string code)
        {
            string email = string.Empty;
            CGW_GEN_SalesPerson usuario = _dbContext.CGW_GEN_SalesPerson.Where(w => w.codeCW == code).FirstOrDefault();
            if (usuario != null)
                email = usuario.charEmail;
            return email;
        }

        #endregion
    }
}
