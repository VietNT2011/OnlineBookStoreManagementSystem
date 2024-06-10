using Microsoft.AspNetCore.Mvc;

namespace AgileBookStore.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
