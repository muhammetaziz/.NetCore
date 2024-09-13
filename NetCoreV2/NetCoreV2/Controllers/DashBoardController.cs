using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            Context c=new Context();

            var username = User.Identity.Name; 
            var usermail=c.Users.Where(x=>x.UserName==username).Select(y=>y.Email).FirstOrDefault();

            var writerId=c.Writers.Where(x=>x.WriterEmail==usermail).Select(y=>y.WriterID).FirstOrDefault();

            ViewBag.v1=c.Blogs.Count().ToString();
            ViewBag.v2=c.Blogs.Where(x=>x.WriterID==writerId).Count();
            ViewBag.v3=c.Categories.Count();
            return View();
        }

    }
}
