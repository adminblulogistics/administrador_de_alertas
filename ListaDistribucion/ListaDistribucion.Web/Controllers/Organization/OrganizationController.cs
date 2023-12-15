using LD.Entities;
using LD.Entities.Dtos;
using LD.Entities.Enumerations;
using LD.EntitiesLD;
using LD.Services.Interfaces.Alarms;
using LD.Services.Interfaces.Companys;
using LD.Services.Interfaces.Contact;
using LD.Services.Interfaces.Organizations;
using LD.Services.Interfaces.Users;
using ListaDistribucion.Web.Models.Organization;
using Microsoft.AspNetCore.Mvc;

namespace ListaDistribucion.Web.Controllers.Organization
{
    public class OrganizationController : BaseController
    {
        private readonly IUserService _userService;
        private readonly ICompanyService _companyService;
        private readonly IOrganizationService _organizationService;
        private readonly IContactService _contactService;
        private readonly IAlarmService _alarmService;
        public OrganizationController(IUserService userService, ICompanyService companyService, IOrganizationService organizationService, IContactService contactService, IAlarmService alarmService)
        {
            _userService = userService;
            _companyService = companyService;
            _organizationService = organizationService;
            _contactService = contactService;
            _alarmService = alarmService;

        }
        public IActionResult Index()
        {
            int idUsuario = Convert.ToInt32(HttpContext.Session.GetInt32("IdUsuario"));
            int idComerciales = 0;
            int idsalesSupport = 0;
            int idEjecutivos = 0;
            List<ORGANIZATIONDto> listaorganizaciones = new List<ORGANIZATIONDto>();

            listaorganizaciones = _organizationService.obtenerOrganizacionesPorUsuario(idComerciales, idsalesSupport, idEjecutivos, idUsuario);

            var model = new OrganizationModel
            {
                Listaorganizaciones = listaorganizaciones
            };
            return View("~/Views/Organization/ListOrganization.cshtml", model);
        }
        public IActionResult searchOrganization()
        {
            int idCompania = Convert.ToInt32(HttpContext.Session.GetInt32("IdCompania"));
            int idComerciales = Convert.ToInt32(!string.IsNullOrEmpty(Request.Form["comercialId"])? Request.Form["comercialId"].ToString() : 0);
            int idsalesSupport = Convert.ToInt32(!string.IsNullOrEmpty(Request.Form["salesupportId"]) ? Request.Form["salesupportId"].ToString() : 0);
            int idEjecutivos = Convert.ToInt32(!string.IsNullOrEmpty(Request.Form["ejecutivoId"]) ? Request.Form["ejecutivoId"].ToString() : 0);

            int idUsuario = Convert.ToInt32(HttpContext.Session.GetInt32("IdUsuario"));
            string rol = HttpContext.Session.GetString("Rol");


            List<ORGANIZATIONDto> listaorganizaciones = new List<ORGANIZATIONDto>();
            listaorganizaciones = _organizationService.obtenerOrganizacionesPorUsuario(idComerciales, idsalesSupport, idEjecutivos, idUsuario);
            if(!listaorganizaciones.Any())
                listaorganizaciones = new List<ORGANIZATIONDto>();

            OrganizationModel model = new OrganizationModel()
            {
                Listaorganizaciones = listaorganizaciones
            };

            return View("~/Views/Organization/ResultSearchOrganization.cshtml", model);
        }
        public IActionResult ViewOrganization()
        {
            int idOrganization = Convert.ToInt32(Request.Form["idCliente"]);
            ORGANIZATIONDto organizacion = _organizationService.obtenerOrganizacionPorId(idOrganization);

            var model = new OrganizationModel
            {
                Organizacion = organizacion,
            };
            return View("~/Views/Organization/ViewOrganization.cshtml", model);
        }
        public IActionResult ListOrganizationContacts()
        {
            int idOrganization = Convert.ToInt32(Request.Form["idOrganization"]);
            List<CONTACTS> listadoContactos = _contactService.ObtenerContactosPorOrganizacionId(idOrganization);
            ORGANIZATIONDto organizacion = _organizationService.obtenerOrganizacionPorId(idOrganization);
            var model = new OrganizationModel
            {
                Organizacion = organizacion,
                ListadoContactos = listadoContactos,
            };
            return View("~/Views/Organization/ListOrganizationContacts.cshtml", model);
        }

