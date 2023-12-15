using LD.Entities;
using LD.EntitiesLD;
using LD.Services.Interfaces.Parameters;
using LD.Services.Parameters;
using ListaDistribucion.Web.Models.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace ListaDistribucion.Web.Controllers.Parameters
{
    public class ParameterController : BaseController
    {
        private readonly IParametersService _parametersService;
        public ParameterController(IParametersService parametersService)
        {
            _parametersService = parametersService;
        }
        public IActionResult Index()
        {
            List<SYSTEM_PARAMS> listParametros = _parametersService.obtenerParametros().Where(x => x.UPDATABLE == true).ToList();

            var model = new ParametersModel
            {
                ListadoParametros = listParametros
            };

            return View("~/Views/Parameters/ListParameters.cshtml", model);
        }
        public ActionResult GuardarParametros()
        {
            Respuesta respuesta = new Respuesta();
            var totalParametros = Convert.ToInt32(Request.Form["total_parametros"]);
            for (int i = 1; i <= totalParametros; i++)
            {
                SYSTEM_PARAMS paramtroSistema = new SYSTEM_PARAMS();
                paramtroSistema.ID_SYSTEM_PARAMS = Convert.ToInt32(Request.Form["id_parametro_" + i]);
                paramtroSistema.VALUE = Request.Form["valor_" + i];
                paramtroSistema.ACTIVE = "S";
                _parametersService.actualizarParametro(paramtroSistema);
            }

            return Json(new { Success = true });
        }
    }
}
