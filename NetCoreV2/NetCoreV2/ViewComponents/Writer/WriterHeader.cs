using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.ViewComponents.Writer
{
    public class WriterHeader:ViewComponent
    {
        Context c=new Context();
        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.WriterEmail == usermail).Select(y => y.WriterID).FirstOrDefault();

            ViewBag.username=username;
            return View();

        }
    }
}
