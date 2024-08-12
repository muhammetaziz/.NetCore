using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreV2.Models;



namespace NetCoreV2.Controllers
{
    [AllowAnonymous]
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EFWriterRepository());

        [Authorize]
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
            Context c = new Context();
            var writerName = c.Writers.Where(x => x.WriterEmail == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v2 = writerName;
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial1()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var usermail = User.Identity.Name; 
            Context c = new Context();
            var writerId = c.Writers.Where(x => x.WriterEmail == usermail).Select(y => y.WriterID).FirstOrDefault();


            var writerValues = wm.TGetById(writerId);
            return View(writerValues);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterEditProfile(Writer p)
        {
            WriterValidator wl = new WriterValidator();
            ValidationResult results = wl.Validate(p);
            if (results.IsValid)
            {
                wm.TUpdate(p);
                return RedirectToAction("Index", "Dashboard");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w = new Writer();
            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimagename;
            }
            w.WriterStatus = p.WriterStatus;
            w.WriterName = p.WriterName;
            w.WriterEmail = p.WriterEmail;
            w.WriterPassword = p.WriterPassword;
            w.WriterAbout = p.WriterAbout;

            wm.TUpdate(w);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
