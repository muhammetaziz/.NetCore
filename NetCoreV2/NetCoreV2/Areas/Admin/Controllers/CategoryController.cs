using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager cm=new CategoryManager(new EFCategoryRepository());
        public IActionResult Index()
        {
            var values = cm.GetList(); 
            return View(values);
        }
    }
}
