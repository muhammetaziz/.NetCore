using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.ViewComponents.Writer
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EFWriterRepository());
        public IViewComponentResult Invoke()
        {
            var usermail = User.Identity.Name;
            Context c = new Context();
            var writerId = c.Writers.Where(x => x.WriterEmail == usermail).Select(y => y.WriterID).FirstOrDefault();

            var values = writerManager.GetWriterById(writerId);
            return View(values);
        }
    }
}
