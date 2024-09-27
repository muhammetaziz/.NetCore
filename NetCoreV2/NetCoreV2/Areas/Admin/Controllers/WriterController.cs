using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetCoreV2.Areas.Admin.Models;
using Newtonsoft.Json;

namespace NetCoreV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    public class WriterController : Controller
    {

        WriterManager wm = new WriterManager(new EFWriterRepository());
        public IActionResult Index()
        {
            var values = wm.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult WriterEdit(int id)
        {
            var writerValue = wm.TGetById(id);  
            return View(writerValue);
        }
        [HttpPost]
        public IActionResult WriterEdit(Writer p)
        { 
            wm.TUpdate(p);
            return RedirectToAction("Index", "Writer", new { area = "Admin" });
        }
        [HttpGet]
        public IActionResult WriterChangeStatus(int id)
        {
            var writer = wm.TGetById(id);
            if (writer == null)
            {
                return NotFound();
            }

            writer.WriterStatus = !writer.WriterStatus; // Durumu değiştir
            wm.TUpdate(writer); // Güncelle

            return RedirectToAction("Index");
        }
        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult WriterList()
        {
            var jsonWriters=JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }


        public static List<WriterClass> writers = new List<WriterClass>()
        {
            new WriterClass() { Id = 1, Name = "test", },
            new WriterClass { Id = 2, Name = "test2", },
            new WriterClass { Id = 3,Name="test3"}
        };

    }
}
