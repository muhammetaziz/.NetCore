using Microsoft.AspNetCore.Mvc;
using NetCoreV2.Models;

namespace NetCoreV2.ViewComponents
{
	public class CommentList : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var values = new List<UserComment>()
			{
				new UserComment{
					userID = 1,
					UserName = "Test",
				},
				new UserComment
				{
					userID = 2,
					UserName = "Test2",
				},
				new UserComment
				{
					userID=3,
					UserName="Test3",
				}
			};
			return View(values);
		}
	}
}
