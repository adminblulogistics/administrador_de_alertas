using LD.Services.Interfaces.Users;
using LD.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LD.EntitiesGB;
using LD.Entities.Dtos;
using LD.EntitiesLD;
using LD.Entities;
using LD.EntitiesCotizador;

namespace LD.Services.Users
{
    public partial class UserService: Common.BaseServiceApplication<LD.EntitiesGB.GB_user>,IUserService
    {
        private readonly IRepositoryUserGB _repositoryUserGB;
        private readonly IRepositoryUserLD _repositoryUserLD;
        private readonly IRepositorySalesSupport _repositorySalesSupport;
        public UserService(IRepositoryUserGB repositoryUser, IRepositoryUserLD repositoryLD, IRepositorySalesSupport repositorySalesSupport)
        {
            _repositoryUserGB = repositoryUser;
            _repositoryUserLD = repositoryLD;
            _repositorySalesSupport = repositorySalesSupport;
        }

        protected override void ValidationsToCreate(GB_user entity)
        {
        }
        protected override void ValidationsToEdit(GB_user entity)
        {
        }

        public List<GB_userRole> obtenerAsignacionesDeRol()
        {
            return _repositoryUserGB.obtenerAsignacionesDeRol();
        }

        public List<GB_role> obtenerRolesPorUsuario(int idUsuario)
        {
            return _repositoryUserGB.obtenerRolesPorUsuario(idUsuario);
        }
        public List<USERDto> obtenerUsuarios()
        {
            List<int> listIds = new List<int>();
            List<USERDto> lstUsers = new List<USERDto>();
            var listUsuariosLD = _repositoryUserLD.obtenerUsuariosLD();
            if (listUsuariosLD.Any())
            {
                listIds = listUsuariosLD.Select(u => u.ID_USER_BLU).ToList();
                var listUsuariosGB = _repositoryUserGB.obtenerUsuarios(listIds);
                if (listUsuariosGB.Any())
                {
                    lstUsers = (from uld in listUsuariosLD
                                join ugb in listUsuariosGB on uld.ID_USER_BLU equals ugb.use_id
                                select new USERDto { 
                                ID_USER = ugb.use_id,
                                ID_USER_CW = uld.ID_USER_CW,
                                ID_USER_SF = uld.ID_USER_SF,
                                BRANCH = uld.BRANCH,
                                CHANGE_COUNTRY = uld.CHANGE_COUNTRY,
                                DOCUMENT_NUMBER = ugb.use_identification.ToString(),
                                EMAIL = ugb.use_mail,
                                FIRST_NAME = ugb.use_name,
                                LAST_NAME = ugb.use_lastName,
                                POSITION = uld.POSITION,
                                ID_COMPANY = uld.ID_COMPANY,
                                COMPANY_NAME = uld.ID_COMPANYNavigation.NAME,
                                IS_ACTIVE = ugb.use_active,
                                USERNAME = ugb.use_name
                                }).ToList();
                }
            }

            return lstUsers;
        }

        public List<GB_userRole> obtenerUsuariosPorRol(string[] nombreRoles)
        {
            return _repositoryUserGB.obtenerUsuariosPorRol(nombreRoles);
        }

        public List<GB_role> obtenerRolesUsuarios()
        {
            return _repositoryUserGB.obtenerRolesUsuarios();
        }

