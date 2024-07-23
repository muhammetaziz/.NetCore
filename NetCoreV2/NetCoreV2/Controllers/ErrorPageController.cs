using Microsoft.AspNetCore.Mvc;

namespace NetCoreV2.Controllers
{
	public class ErrorPageController : Controller
	{
		public IActionResult Error1(int code)
		{

			return View();
		}
	}
}
