using AgileBookStore.Data;
using Microsoft.AspNetCore.Mvc;

namespace AgileBookStore.Components
{
	public class Categorybar : ViewComponent
	{
		private readonly AgileBookStoreContext _Context;
		public Categorybar(AgileBookStoreContext context)
		{
			_Context = context;
		}
		public IViewComponentResult Invoke()
		{
			return View(_Context.Categories.ToList());
		}
	}
}
