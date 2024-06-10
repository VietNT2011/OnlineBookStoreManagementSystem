using AgileBookStore.Areas.Identity.Data;
using AgileBookStore.Data;
using AgileBookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgileBookStore.Controllers
{
    public class WishListController : Controller
    {
		private readonly AgileBookStoreContext _context;
		private readonly UserManager<AgileBookStoreUser> _userManager;

		public WishListController(AgileBookStoreContext context, UserManager<AgileBookStoreUser> userManager)
		{
			_context = context;
			this._userManager = userManager;
		}
		public async Task<IActionResult> WishlistAll()
		{
			var userId = _userManager.GetUserId(this.User);

			var wishlistItems = await _context.Wishlists
				.Where(w => w.IdUser == userId)
				.Include(w => w.Product)
				.ToListAsync();
			var products = wishlistItems.Select(w => w.Product).ToList();

			return View(products);
		}
		[HttpPost]
<<<<<<< Updated upstream
=======
		public async Task<IActionResult> Exist(int productId)
		{
			var product = await _context.Products.FirstOrDefaultAsync(p => p.IdProduct == productId);
			if (product == null)
			{
				return NotFound("Product not found");
			}
			var userId = _userManager.GetUserId(User);

			var wishlistItem = await _context.Wishlists.FirstOrDefaultAsync(w => w.IdUser == userId && w.Product.IdProduct == productId);

			if (wishlistItem != null)
			{
				return Ok("Product in wishlist");
			}
			else
			{
				return Ok("Product not in wishlist");
			}
		}

		[HttpPost]
>>>>>>> Stashed changes
		public async Task<IActionResult> AddToWishlist(int productId)
		{
			var product = await _context.Products.FirstOrDefaultAsync(p => p.IdProduct == productId);
			if (product == null)
			{
				return NotFound("Product not found");
			}
			var userId = _userManager.GetUserId(User);

			var wishlistItem = await _context.Wishlists.FirstOrDefaultAsync(w => w.IdUser == userId && w.Product.IdProduct == productId);

			if (wishlistItem != null)
			{
				return BadRequest("Product already exists in wishlist");
			}

			try
			{
				var currentUser = await _userManager.GetUserAsync(this.User);
				var wishlist = new Wishlist
				{
					User = currentUser, 
					IdUser = userId,
					Product = product
				};

				_context.Wishlists.Add(wishlist);
				await _context.SaveChangesAsync();

				return Ok("Product added to wishlist successfully");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost]
		public async Task<IActionResult> DeleteFromWishlist(int productId)
		{
			var product = await _context.Products.FirstOrDefaultAsync(p => p.IdProduct == productId);
			if (product == null)
			{
				return NotFound("Product not found");
			}

			var userId = _userManager.GetUserId(User);

			var wishlistItem = await _context.Wishlists.FirstOrDefaultAsync(w => w.IdUser == userId && w.Product.IdProduct == productId);
			if (wishlistItem == null)
			{
				return BadRequest("Product does not exist in wishlist");
			}

			try
			{
				_context.Wishlists.Remove(wishlistItem);
				await _context.SaveChangesAsync();

				return Ok("Product removed from wishlist successfully");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

	}
}
