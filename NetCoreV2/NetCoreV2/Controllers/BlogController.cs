using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
