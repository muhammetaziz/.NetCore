using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        [Area("Admin")]
         public IActionResult Index()
        {
            return View();
        }
    }
}
