using Microsoft.AspNetCore.Mvc;

namespace ListaDistribucion.Web.Controllers.Excel
{
    public class ExcelController : Controller
    {
        public IActionResult ExportarExcel()
        {

            ViewBag.DataExcel = Request.Form["__dataExcel"];
            ViewBag.TituloReporte = Request.Form["__tituloReporte"];

            HttpContext.Response.Headers.Add("Content-Disposition", "Attachment;filename=reporte.xls");
            HttpContext.Response.ContentType = "application/vnd.ms-excel";

            return View("~/Views/Excel/ExporterExcel.cshtml");
        }

        public IActionResult ExportarExcelFromDiv()
        {
            ViewBag.DataExcel = Request.Form["__dataExcel"];
            ViewBag.TituloReporte = Request.Form["__tituloReporte"];
            HttpContext.Response.Headers.Add("Content-Disposition", "Attachment;filename=reporte.xls");
            HttpContext.Response.ContentType = "application/vnd.ms-excel";

            return View("~/Views/Excel/ExporterExcel.cshtml");
        }
    }
}
