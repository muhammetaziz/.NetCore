using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.ViewComponents.Comment
{
    public class CommentListByBlog : ViewComponent
    {
        CommentManager cm=new CommentManager(new EFCommentRepository());
        public IViewComponentResult Invoke()
        {
            var values = cm.GetList(2);
            return View(values);
        }
    }
}
