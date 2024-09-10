using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCoreV2.Models;

namespace NetCoreV2.Controllers
{
    [AllowAnonymous]
    public class RegisterUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        //RegisterGetIndex
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //RegisterPostIndex
        [HttpPost]
        public async Task<IActionResult> Index(UserSignUpViewModel p)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    Email = p.Mail,
                    UserName = p.UserName,
                    NameSurname = p.nameSurname,
                    ImageUrl="ımageUrl",
                };
                var result=await _userManager.CreateAsync(user,p.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Login");

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);

                    }
                }
            }
            return View(p);
        }
    }
}