        public GB_user obtenerUsuarioGBPorId(int idUser)
        {
            return _repositoryUserGB.obtenerUsuarioPorId(idUser);
        }
        public USERDto obtenerUsuarioPorID(int idUser)
        {
            USERDto user = new USERDto();
            var userLD = _repositoryUserLD.obtenerUsuarioLDPorID(idUser);
            if (userLD != null)
            {
                var userGB = _repositoryUserGB.obtenerUsuarioPorId(userLD.ID_USER_BLU);
                user.ID_USER = userGB.use_id;
                user.ID_USER_CW = userLD.ID_USER_CW;
                user.ID_USER_SF = userLD.ID_USER_SF;
                user.BRANCH = userLD.BRANCH;
                user.CHANGE_COUNTRY = userLD.CHANGE_COUNTRY;
                user.DOCUMENT_NUMBER = userGB.use_identification.ToString();
                user.EMAIL = userGB.use_mail;
                user.FIRST_NAME = userGB.use_name;
                user.LAST_NAME = userGB.use_lastName;
                user.POSITION = userLD.POSITION;
                user.ID_COMPANY = userLD.ID_COMPANY;
                user.COMPANY_NAME = userLD.ID_COMPANYNavigation.NAME;
                user.IS_ACTIVE = userGB.use_active;
                user.USERNAME = userGB.use_name;
            }
            return user;
        }
        public ADDITIONAL_USER_INFORMATION obtenerUsuarioLDPorID(int idUser)
        {
            return _repositoryUserLD.obtenerUsuarioLDPorID(idUser);
        }
        public ADDITIONAL_USER_INFORMATION obtenerUsuarioLDPorAlisasSF(string aliasSaleF)
        {
            return _repositoryUserLD.obtenerUsuarioLDPorAlisasSF(aliasSaleF);
        }
        public (GB_user,bool) obtenerUsuarioGBPorValores(long? documento, string email, string username)
        {
            bool existUserLD = false;
            GB_user usuarioGB = _repositoryUserGB.obtenerUsuarioPorValores(documento, email, username);
            if (usuarioGB != null)
            {
                var usuarioLD = _repositoryUserLD.obtenerUsuarioLDPorID(usuarioGB.use_id);
                existUserLD = usuarioLD!= null;
            }
            return (usuarioGB, existUserLD);
        }

        public List<GB_module> obtenerModulosPorUsuarioRol(int idUsuario, int idRol)
        {
            return _repositoryUserGB.obtenerModulosPorUsuarioRol(idUsuario, idRol);
        }

        public Respuesta insertarUsuario(ADDITIONAL_USER_INFORMATION usuario)
        {
            return _repositoryUserLD.insertarUsuario(usuario);
        }
        public Respuesta actualizarUsuario(ADDITIONAL_USER_INFORMATION usuario)
        {
            return _repositoryUserLD.actualizarUsuario(usuario);
        }
        public Respuesta actualizarRolDefecto(USERDto usuario)
        {
            return _repositoryUserLD.actualizarRolDefecto(usuario);
        }
        public List<USERDto> obtenerUsuariosPorRol(string rol, string filtro, int idCompania)
        {
            string[] nombreRoles = new string[] { rol };
            List<USERDto> lisUsuariosDto = new List<USERDto>();
            var lisUsuariosLD = this.obtenerUsuarios().Where(w=>w.ID_COMPANY == idCompania);
            if (lisUsuariosLD.Any())
            {
                var lisUsuarios = this.obtenerUsuariosPorRol(nombreRoles);
                if (lisUsuarios.Any())
                {
                    var SelectUsariosLD = (from u in lisUsuarios
                                          join usld in lisUsuariosLD on u.use_id equals usld.ID_USER
                                          where (u.use.use_name.ToLower().Contains(filtro.ToLower()) || u.use.use_lastName.ToLower().Contains(filtro.ToLower()))
                                           select u).ToList();
                    foreach (var us in SelectUsariosLD)
                    {
                        USERDto user = new USERDto();
                        user.USERNAME = us.use.use_name + " " + us.use.use_lastName;
                        user.ID_USER = us.use_id;
                        user.EMAIL = us.use.use_mail;
                        lisUsuariosDto.Add(user);
                    }
                }
            }            
            return lisUsuariosDto;
        }
        public List<USERDto> obtenerComercialesPorSaleSupport(int idUser)
        {
            List<SALES_SUPPORTS> listComercialesSaleSuppor = new List<SALES_SUPPORTS>();
            List<GB_user> listUsuariosGB = new List<GB_user>();
            List<USERDto> listComerciales = new List<USERDto>();

            listComercialesSaleSuppor = _repositorySalesSupport.obtenerComercialesPorSaleSupport(idUser);
            if (listComercialesSaleSuppor.Any())
            {
                var idsComerciales = listComercialesSaleSuppor.Select(s=>(int)s.ID_COMERCIAL).ToList();
                listUsuariosGB = _repositoryUserGB.obtenerUsuarios(idsComerciales);
            }
            foreach (var u in listUsuariosGB)
            {
                var userLD = _repositoryUserLD.obtenerUsuarioLDPorID(u.use_id);
                if (userLD != null)
                {
                    USERDto user = new USERDto();
                    user.ID_USER = u.use_id;
                    user.FIRST_NAME = u.use_name;
                    user.LAST_NAME = u.use_lastName;
                    user.ID_USER_SF = userLD.ID_USER_SF;
                    listComerciales.Add(user);
                }
            }

            return listComerciales;
        }
    }
}