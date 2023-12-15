using LD.Entities;
using LD.Entities.Dtos;
using LD.EntitiesGB;
using LD.EntitiesLD;
using LD.Services.Interfaces.Companys;
using LD.Services.Interfaces.Integration;
using LD.Services.Interfaces.Users;
using ListaDistribucion.Web.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace ListaDistribucion.Web.Controllers.Users
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IIntegrationService _integrationService;
        private readonly ICompanyService _companyService;
        public UserController(IUserService userService, IIntegrationService integrationService, ICompanyService companyService)
        {
            _userService = userService;
            _integrationService = integrationService;
            _companyService = companyService;
        }
        public IActionResult Index()
        {
            List<USERDto> usuarios = _userService.obtenerUsuarios();
            List<GB_role> roles = _userService.obtenerRolesUsuarios();
            List<GB_userRole> asignacionesRol = _userService.obtenerAsignacionesDeRol();

            var model = new UserModel
            {
                ListadoUsuariosLD = usuarios,
                ListadoRoles = roles,
                ListadoAsignacionesRol = asignacionesRol,
            };

            return View("~/Views/User/ListUsers.cshtml", model);
        }
        public IActionResult addUser()
        {
            int idUsuario = Convert.ToInt32(HttpContext.Session.GetInt32("IdUsuario"));
            var usuario = _userService.obtenerUsuarioGBPorId(idUsuario);

            var model = new UserModel
            {
                usuario = usuario,
                Companias = _companyService.obtenerCompanias()
            };

            return View("~/Views/User/addUser.cshtml", model);
        }
        public JsonResult buscarUsuarioGBPorValores()
        {
            long? documento = null;
            if (!string.IsNullOrEmpty(Request.Form["buscar_documento"]))
                documento = Convert.ToInt64(Request.Form["buscar_documento"]);

            string email = Request.Form["buscar_email"];
            string username = Request.Form["buscar_usuario"];

            var usuario = _userService.obtenerUsuarioGBPorValores(documento, email, username);

            return Json(new { usuario = usuario.Item1, existeUser = usuario.Item2 });
        }
        public JsonResult guardarUsuario()
        {
            Respuesta respuesta = new Respuesta();

            string documento = Request.Form["documento"];
            string nombres = Request.Form["nombres"];
            string apellidos = Request.Form["apellidos"];
            string email = Request.Form["email"];
            string username = Request.Form["username"];
            string idSF = Request.Form["codigo_sf"];
            string idCW = Request.Form["codigo_cw"];
            string cargo = Request.Form["cargo"];
            string branch = Request.Form["branch"];
            bool escoger_pais = Convert.ToBoolean(Request.Form["permite_cambio_pais"]);
            int idCompania = Convert.ToInt32(Request.Form["id_compania"]);
            bool activo = Convert.ToBoolean(Request.Form["activo"]);

            ADDITIONAL_USER_INFORMATION usuario = new ADDITIONAL_USER_INFORMATION();

            usuario.POSITION = cargo;
            usuario.ID_USER_SF = idSF;
            usuario.ID_USER_CW = idCW;
            usuario.BRANCH = branch;
            usuario.CHANGE_COUNTRY = escoger_pais;
            usuario.ID_COMPANY = idCompania;

            // id_gb se envía desde formulario de importación de nuevo usuario.
            if (!string.IsNullOrEmpty(Request.Form["id_gb"]))
            {
                int idUsuario = Convert.ToInt32(Request.Form["id_gb"]);
                usuario.ID_USER_BLU = idUsuario;
                respuesta = _userService.insertarUsuario(usuario);
            }

            // id_interno se envía desde formulario de actualización de usuaurio previamente creado.
            if (!string.IsNullOrEmpty(Request.Form["id_Interno"]))
            {
                int idUsuarioInterno = Convert.ToInt32(Request.Form["id_Interno"]);
                usuario.ID_USER = idUsuarioInterno;
                respuesta = _userService.actualizarUsuario(usuario);
            }

            return Json(new { respuesta = respuesta });
        }
        public IActionResult editUsuario()
        {
            int idUsuario = Convert.ToInt32(Request.Form["idUsuario"]);
            USERDto usuario = _userService.obtenerUsuarioPorID(idUsuario);

            var model = new UserModel
            {
                usuarioDto = usuario,
                Companias = _companyService.obtenerCompanias()
            };

            return View("~/Views/User/editUser.cshtml", model);
        }
        public JsonResult ActualizarAliasSF()
        {
            Respuesta respuesta = new Respuesta();
            int idUsuario = Convert.ToInt32(Request.Form["id_usuario"]);

            USERDto usuario = _userService.obtenerUsuarioPorID(idUsuario);

            respuesta = _integrationService.actualizarAliasSF(idUsuario, usuario.EMAIL);

            return Json(new { success = respuesta.ProcesoExitoso });
        }

        //public JsonResult ActualizarAliasMasivoSF()
        //{
        //    Respuesta respuesta = new Respuesta();

        //    List<USERS_APPS> listadoUsuarios = adminBusiness.obtenerUsuarios();

        //    foreach (var usuario in listadoUsuarios)
        //        respuesta = adminBusiness.actualizarAliasSF(usuario.ID_USER, usuario.EMAIL);

        //    return Json(new { success = respuesta.ProcesoExitoso });
        //}
    }
}
