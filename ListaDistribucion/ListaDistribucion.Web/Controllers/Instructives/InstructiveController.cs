using LD.Entities;
using LD.EntitiesLD;
using LD.Services.Interfaces.Companys;
using LD.Services.Interfaces.Instructives;
using ListaDistribucion.Web.Models.Instructive;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace ListaDistribucion.Web.Controllers.Instructives
{
    public class InstructiveController : BaseController
    {
        private readonly IInstructiveService _instructiveService;
        private readonly ICompanyService _companyService;
        public InstructiveController(IInstructiveService instructiveService, ICompanyService companyService)
        {
            _instructiveService = instructiveService;
            _companyService = companyService;
        }
        public IActionResult Index()
        {
            List<INSTRUCTIVE> instructivos = _instructiveService.obtenerInstructivos();

            InstructiveModel model = new InstructiveModel()
            {
                ListadoInstructivos = instructivos,
            };

            return View("~/Views/Instructive/SearchInstructive.cshtml", model);
        }

        public IActionResult searchInstructives()
        {
            int? idInstructivo = null;
            if (!string.IsNullOrEmpty(Request.Form["id_instructive"]))
                idInstructivo = Convert.ToInt32(Request.Form["id_instructive"]);

            string tema = Request.Form["tema"];
            string descripcion = Request.Form["descripcion"];
            string roles = Request.Form["roles"];
            string compania = Request.Form["compania"];

            bool? estado = null;
            if (!string.IsNullOrEmpty(Request.Form["instructive_estado"]))
                estado = Convert.ToBoolean(Request.Form["instructive_estado"]);

            List<INSTRUCTIVE> instructivos = _instructiveService.obtenerInstructivos(idInstructivo, tema, descripcion, compania, roles, estado);

            InstructiveModel model = new InstructiveModel()
            {
                ListadoInstructivos = instructivos,
            };

            return View("~/Views/Instructive/ListInstructives.cshtml", model);
        }
        public IActionResult editInstructive()
        {
            INSTRUCTIVE instructive = new INSTRUCTIVE();

            int idInstructive = Convert.ToInt32(Request.Form["idInstructive"]);

            if (idInstructive != 0)
            {
                instructive = _instructiveService.obtenerInstructivoPorId(idInstructive);
            }

            List<COMPANIES> listCompanias = _companyService.obtenerCompanias();

            InstructiveModel model = new InstructiveModel()
            {
                instructivo = instructive,
                ListadoCompanies = listCompanias
            };

            return View("~/Views/Instructive/editInstructive.cshtml", model);
        }
        public JsonResult saveInstructive(List<IFormFile> documentos)
        {
            Respuesta respuesta = new Respuesta();
            int idInstructivo = Convert.ToInt32(Request.Form["instructivo_id"]);
            string tema = Request.Form["tema"];
            string descripcion = Request.Form["descripcion"];
            string companias = Request.Form["list_companias"];
            string roles = Request.Form["list_roles"];
            string fileInstructive = string.Empty;
            bool status = Convert.ToBoolean(Request.Form["instructivo_estado"]);
            if (idInstructivo != 0 && string.IsNullOrEmpty(fileInstructive))
            {
                fileInstructive = Request.Form["ATTACHED"];
            }

            respuesta = _instructiveService.saveInstructive(documentos, idInstructivo, tema, descripcion, companias, roles, fileInstructive, status);

            return Json(new { success = true });
        }

        public ActionResult VerArchivo()
        {
            int idInstructivo = Convert.ToInt32(Request.Query["id_instructive"]);
            int item = Convert.ToInt32(Request.Query["item"]);

            var resp = _instructiveService.VerArchivo(idInstructivo, item);

            string contentType = "application/octet-stream"; // <--- Si es PDF o imágenes abrir en explorador. 

            FileContentResult respuesta = new FileContentResult(resp.Item1, contentType);

            respuesta.FileDownloadName = resp.Item2;// nombreArchivo;

            return respuesta;
        }
        public IActionResult EliminarArchivo()
        {
            Respuesta respuesta = new Respuesta();
            string rol = HttpContext.Session.GetString("Rol");
            int idInstructivo = Convert.ToInt32(Request.Form["id_instructive"]);
            int idUsuario = Convert.ToInt32(HttpContext.Session.GetInt32("IdUsuario"));
            int item = Convert.ToInt32(Request.Query["item"]);

            respuesta = _instructiveService.EliminarArchivo(idInstructivo, item);

            return Json(new { success = true, msjcorreo = respuesta.MensajeRespuesta });
        }
        //Consulta de registros por rol en el modulo de "Consultas"
        public IActionResult InstructiveSearch()
        {
            string rol = HttpContext.Session.GetString("Rol");
            int idCompania = (int)HttpContext.Session.GetInt32("IdCompania");
            string compania = _companyService.obtenerCompaniasPorId(idCompania).NAME;

            int? idInstructivo = null;
            if (!string.IsNullOrEmpty(Request.Form["id_instructive"]))
                idInstructivo = Convert.ToInt32(Request.Form["id_instructive"]);


            string tema = "";
            if (!string.IsNullOrEmpty(Request.Form["tema"]))
                tema = Request.Form["tema"];


            string descripcion = "";
            if (!string.IsNullOrEmpty(Request.Form["descripcion"]))
                descripcion = Request.Form["descripcion"];

            List<INSTRUCTIVE> instructivos = _instructiveService.obtenerInstructivos(idInstructivo, tema, descripcion, compania, rol, true);

            InstructiveModel model = new InstructiveModel()
            {
                ListadoInstructivos = instructivos.OrderBy(x => x.TOPIC).ToList(),
            };

            int? typeSearch = null;
            if (!string.IsNullOrEmpty(Request.Form["typeSearch"]))
                typeSearch = Convert.ToInt32(Request.Form["typeSearch"]);

            if (typeSearch == 1)
                return View("~/Views/Instructive/InstructiveList.cshtml", model);
            else
                return View("~/Views/Instructive/InstructiveSearch.cshtml", model);

        }
    }
}
