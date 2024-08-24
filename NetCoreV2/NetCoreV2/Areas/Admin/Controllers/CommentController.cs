using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        CommentManager cm=new CommentManager(new EFCommentRepository());
        public IActionResult AdminCommentList()
        {
            var value = cm.GetList();
            return View(value);
        }

        [HttpGet]
        public IActionResult CommentChangeStatus(int id)
        {
            var Abone = cm.TGetById(id);
            if (Abone == null)
            {
                return NotFound();
            }

            Abone.CommentStatus = !Abone.CommentStatus; // Durumu değiştir
            cm.TUpdate(Abone); // Güncelle

            return RedirectToAction("AdminCommentList");
        }
    }
}
