using Microsoft.AspNetCore.Mvc;

namespace AgileBookStore.Controllers
{
	public class ContactController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
