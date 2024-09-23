using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NotificationController : Controller
    {
        NatificationManager nm = new NatificationManager(new EFNatificationRepository());
        public IActionResult AdminNatificationList()
        {
            var value = nm.GetList();
            return View(value);
        }

        [HttpGet]
        public IActionResult AddNotification()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNotification(Natification p)
        {
            p.NatificationStatus =true;
            p.NatificationDate = DateTime.Now;
            p.NotificationTypeSymbol = "mdi mdi-bell";
            p.NatificationColor = "preview-icon bg-primary";
            nm.TUpdate(p);
            return RedirectToAction("AdminNatificationList", "Notification", new { area = "Admin" });
             
        }
         
    }
}
