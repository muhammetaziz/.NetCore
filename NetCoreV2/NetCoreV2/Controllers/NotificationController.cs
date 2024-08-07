using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
