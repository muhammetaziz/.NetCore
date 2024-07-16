using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.Controllers
{
	public class CommentController : Controller
	{
		CommentManager cm=new CommentManager(new EFCommentRepository());
		public IActionResult Index()
		{
			return View();
		}
		public PartialViewResult PartialAddComment()
		{
			return PartialView();
		}
		public PartialViewResult CommentListByBlog(int id)
		{
			var values = cm.GetList(id); 
			return PartialView(values);
		}
	}
}
