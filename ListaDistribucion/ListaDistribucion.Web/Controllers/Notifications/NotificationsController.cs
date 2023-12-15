using LD.Services.Interfaces.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace ListaDistribucion.Web.Controllers.Notifications
{
    public class NotificationsController : BaseController
    {
        private readonly INotificationsService _notificationsService;
        public NotificationsController(INotificationsService notificationsService)
        {
            _notificationsService = notificationsService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> NotificationAlarms()
        {
            var response = await _notificationsService.Notifications();
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
