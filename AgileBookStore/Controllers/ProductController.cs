using AgileBookStore.Areas.Identity.Data;
using AgileBookStore.Data;
using AgileBookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using X.PagedList;

namespace AgileBookStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly AgileBookStoreContext _context;
		private readonly UserManager<AgileBookStoreUser> _userManager;

		public ProductController(AgileBookStoreContext context, UserManager<AgileBookStoreUser> userManager)
        {
            _context = context;
			this._userManager = userManager;
		}


		public async Task<IActionResult> ProductAllAsync(int? page)
		{
			int pageSize = 16;

			List<Product> products = await _context.Products.ToListAsync();

			Random rng = new Random();
			products = products.OrderBy(x => rng.Next()).ToList();

			int pageNumber = page ?? 1; 
			IPagedList<Product> pagedList = products.ToPagedList(pageNumber, pageSize);

			return View(pagedList);
		}


		public IActionResult ProductDetail(int id)
		{
			var product = _context.Products
								  .Include(p => p.Categories)  // Include the related categories
								  .FirstOrDefault(p => p.IdProduct == id);

			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}

		public async Task<IActionResult> ProductByCategory(int categoryId, int? page)
        {
            int pageSize = 16;

            var products = await _context.Products
                .Where(p => p.Categories.Any(c => c.Id == categoryId))
                .ToListAsync();

            int pageNumber = page ?? 1;
            var pagedList = products.ToPagedList(pageNumber, pageSize);

            return View("ProductAll", pagedList);
        }

		public async Task<IActionResult> Search(string searchTerm, int? page)
		{
			if (string.IsNullOrEmpty(searchTerm))
			{
				return RedirectToAction(nameof(ProductAllAsync));
			}

			int pageSize = 16;

			var products = await _context.Products
				.Where(p => p.NameProduct.Contains(searchTerm) || p.Author.Contains(searchTerm))
				.ToListAsync();

			int pageNumber = page ?? 1;
			var pagedList = products.ToPagedList(pageNumber, pageSize);

			return View("ProductAll", pagedList);
		}

		[HttpPost]
		public async Task <IActionResult> AddToCart([FromBody] ShoppingCart item)
		{
			var shoppingCartCheck = _context.ShoppingCarts
				.SingleOrDefault(c => c.Id == _userManager.GetUserId(this.User) && c.IdProduct == item.IdProduct);
			if (shoppingCartCheck == null)
			{
				var product = _context.Products.Find(item.IdProduct);
				var currentUser = await _userManager.GetUserAsync(this.User);

				var shopcart = new ShoppingCart
				{
					Product = product,
					IdProduct = item.IdProduct,
					Id = _userManager.GetUserId(this.User),
					User = currentUser,
					Quantity = item.Quantity,
				};
				_context.ShoppingCarts.Add(shopcart);
				_context.SaveChanges();
			}
			else
			{
				shoppingCartCheck.Quantity += item.Quantity;
				_context.SaveChanges();
			}
			return Ok(); 
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
