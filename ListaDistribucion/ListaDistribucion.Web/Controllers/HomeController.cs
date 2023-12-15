using LD.Entities.Enumerations;
using LD.EntitiesGB;
using LD.EntitiesLD;
using LD.Services.Interfaces.Parameters;
using LD.Services.Interfaces.Users;
using LD.Utilities.ExtensionMethods;
using ListaDistribucion.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace ListaDistribucion.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly IParametersService _parametersService;

        public HomeController(ILogger<HomeController> logger, IUserService userService, IParametersService parametersService)
        {
            _logger = logger;
            _userService = userService;
            _parametersService = parametersService;
        }

        [HttpGet]
        public IActionResult Index(string token)
        {
            token = "Qmx1fDMwLzExLzIwMjN8MTc5N3xDYW1pbG8gRXJuZXN0byBHYWl0YW4gUml2ZXJvc3xjYW1pbG8uZ2FpdGFufE5ldA==";
            HomeModel model = new HomeModel();

            SYSTEM_PARAMS systemParam = _parametersService.obtenerParametrosSistemaPorDescripcion("UrlLoginBlunet");
            SYSTEM_PARAMS logout = _parametersService.obtenerParametrosSistemaPorDescripcion("UrlLogoutBlunet");

            model.urlLogin = systemParam.VALUE;
            model.urlLogout = logout.VALUE;

            int idUsuario = 0;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetInt32("IdUsuario").ToString()))
                idUsuario = Convert.ToInt32(HttpContext.Session.GetInt32("IdUsuario"));

            #region Recuperación de datos cuando el token no es vacío
            if (!string.IsNullOrEmpty(token))
            {

                byte[] base64EncodedBytes = null;
                string tokenDecrypt = null;

                try
                {
                    base64EncodedBytes = System.Convert.FromBase64String(token);
                    tokenDecrypt = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
                }
                catch (Exception e)
                {
                    model.errorCode = (int)Enumeraciones.ErroresLogin.excepcionSistema;
                    model.systemException = e.Message;
                }

                if (!string.IsNullOrEmpty(tokenDecrypt))
                {
                    var arrTokenDecrypt = tokenDecrypt.Split('|');

                    if (arrTokenDecrypt.Count() > 0)
                    {
                        idUsuario = Convert.ToInt32(arrTokenDecrypt[2]);
                        idUsuario = 2515; //IdProducción

                        GB_user usuario = _userService.obtenerUsuarioGBPorId(idUsuario);

                        List<GB_role> rolesUsuario = _userService.obtenerRolesPorUsuario(idUsuario);

                        if (rolesUsuario.Count() == 0)
                        {
                            model.errorCode = (int)Enumeraciones.ErroresLogin.usuarioSinRol;
                            return View("~/Views/Shared/Login.cshtml", model);
                        }

                        GB_role rolInicial = rolesUsuario.FirstOrDefault();

                        string nombre = usuario.use_name;
                        string apellido = usuario.use_lastName;
                        string nombreDeusuario = usuario.use_user;
                        string email = usuario.use_mail;
                        string cargo = (string.IsNullOrEmpty(usuario.use_charge) ? "Sin registrar" : usuario.use_charge.ToString());
                        int compania = 1;
                        string nombreCompania = "COLOMBIA";
                        string codeCompania = "COL";

                        HttpContext.Session.SetString("Usuario", nombreDeusuario);
                        HttpContext.Session.SetString("NombresUsuario", nombre);
                        HttpContext.Session.SetString("ApellidosUsuario", apellido);
                        HttpContext.Session.SetString("CorreoUsuario", email);
                        HttpContext.Session.SetString("CargoUsuario", cargo);
                        HttpContext.Session.SetInt32("IdRol", rolInicial.rol_id);
                        HttpContext.Session.SetString("Rol", rolInicial.rol_name);
                        HttpContext.Session.SetString("RolTag", rolInicial.rol_initials);
                        HttpContext.Session.SetInt32("IdUsuario", idUsuario);
                        HttpContext.Session.SetInt32("IdCompania", compania);
                        HttpContext.Session.SetString("NombreCompania", nombreCompania);
                        HttpContext.Session.SetString("CodeCompania", codeCompania);

                        string pais = string.Empty;
                        if (compania == Convert.ToInt32(Enumeraciones.Pais.Colombia))
                            pais = "COLOMBIA";
                        else if (compania == Convert.ToInt32(Enumeraciones.Pais.Ecuador))
                            pais = "ECUADOR";
                        else if (compania == Convert.ToInt32(Enumeraciones.Pais.Mexico))
                            pais = "MEXICO";

                        HttpContext.Session.SetString("Pais", pais);

                        var timeOutSession = Convert.ToInt64(AppDomain.CurrentDomain.GetData("TimeOutSession"));
                        var fechaActual = DateTime.Now.AddMinutes(timeOutSession).ToString("yyyy-MM-dd HH:mm:ss");
                        HttpContext.Session.SetString("ExpireSession", fechaActual);

                        //PARA AUDITORIA
                        AppDomain.CurrentDomain.SetData("UserName", nombreDeusuario);
                        AppDomain.CurrentDomain.SetData("IdUser", idUsuario);

                        List<GB_module> listadoTodosModulos = _userService.obtenerModulosPorUsuarioRol(idUsuario, rolInicial.rol_id).ToList();
                        List<GB_module> listadoPadres = listadoTodosModulos.Where(x => x.mod_fatherId == null).OrderBy(x => x.mod_name).ToList();
                        List<GB_module> listadoTodosHijos = listadoTodosModulos.Where(x => x.mod_fatherId != null).OrderBy(x => x.mod_name).ToList();

                        HttpContext.Session.SetString("userModules", JsonSerializer.Serialize(listadoTodosHijos.Select(x => x.mod_initials).ToList()));

                        model.ListadoModulosPadres = listadoPadres;
                        model.ListadoModulosHijos = listadoTodosHijos;

                        return View("~/Views/Home/Home.cshtml", model);

                    }
                    else
                    {
                        model.errorCode = (int)Enumeraciones.ErroresLogin.tokenInvalido;
                        return View("~/Views/Shared/Login.cshtml", model);
                    }
                }

                else
                {
                    model.errorCode = (int)Enumeraciones.ErroresLogin.tokenInvalido;
                    return View("~/Views/Shared/Login.cshtml", model);
                }
            }
            #endregion
            else
            {
                if (idUsuario != 0)
                {
                    if (!string.IsNullOrEmpty(Request.Query["Compania"]))
                    {
                        int compania2 = Convert.ToInt32(Request.Query["Compania"]);
                        HttpContext.Session.SetInt32("IdCompania", Convert.ToInt32(compania2));
                    }

                    if (!string.IsNullOrEmpty(Request.Query["idUsuario"]))
                    {
                        int idUsuario2 = Convert.ToInt32(Request.Query["idUsuario"]);
                        HttpContext.Session.SetInt32("IdUsuario", Convert.ToInt32(idUsuario2));
                    }

                    int idRol = Convert.ToInt32(HttpContext.Session.GetInt32("IdRol"));

                    List<GB_module> listadoTodosModulos = _userService.obtenerModulosPorUsuarioRol(idUsuario, idRol).ToList();
                    List<GB_module> listadoPadres = listadoTodosModulos.Where(x => x.mod_fatherId == null).OrderBy(x => x.mod_name).ToList();
                    List<GB_module> listadoTodosHijos = listadoTodosModulos.Where(x => x.mod_fatherId != null).OrderBy(x => x.mod_name).ToList();

                    HttpContext.Session.SetString("userModules", JsonSerializer.Serialize(listadoTodosHijos.Select(x => x.mod_initials).ToList()));

                    model.ListadoModulosPadres = listadoPadres;
                    model.ListadoModulosHijos = listadoTodosHijos;

                    return View("~/Views/Home/Home.cshtml", model);
                }
                else
                {
                    model.errorCode = (int)Enumeraciones.ErroresLogin.sesionNula;
                    return View("~/Views/Shared/Login.cshtml", model);
                }
            }
        }

        public ActionResult Logout()
        {
            SYSTEM_PARAMS urlLogin = _parametersService.obtenerParametrosSistemaPorDescripcion("UrlLoginBlunet");
            string urlBlunet = urlLogin.VALUE;

            HttpContext.Session.Clear();

            return Redirect(urlBlunet);
        }

        public ActionResult LogoutAuto()
        {
            SYSTEM_PARAMS systemParam = _parametersService.obtenerParametrosSistemaPorDescripcion("UrlLoginBlunet");

            HttpContext.Session.Clear();

            HomeModel model = new HomeModel();
            model.errorCode = (int)Enumeraciones.ErroresLogin.sessionExpira;
            model.urlLogin = systemParam.VALUE;

            return View("~/Views/Shared/Login.cshtml", model);
        }
    }
}