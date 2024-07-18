using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.Controllers
{
	public class RegisterController : Controller
	{
		WriterManager wm=new WriterManager(new EFWriterRepository());

		[HttpGet]
		public IActionResult Index()
		{ 
			return View();
		}
		

		[HttpPost]
		public IActionResult Index(Writer p)
		{
			p.WriterStatus=true;
			p.WriterAbout = "Deneme Test";
			wm.WriterAdd(p);
			return RedirectToAction("Index","Blog");
		}
	}
}




//Ekleme işlemi yapılırken HttpGet ile Postun tanımlandıgı ısımlerın aynı olmak zorundadır.
//HttpGet sayfa yuklenince 
//HttpPost sayfada butona tıklanınca calısır