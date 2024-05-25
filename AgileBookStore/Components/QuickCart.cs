using AgileBookStore.Areas.Identity.Data;
using AgileBookStore.Data;
using AgileBookStore.Models;
using AgileBookStore.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AgileBookStore.Components
{
	public class QuickCart : ViewComponent
	{
		private readonly AgileBookStoreContext _Context;
		private readonly UserManager<AgileBookStoreUser> _userManager;
		public QuickCart(AgileBookStoreContext context, UserManager<AgileBookStoreUser> userManager)
		{
			_Context = context;
			this._userManager = userManager;
		}
		public IViewComponentResult Invoke()
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

	}
}
