using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EFWriterRepository());
        Context c = new Context();
        

        
        public IViewComponentResult Invoke()
        { 
            var username = User.Identity.Name;
            ViewBag.UserName = username; 

            var usermail=c.Users.Where(x=>x.UserName==username).Select(y=>y.Email).FirstOrDefault();
            ViewBag.UserMail=usermail;

            var writerId = c.Writers.Where(x => x.WriterEmail == username).Select(y => y.WriterID).FirstOrDefault(); 
            var values = writerManager.GetWriterById(writerId);
            return View(values);
        }
    }
}
