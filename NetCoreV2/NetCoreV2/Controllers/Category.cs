using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.Controllers
{
    public class Category : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
