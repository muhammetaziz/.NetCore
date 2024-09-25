using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCoreV2.Models;

namespace NetCoreV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminRoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public AdminRoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> AddRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppRole role = new AppRole()
                {
                    Name = model.Name,
                };
                var result=await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            
            return View(model);
        }

        [HttpGet]
        public ActionResult EditRole(int id)
        {
            var values=_roleManager.Roles.FirstOrDefault(x=>x.Id == id);
            RoleUpdateViewModel model = new RoleUpdateViewModel
            {
                ID = values.Id,
                Name = values.Name
            };

            return View(model);
        }

        [HttpPost]
        public  async Task<IActionResult> EditRole(RoleUpdateViewModel model)
        {

            var values=_roleManager.Roles.Where(x=>x.Id==model.ID).FirstOrDefault();
           
            values.Name= model.Name;
            var  result=await _roleManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public async Task<IActionResult> DeleteRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result=await _roleManager.DeleteAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");

            }
            return View();
        }
    }
}
