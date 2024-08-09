using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.Controllers
{
    public class NotificationController : Controller
    {
        NatificationManager nm=new NatificationManager(new EFNatificationRepository());
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult AllNatification()
        {
            var values = nm.GetList();
            return View(values);
        }

    }
}
