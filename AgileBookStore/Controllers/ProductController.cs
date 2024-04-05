using AgileBookStore.Data;
using AgileBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using X.PagedList;

namespace AgileBookStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly AgileBookStoreContext _context;
        public ProductController(AgileBookStoreContext context)
        {
            _context = context;
        }

		public async Task<IActionResult> ProductAllAsync(int? page)
		{
			int pageSize = 16; 
			
			List<Product> products = await _context.Products.ToListAsync();

			
			//int totalProducts = products.Count; 
			//int totalPages = (int)Math.Ceiling((double)totalProducts / pageSize); 

			int pageNumber = page ?? 1; 
			IPagedList<Product> pagedList = products.ToPagedList(pageNumber, pageSize);

			return View(pagedList);
		}
		public IActionResult ProductDetail(int id)
		{
			
			var product = _context.Products.FirstOrDefault(p => p.IdProduct == id);
			if (product == null)
			{
				return NotFound(); 
			}
			return View(product);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
