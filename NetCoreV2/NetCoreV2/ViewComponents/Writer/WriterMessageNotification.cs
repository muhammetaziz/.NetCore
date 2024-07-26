using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    { 
        public IViewComponentResult Invoke()
        { 
            return View();
        }
    }
}
