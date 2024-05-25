using AgileBookStore.Data;
using AgileBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgileBookStore.Components
{
    public class RelatedProduct : ViewComponent
    {
        private readonly AgileBookStoreContext _context;
        public RelatedProduct(AgileBookStoreContext context)
        {
            _context = context;
        }
		public IViewComponentResult Invoke(List<Category> categories)
		{
			var relatedProducts = _context.Products
				.Include(p => p.Categories)
				.AsEnumerable()
				.Where(product => categories.Any(category => product.Categories.Contains(category)))
				.ToList();

			return View(relatedProducts);
		}
	}
}
