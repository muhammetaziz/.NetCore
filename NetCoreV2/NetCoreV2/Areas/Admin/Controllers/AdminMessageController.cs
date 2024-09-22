
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        Context c =new Context();
        Message2Manager mm = new Message2Manager(new EFMessage2Repository());
        public IActionResult Inbox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.WriterEmail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.GetInboxListByWriter(writerId);
            ViewBag.Mail = usermail.ToLower();
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
            ViewBag.SenderName = c.Message2s.Where(x => x.MessageSenderID == writerId).Select(y => y.ReciverUser.WriterName).FirstOrDefault();
            return View(values);
        }
        public IActionResult MessageStatusChange(int id)
        {
            var messageValue = mm.TGetById(id);
            messageValue.MessageStatus = false;
            mm.TUpdate(messageValue);
            return RedirectToAction("Inbox", "AdminMessage", new { area = "Admin" });
        }
    }
}
