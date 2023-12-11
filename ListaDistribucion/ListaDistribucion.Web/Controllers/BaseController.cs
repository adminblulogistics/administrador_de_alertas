using Microsoft.AspNetCore.Mvc;

namespace ListaDistribucion.Web.Controllers
{
    public class BaseController : Controller
    {
        public virtual ActionResult ActualizarSession()
        {
            //La session se actualiza por medio del FiltroSessionExpira //Validar
            var timeOutSession = Convert.ToInt64(AppDomain.CurrentDomain.GetData("TimeOutSession"));
            var fechaActual = DateTime.Now.AddMinutes(timeOutSession).ToString("yyyy-MM-dd HH:mm:ss");
            HttpContext.Session.SetString("ExpireSession", fechaActual);
            DateTime expiresSession = Convert.ToDateTime(fechaActual);
            return Json(new { Success = true, anio = expiresSession.Year, mes = expiresSession.Month, dia = expiresSession.Day, hora = expiresSession.Hour, minutos = expiresSession.Minute, segundos = expiresSession.Second });
        }
    }
}
