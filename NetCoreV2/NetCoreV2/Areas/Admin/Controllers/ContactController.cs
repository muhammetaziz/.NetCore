using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.Areas.Admin.Controllers
{

    [Area("Admin")]

    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactRepository());
        public IActionResult Index()
        {
            var values = cm.GetList();
            return View(values);
        }
        public IActionResult ContactDetails(int id)
        {
            ViewBag.i = id;
            var values = cm.GetBlogById(id);
            return View(values);
        }

        public IActionResult ContactDelete(int id)
        {
            var contactValue = cm.TGetById(id);
            cm.TDelete(contactValue);
            return RedirectToAction("Index", "Contact", new { area = "Admin" });
        }

    }
}
