using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace NetCoreV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        public IActionResult Index()
        {
            var values = cm.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {

            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(p);
            if (results.IsValid)
            {
                cm.TAdd(p);
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        // public IActionResult CategoryDelete(int id)
        //{
             
        //    var categoryValue = cm.TGetById(id);  
        //    cm.TDelete(categoryValue);
        //    return RedirectToAction("Index", "Category", new { area = "Admin" });

        //}


        [HttpGet]
        public IActionResult CategoryEdit(int id)
        {
            var blogValue = cm.TGetById(id);
            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()

                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View(blogValue);
        }
        [HttpPost]
        public IActionResult CategoryEdit(Category p)
        {          
            
            cm.TUpdate(p);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }
    }
}
