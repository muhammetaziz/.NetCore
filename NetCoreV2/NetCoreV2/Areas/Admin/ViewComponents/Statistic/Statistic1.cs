using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        Context c=new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.ToplamBlogSayısı = bm.GetList().Count();
            ViewBag.ToplamMesajSayısı = c.Contacts.Count();
            ViewBag.ToplamYorumSayısı = c.Comments.Count();
            return View();
        }
    }
}
