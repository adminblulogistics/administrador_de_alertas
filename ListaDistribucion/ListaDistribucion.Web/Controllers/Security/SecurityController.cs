using LD.Entities.Dtos;
using LD.EntitiesGB;
using LD.EntitiesLD;
using LD.Services.Interfaces.Companys;
using LD.Services.Interfaces.Users;
using ListaDistribucion.Web.Models.Security;
using Microsoft.AspNetCore.Mvc;

namespace ListaDistribucion.Web.Controllers.Security
{
    public class SecurityController : BaseController
    {
        private readonly IUserService _userService;
        private readonly ICompanyService _companyService;
        public SecurityController(IUserService userService, ICompanyService companyService)
        {
            _userService = userService;
            _companyService = companyService;
        }
        public IActionResult selectRole()
        {
            int idUsuario = Convert.ToInt32(HttpContext.Session.GetInt32("IdUsuario"));
            USERDto usuario = _userService.obtenerUsuarioPorID(idUsuario);
            List<GB_role> rolesUsuario = _userService.obtenerRolesPorUsuario(idUsuario);
            bool cambiarCompania = (bool)usuario.CHANGE_COUNTRY;

            SecurityModel model = new SecurityModel
            {
                ListadoRoles = rolesUsuario,
                cambiarCompania = cambiarCompania,
                Rol = HttpContext.Session.GetString("Rol"),
                Usuario = usuario
            };

            return View("~/Views/Security/SelectRole.cshtml", model);
        }

        public JsonResult changeRole()
        {
            int idRol = Convert.ToInt32(Request.Form["idRol"]);
            string rol = Request.Form["rol"];
            string tag = Request.Form["tag"];

            HttpContext.Session.SetInt32("IdRol", idRol);
            HttpContext.Session.SetString("Rol", rol);
            HttpContext.Session.SetString("RolTag", tag);

            return Json(new { success = true });
        }

        public JsonResult changeDefaultRole()
        {
            int idRol = Convert.ToInt32(Request.Form["idRol"]);
            int idUsuario = Convert.ToInt32(Request.Form["idUsuario"]);

            USERDto usuario = _userService.obtenerUsuarioPorID(idUsuario);
            USERDto usuarioRolnuevo = new USERDto();
            usuarioRolnuevo.ID_USER = usuario.ID_USER;
            usuarioRolnuevo.ID_USER_SF = usuario.ID_USER_SF;
            usuarioRolnuevo.ID_USER_CW = usuario.ID_USER_CW;
            usuarioRolnuevo.USERNAME = usuario.USERNAME;
            usuarioRolnuevo.DOCUMENT_NUMBER = usuario.DOCUMENT_NUMBER;
            usuarioRolnuevo.FIRST_NAME = usuario.FIRST_NAME;
            usuarioRolnuevo.LAST_NAME = usuario.LAST_NAME;
            usuarioRolnuevo.POSITION = usuario.POSITION;
            usuarioRolnuevo.EMAIL = usuario.EMAIL;
            usuarioRolnuevo.IS_ACTIVE = usuario.IS_ACTIVE;
            usuarioRolnuevo.BRANCH = usuario.BRANCH;
            usuarioRolnuevo.ID_COMPANY = usuario.ID_COMPANY;
            usuarioRolnuevo.CHANGE_COUNTRY = usuario.CHANGE_COUNTRY;
            usuarioRolnuevo.DEFAULT_ROL = idRol;

            _userService.actualizarRolDefecto(usuarioRolnuevo);

            return Json(new { success = true });
        }

        public JsonResult changeCompany()
        {
            int idCompany = Convert.ToInt32(Request.Form["idPais"]);
            COMPANIES compania = _companyService.obtenerCompaniasPorId(idCompany);
            HttpContext.Session.SetInt32("IdCompania", idCompany);
            HttpContext.Session.SetString("NombreCompania", compania.NAME);
            HttpContext.Session.SetString("CodeCompania", compania.CODE);
            return Json(new { success = true });
        }
    }
}
