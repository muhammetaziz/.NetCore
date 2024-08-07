using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        NatificationManager nm = new NatificationManager(new EFNatificationRepository());
        public IViewComponentResult Invoke()
        {

            var values = nm.GetList();
            return View(values);

        }
    }
}
