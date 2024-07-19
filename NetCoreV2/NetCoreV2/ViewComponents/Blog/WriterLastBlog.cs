using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.ViewComponents.Blog
{
	public class WriterLastBlog : ViewComponent
	{
		BlogManager bm=new BlogManager(new EFBlogRepository());

		public IViewComponentResult Invoke()
		{
			var values = bm.GetBlogListByWriter(1);
			return View(values);
		}
	}
}
