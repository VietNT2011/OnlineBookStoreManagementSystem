using AgileBookStore.Areas.Identity.Data;
using AgileBookStore.Data;
using AgileBookStore.Models;
using AgileBookStore.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgileBookStore.Controllers
{
	public class ReviewsController : Controller
	{
		private readonly AgileBookStoreContext _context;
		private readonly UserManager<AgileBookStoreUser> _userManager;

		public ReviewsController(AgileBookStoreContext context, UserManager<AgileBookStoreUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> GetReviewStats(int productId)
		{
			var reviewStats = await _context.ReviewComments
				.Include(r => r.Product)
				.Where(r => r.Product.IdProduct == productId)
				.GroupBy(r => r.Product.IdProduct)
				.Select(g => new TotalStarAndReview
				{
					TotalComments = g.Count(),
					AverageStars = g.Average(r => r.star)
				})
				.FirstOrDefaultAsync();
			return Json(reviewStats);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllReviews(int productId)
		{
			var reviews = await _context.ReviewComments.ToListAsync();
			return Json(reviews);
		}

		[HttpGet]
		public async Task<IActionResult> GetReviews(int productId)
		{
			var reviews = await _context.ReviewComments
									.Include(r => r.Product)
									.Where(r => r.Product.IdProduct == productId)
									.ToListAsync();
			reviews.Reverse();
			return Json(reviews);
		}

		[HttpPost]
		public async Task<IActionResult> AddReview(int productId, string review, int rating)
		{
			if (string.IsNullOrEmpty(review) || rating < 0 || rating > 5)
			{
				return BadRequest(new { success = false, message = "Invalid review or rating." });
			}

			var product = await _context.Products.FirstOrDefaultAsync(p => p.IdProduct == productId);
			if (product == null)
			{
				return NotFound(new { success = false, message = "Product not found." });
			}

			var currentUser = await _userManager.GetUserAsync(User);
			if (currentUser == null)
			{
				return Unauthorized(new { success = false, message = "User not authorized." });
			}

			var reviewComment = new ReviewComment
			{
				Product = product,
				UserName = currentUser.UserName,
				email = currentUser.Email,
				Comment = review,
				star = rating
			};

			_context.ReviewComments.Add(reviewComment);
			await _context.SaveChangesAsync();

			return Ok(new { success = true, message = "Review added successfully." });
		}
	}
}
