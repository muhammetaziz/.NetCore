using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Office2010.Excel;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NetCoreV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AboutController : Controller
    {
        AboutManager am = new AboutManager(new EFAboutRepository());
        public IActionResult AdminAboutIndex()
        {
            var value = am.GetList();
            return View(value);
        }


        [HttpGet]
        public IActionResult EditAbout(int id)
        {
            var blogValue = am.TGetById(id);  
            return View(blogValue);
        }
        [HttpPost]
        public IActionResult EditAbout(About p)
        {
            p.AboutMapLocation = "Location";
            p.AboutStatus =true;
            
            am.TUpdate(p); 
            return RedirectToAction("AdminAboutIndex", "About", new { area = "Admin" });
        }


    }
}
