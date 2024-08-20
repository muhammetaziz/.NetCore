using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace NetCoreV2.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.ToplamBlogSayısı = bm.GetList().Count();
            ViewBag.ToplamMesajSayısı = c.Contacts.Count();
            ViewBag.ToplamYorumSayısı = c.Comments.Count();
            ViewBag.LastBlog = c.Blogs.OrderByDescending(x => x.BlogID).Select(x => x.BlogTitle).Take(1).FirstOrDefault();
            ViewBag.ToplamYazarSayısı = c.Writers.Count();


            return View();
        }
    }
}




//string api="12ad2aba611dbef9c504b82a127794c5";
//string connection="http://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
//XDocument document = XDocument.Load(connection);

//ViewBag.sıcaklık = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;