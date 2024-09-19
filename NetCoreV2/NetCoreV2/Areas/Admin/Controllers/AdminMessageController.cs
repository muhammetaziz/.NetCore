
using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.Areas.Admin.Controllers
{
    public class AdminMessageController : Controller
    {
        public IActionResult Inbox()
        {
            return View();
        }
    }
}
