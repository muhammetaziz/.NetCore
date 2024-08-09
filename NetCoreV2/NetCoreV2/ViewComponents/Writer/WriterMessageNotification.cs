using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    { 
        MessageManager mm=new MessageManager(new EFMessageRepository());
        public IViewComponentResult Invoke()
        {
            string p;
            p="m.aziz.aciker@gmail.com";
            var values = mm.GetInboxListByWriter(p);
            return View(values);
        }
    }
}
