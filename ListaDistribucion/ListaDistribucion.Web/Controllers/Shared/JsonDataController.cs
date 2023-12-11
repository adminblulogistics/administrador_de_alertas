using LD.Entities.Dtos;
using LD.Entities.Enumerations;
using LD.Services.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace ListaDistribucion.Web.Controllers.Shared
{
    public class JsonDataController : BaseController
    {
        private readonly IUserService _userService;
        public JsonDataController(IUserService userService)
        {
            _userService = userService;
        }
        public JsonResult ObtenerComerciales()
        {
            string filtro = Request.Query["f"];
            int idCompania = Convert.ToInt32(HttpContext.Session.GetInt32("IdCompania"));

            List<USERDto> listado = _userService.obtenerUsuariosPorRol(Enum.GetName(typeof(Enumeraciones.PerfilesModulo), Enumeraciones.PerfilesModulo.AA_Comercial).Replace("_", " "),filtro, idCompania);

            var listadoTemp =
                (
                    from lp in listado
                    orderby lp.USERNAME
                    select new
                    {
                        value = lp.ID_USER,
                        text = lp.USERNAME
                    }
                ).ToList();

            return Json(listadoTemp);
        }
        public JsonResult ObtenerSaleSupport()
        {
            string filtro = Request.Query["f"];
            int idCompania = Convert.ToInt32(HttpContext.Session.GetInt32("IdCompania"));

            List<USERDto> listado = _userService.obtenerUsuariosPorRol(Enum.GetName(typeof(Enumeraciones.PerfilesModulo), Enumeraciones.PerfilesModulo.AA_Sales_Support).Replace("_", " "), filtro, idCompania);

            var listadoTemp =
                (
                    from lp in listado
                    orderby lp.USERNAME
                    select new
                    {
                        value = lp.ID_USER,
                        text = lp.USERNAME
                    }
                ).ToList();

            return Json(listadoTemp);
        }
        public JsonResult ObtenerEjecutivos()
        {
            string filtro = Request.Query["f"];
            int idCompania = Convert.ToInt32(HttpContext.Session.GetInt32("IdCompania"));

            List<USERDto> listado = _userService.obtenerUsuariosPorRol(Enum.GetName(typeof(Enumeraciones.PerfilesModulo), Enumeraciones.PerfilesModulo.AA_Ejecutivo_de_cuenta).Replace("_", " "), filtro, idCompania);

            var listadoTemp =
                (
                    from lp in listado
                    orderby lp.USERNAME
                    select new
                    {
                        value = lp.ID_USER,
                        text = lp.USERNAME
                    }
                ).ToList();

            return Json(listadoTemp);
        }
    }
}
