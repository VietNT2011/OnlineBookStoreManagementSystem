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
						.ToList();
					var shoppingCartViewModels = new List<ShoppingCartViewModel>();

					foreach (var cartItem in shoppingCartItems)
					{
						// Truy vấn thông tin sản phẩm tương ứng với từng cartItem
						var product = _Context.Products.FirstOrDefault(p => p.IdProduct == cartItem.IdProduct);

						if (product != null)
						{
							var shoppingCartViewModel = new ShoppingCartViewModel
							{
								IdShoppingCart = cartItem.IdShoppingCart,
								Product = product,
								Quantity = cartItem.Quantity
							};

							shoppingCartViewModels.Add(shoppingCartViewModel);
						}
					}
					shoppingCartViewModels.Reverse();
					return View(shoppingCartViewModels);
				}
			}
			return View(new List<ShoppingCartViewModel>());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(int id)
		{
			var shoppingCartItem = await _Context.ShoppingCarts.FindAsync(id);
			if (shoppingCartItem == null)
			{
				return NotFound();
			}

			_Context.ShoppingCarts.Remove(shoppingCartItem);
			await _Context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(int id, int quantity)
		{
			var shoppingCartItem = await _Context.ShoppingCarts.FindAsync(id);

			if (shoppingCartItem == null)
			{
				return NotFound(); 
			}

			shoppingCartItem.Quantity = quantity;
			await _Context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		public IActionResult CheckOut()
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
						// Truy vấn thông tin sản phẩm tương ứng với từng cartItem
						var product = _Context.Products.FirstOrDefault(p => p.IdProduct == cartItem.IdProduct);

						if (product != null)
						{
							var shoppingCartViewModel = new ShoppingCartViewModel
							{
								IdShoppingCart = cartItem.IdShoppingCart,
								Product = product,
								Quantity = cartItem.Quantity
							};

							shoppingCartViewModels.Add(shoppingCartViewModel);
						}
					}
					shoppingCartViewModels.Reverse();
					return View(shoppingCartViewModels);
				}
			}
			return View(new List<ShoppingCartViewModel>());
		}
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

                   
                    _Context.ShoppingCarts.RemoveRange(shoppingCartItems);
                    _Context.SaveChanges();

                    
                    return RedirectToAction("Index", "ShoppingCarts");
                }
            }

            
            return RedirectToAction("Index", "Home"); 
        }
    }
}
