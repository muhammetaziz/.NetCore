using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Authorize(Roles = "Admin,Moderator")]
    public class NewsLetter : Controller
    {
            NewsLetterManager nlm=new NewsLetterManager(new EFNewsLetterRepository());
        public IActionResult NewsLetterList()
        {
            var value = nlm.GetList();
            return View(value);
        }

        [HttpGet]
        public IActionResult NewsChangeStatus(int id)
        {
            var Abone = nlm.TGetById(id);
            if (Abone == null)
            {
                return NotFound();
            }

            Abone.MailStatus = !Abone.MailStatus; // Durumu değiştir
            nlm.TUpdate(Abone); // Güncelle

            return RedirectToAction("NewsLetterList");
        }
    }
}
