using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2:ViewComponent
    {
        Context c =new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.AdminAdı = c.Admins.Where(x => x.AdminID == 1).Select(y => y.Name).FirstOrDefault();
            ViewBag.Resim= c.Admins.Where(x => x.AdminID == 1).Select(y => y.ImageUrl).FirstOrDefault(); 
            ViewBag.Desc= c.Admins.Where(x => x.AdminID == 1).Select(y => y.ShortDesc).FirstOrDefault(); 
            return View();
        }
    }
}
