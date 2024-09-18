using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
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

        Context c = new Context();
        Message2Manager mm = new Message2Manager(new EFMessage2Repository());
        public IActionResult Inbox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.WriterEmail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.GetInboxListByWriter(writerId);
            return View(values);
        }
        public IActionResult Outbox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.WriterEmail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.GetSendBoxListByWriter(writerId);
            //var recivingMesage=mm.GetList().Where(x=>x.MessageSenderID==writerId).ToList();
            return View(values);
        }
        public IActionResult ReadMessage()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.WriterEmail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.GetInboxListByWriter(writerId);
            return View(values);
        }
        public IActionResult MessageDetails(int id)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.WriterEmail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.TGetById(id);
            ViewBag.SenderName = c.Message2s.Where(x => x.MessageReciverID == writerId).Select(y => y.SenderUser.WriterName).FirstOrDefault();
            return View(values);
        }

        public IActionResult MessageDetails2(int id)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.WriterEmail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.TGetById(id);
            ViewBag.ReciverName = c.Message2s.Where(x => x.MessageSenderID == writerId).Select(y => y.ReciverUser.WriterName).FirstOrDefault();
            return View(values);
        }


        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message2 p)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.WriterEmail == usermail).Select(y => y.WriterID).FirstOrDefault();   
            
            p.MessageSenderID= writerId;
            //p.MessageReciverID = 2;
            p.MessageStatus=true;
            p.MessageDate= DateTime.Now;
            mm.TAdd(p);

            return RedirectToAction("Inbox");
        }
    }
}
