using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Index(Writer p)
        {
            Context c = new Context();

            var dataValue = c.Writers.FirstOrDefault(x => x.WriterEmail == p.WriterEmail && x.WriterPassword == p.WriterPassword);
            if (dataValue != null)
            {
                HttpContext.Session.SetString("UserName", p.WriterEmail);
                return RedirectToAction("Index", "Writer");
            }
            else
            {
                return View();
            }

        }
    }
}
