using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
