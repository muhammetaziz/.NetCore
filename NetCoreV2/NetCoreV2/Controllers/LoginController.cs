//using DataAccessLayer.Concrete;
//using EntityLayer.Concrete;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using NetCoreV2.Models;
//using System.Security.Claims;

//namespace NetCoreV2.Controllers
//{
//    [AllowAnonymous]
//    public class LoginController : Controller
//    {
//        private readonly SignInManager<AppUser> _signInManager;

//        public LoginController(SignInManager<AppUser> signInManager)
//        {
//            _signInManager = signInManager;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }


//        [HttpPost]
//        public async Task<IActionResult> Index(UserSignInModel p)
//        {
//            if (ModelState.IsValid)
//            {

//                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);
//                if (result.Succeeded)
//                {
//                    return RedirectToAction("Index", "DashBoard");
//                }
//                else
//                {
//                    return RedirectToAction("Index", "Login");
//                }
//            }
//            return View();
//        }
//        public async Task< IActionResult> LogOut()
//        {
//            await _signInManager.SignOutAsync();
//            return RedirectToAction("Index", "Login");
//        } 
//    }
//}
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCoreV2.Models;
using System.Threading.Tasks;

namespace NetCoreV2.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignInModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);

                if (result.Succeeded)
                {
                    // Giriş yapan kullanıcının bilgilerini al
                    var user = await _userManager.FindByNameAsync(p.username);

                    if (user != null)
                    {
                        // Kullanıcının rollerini al
                        var roles = await _userManager.GetRolesAsync(user);

                        // Eğer kullanıcı "Admin" rolündeyse admin sayfasına yönlendir
                        if (roles.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Widget", new { area = "Admin" });
                        }
                        // Eğer kullanıcı "Writer" rolündeyse yazar sayfasına yönlendir
                        else if (roles.Contains("Writer"))
                        {
                            return RedirectToAction("Index", "DashBoard");
                        }
                        // Diğer roller için farklı yönlendirmeler yapabilirsiniz
                        else
                        {
                            return RedirectToAction("Index", "DashBoard");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Geçersiz giriş denemesi.");
                }
            }
            return View(p);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
