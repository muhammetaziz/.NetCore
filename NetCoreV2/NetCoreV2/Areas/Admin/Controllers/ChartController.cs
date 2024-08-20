using Microsoft.AspNetCore.Mvc;
using NetCoreV2.Areas.Admin.Models;

namespace NetCoreV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();

            list.Add(new CategoryClass { CategoryNamee = "Teknoloji", CategoryCount = 10 });
            list.Add(new CategoryClass { CategoryNamee = "Yazılım", CategoryCount = 21 });
            list.Add(new CategoryClass { CategoryNamee = "Spor", CategoryCount = 4 });

            return Json(new { jsonList = list });
        }
    }
}
