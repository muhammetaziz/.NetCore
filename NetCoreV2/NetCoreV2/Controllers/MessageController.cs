using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NetCoreV2.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        
        Message2Manager mm = new Message2Manager(new EFMessage2Repository());
        public IActionResult Inbox()
        {
            int id = 1;
            var values = mm.GetInboxListByWriter(id);
            return View(values);
        }
        public IActionResult Outbox()
        {
            int id = 1;
            var values = mm.GetInboxListByWriter(id);
            return View(values);
        }
        public IActionResult ReadMessage()
        {
            int id = 1;
            var values = mm.GetInboxListByWriter(id);
            return View(values);
        }
        public IActionResult MessageDetails(int id)
        { 
            var values = mm.TGetById(id);
            ViewBag.sn = "Gonderen";
            return View(values);
        }
    }
}
