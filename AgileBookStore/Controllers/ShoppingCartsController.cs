using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgileBookStore.Data;
using AgileBookStore.Models;
using AgileBookStore.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using AgileBookStore.Models.ViewModels;
using System.Security.Claims;
using System.Reflection.Metadata.Ecma335;

namespace AgileBookStore.Controllers
{
	public class ShoppingCartsController : Controller
	{
		private readonly AgileBookStoreContext _Context;
		private readonly UserManager<AgileBookStoreUser> _userManager;
		public ShoppingCartsController(AgileBookStoreContext context, UserManager<AgileBookStoreUser> userManager)
		{
			_Context = context;
			this._userManager = userManager;
		}
		// GET: ShoppingCarts
		public IActionResult Index()
		{
			var user = HttpContext.User;
			if (user.Identity.IsAuthenticated)
			{
				var claimsPrincipal = user as ClaimsPrincipal;
				if (claimsPrincipal != null)
				{
					var currentUserId = _userManager.GetUserId(claimsPrincipal);
					var shoppingCartItems = _Context.ShoppingCarts
						.Where(cart => cart.Id == currentUserId)
						.Include(cart => cart.Product)
						.ToList();
                    shoppingCartItems.Reverse();
					return View(shoppingCartItems);
				}
			}
			return View(new List<ShoppingCart>());
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			var shoppingCartItem = await _Context.ShoppingCarts.FindAsync(id);
			if (shoppingCartItem == null)
			{
				return NotFound();
			}

			_Context.ShoppingCarts.Remove(shoppingCartItem);
			await _Context.SaveChangesAsync();

			return Ok();
		}
		[HttpPost]
		public async Task<IActionResult> Update(int id, int quantity)
		{
			var shoppingCartItem = await _Context.ShoppingCarts.FindAsync(id);

			if (shoppingCartItem == null)
			{
				return NotFound(); 
			}
			if(quantity == 0)
			{
                _Context.ShoppingCarts.Remove(shoppingCartItem);
            }
            shoppingCartItem.Quantity = quantity;
            await _Context.SaveChangesAsync();
			return Ok();
		}


        [HttpPost]
        public IActionResult DeleteAll()
        {
            var user = HttpContext.User;
            if (user.Identity.IsAuthenticated)
            {
                var claimsPrincipal = user as ClaimsPrincipal;
                if (claimsPrincipal != null)
                {
                    var currentUserId = _userManager.GetUserId(claimsPrincipal);

                    var shoppingCartItems = _Context.ShoppingCarts
                        .Where(cart => cart.Id == currentUserId)
                        .ToList();

                    if (shoppingCartItems.Any())
                    {
                        _Context.ShoppingCarts.RemoveRange(shoppingCartItems);
                        _Context.SaveChanges();

                        return Ok(); 
                    }
                    return NotFound(); 
                }
            }

            return Unauthorized(); 
        }


        public IActionResult PreCheckOut()
        {
            var user = HttpContext.User;
            if (user.Identity.IsAuthenticated)
            {
                var claimsPrincipal = user as ClaimsPrincipal;
                if (claimsPrincipal != null)
                {
                    var currentUserId = _userManager.GetUserId(claimsPrincipal);
                    var shoppingCartItems = _Context.ShoppingCarts
                        .Where(cart => cart.Id == currentUserId)
                        .Include(cart => cart.Product)
                        .ToList();
                    shoppingCartItems.Reverse();
                    return View(shoppingCartItems);
                }
            }
            return View(new List<ShoppingCart>());
        }

        public async Task<IActionResult> AddOrder()
        {
            var user = HttpContext.User;
            if (user.Identity.IsAuthenticated)
            {
                var claimsPrincipal = user as ClaimsPrincipal;
                if (claimsPrincipal != null)
                {
                    var currentUserId = _userManager.GetUserId(claimsPrincipal);
                    var shoppingCartItems = _Context.ShoppingCarts
                        .Where(cart => cart.Id == currentUserId)
                        .ToList();
                    if (shoppingCartItems != null && shoppingCartItems.Count > 0)
                    {
                        shoppingCartItems.Reverse();
                        var newOrder = new Order
                        {
                            Id = currentUserId,
                            ShoppingCarts = shoppingCartItems
                        };
                        _Context.Orders.Add(newOrder);
                        await _Context.SaveChangesAsync();
                        return Ok(new { OrderId = newOrder.OrderId });
                    }
                    return BadRequest("No items in the shopping cart.");
                }
            }
            return Unauthorized();
        }
<<<<<<< Updated upstream
    }
=======
		public IActionResult RefeshQuickCart()
		{
			var user = HttpContext.User;
			if (user.Identity.IsAuthenticated)
			{
				var claimsPrincipal = user as ClaimsPrincipal;
				if (claimsPrincipal != null)
				{
					var currentUserId = _userManager.GetUserId(claimsPrincipal);
					var shoppingCartItems = _Context.ShoppingCarts
						.Where(cart => cart.Id == currentUserId)
						.ToList();
					var shoppingCartViewModels = new List<ShoppingCartViewModel>();

					foreach (var cartItem in shoppingCartItems)
					{
						var product = _Context.Products.FirstOrDefault(p => p.IdProduct == cartItem.IdProduct);

						if (product != null)
						{
							var shoppingCartViewModel = new ShoppingCartViewModel
							{
								Product = product,
								Quantity = cartItem.Quantity
							};

							shoppingCartViewModels.Add(shoppingCartViewModel);
						}
					}
					shoppingCartViewModels.Reverse();
					return Json(shoppingCartViewModels);
				}
			}

			return Json(new List<ShoppingCartViewModel>());
		}
	}
>>>>>>> Stashed changes
}
