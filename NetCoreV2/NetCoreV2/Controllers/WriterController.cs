﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCoreV2.Models;



namespace NetCoreV2.Controllers
{
    [AllowAnonymous]

    public class WriterController : Controller
    {
        Context c = new Context();
        WriterManager wm = new WriterManager(new EFWriterRepository()); 
        private readonly UserManager<AppUser> _userManager; 
        public WriterController(UserManager<AppUser> userManager)
        {
            this._userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.v = usermail; 
            var writerName = c.Writers.Where(x => x.WriterEmail == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v2 = writerName;
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }

         

         
        public PartialViewResult WriterNavbarPartial1()
        {
            return PartialView();
        }

         
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }


        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.email = values.Email;
            model.namesurname = values.NameSurname;
            model.ımageurl = values.ImageUrl;
            model.username = values.UserName;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
              
            values.NameSurname = model.namesurname;
            values.UserName = model.username;
            values.Email = model.email;
            values.ImageUrl = model.ımageurl;
            values.PasswordHash=_userManager.PasswordHasher.HashPassword(values,model.password);
            var result = await _userManager.UpdateAsync(values);

            return RedirectToAction("Index", "Dashboard");


            //WriterValidator wl = new WriterValidator();
            //ValidationResult results = wl.Validate(p);
            //if (results.IsValid)
            //{
            //    wm.TUpdate(p);
            //    return RedirectToAction("Index", "Dashboard");

            //}
            //else
            //{
            //    foreach (var item in results.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}

            //return View();
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

        

        public IActionResult WriterProfileCard()
        {
            var username = User.Identity.Name.ToUpper();
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.WriterEmail == usermail).Select(y => y.WriterID).FirstOrDefault(); 
            var writerImage = c.Writers.Where(x => x.WriterEmail == usermail).Select(y => y.WriterImage).FirstOrDefault(); 
            var writerStatus = c.Writers.Where(x => x.WriterEmail == usermail).Select(y => y.WriterStatus).FirstOrDefault(); 
            var writerAbout = c.Writers.Where(x => x.WriterEmail == usermail).Select(y => y.WriterAbout).FirstOrDefault(); 


            ViewBag.WriterStatus = writerStatus;
            ViewBag.WriterImage = writerImage;
            ViewBag.WriterName = username;
            ViewBag.WriterEmail=usermail;
            ViewBag.WriterAbout= writerAbout;
            ViewBag.WriterId= writerId;
            
             

            return View();
        }

        
    }
}