        public IActionResult EditOrganizationContact()
        {
            int idCompania = Convert.ToInt32(HttpContext.Session.GetInt32("IdCompania"));
            long idcontacto = Convert.ToInt64(Request.Form["idContacto"]);
            long idOrganization = Convert.ToInt64(Request.Form["idCustomer"]);

            CONTACTS contacto = new CONTACTS();
            if(idcontacto!=0)
                contacto = _contactService.ObtenerContactoPorId(idcontacto);

            ORGANIZATIONDto organizacion = _organizationService.obtenerOrganizacionPorId(idOrganization);

            OrganizationModel model = new OrganizationModel
            {
                Organizacion = organizacion,
                Contacto = contacto,

            };
            return View("~/Views/Organization/EditOrganizationContact.cshtml", model);
        }
        public JsonResult SaveContact()
        {
            Respuesta respuesta = new Respuesta();
            int id_contacto = Convert.ToInt32(Request.Form["id_contacto"]);
            int id_Organizacion  = Convert.ToInt32(Request.Form["id_Organizacion"]);
            string nombre = Request.Form["nombre"];
            string telefono = Request.Form["telefono"];
            string email = Request.Form["email"];

            respuesta = _organizationService.saveContact(id_contacto, id_Organizacion, nombre, telefono, email);

            return Json(new { success = respuesta.ProcesoExitoso });
        }
        public JsonResult DeteleContact()
        {
            int idContactoOrg = Convert.ToInt32(Request.Form["idContactoOrg"]);
            var  contacto = _contactService.ObtenerContactoPorId(idContactoOrg);
            Respuesta respuesta = new Respuesta();
            respuesta = _contactService.eliminarContacto(contacto);

            return Json(new { success = respuesta.ProcesoExitoso });
        }
        public JsonResult saveOrganization()
        {

            int idOrganization = Convert.ToInt32(Request.Form["idOrganization"]);
            int idComercial = Convert.ToInt32(Request.Form["comercial1Id"]);
            int idSaleSupport = Convert.ToInt32(Request.Form["salesupport1Id"]);
            int idEjecutivo = Convert.ToInt32(Request.Form["ejecutivo1Id"]);

            Respuesta respuesta = new Respuesta();
            respuesta = _organizationService.saveOrganization(idOrganization, idEjecutivo);

            return Json(new { success = respuesta.ProcesoExitoso });
        }
        public IActionResult ListAlarms()
        {

            List<ALARMS> listAlarms = new List<ALARMS>();
            listAlarms = _alarmService.obtenerAlarmas();

            OrganizationModel model = new OrganizationModel()
            {
                ListAlarms = listAlarms
            };

            return View("~/Views/Organization/ContactAlarmsModal.cshtml", model);
        }
        public JsonResult saveContactAlarm()
        {
            int idContactoOrg = Convert.ToInt32(Request.Form["idContactoOrg"]);
            var contacto = _contactService.ObtenerContactoPorId(idContactoOrg);
            Respuesta respuesta = new Respuesta();
            //respuesta = _alarmService.insertAlarma(contacto);

            return Json(new { success = respuesta.ProcesoExitoso });
        }
        public IActionResult UpdateMasivo()
        {
            OrganizationModel model = new OrganizationModel()
            {               
            };
            return View("~/Views/Organization/LoadExcelMasivo.cshtml", model);
        }
        public IActionResult ProcessExcel(IFormFile archivo)
        {
            Respuesta respuesta = new Respuesta();
            List<string> errores = new List<string>();

            if (archivo.Length > 0)
            {
                respuesta = _organizationService.ValidarExcelMasivo(archivo);
            }
            else
            {
                errores.Add("No ha seleccionado ningún archivo");
            }

            var model = new OrganizationModel
            {
                ResultadoArchivoProcesado = respuesta
            };

            return View("~/Views/Organization/ResultProcesarExcelMasivo.cshtml", model);
        }
    }
}
