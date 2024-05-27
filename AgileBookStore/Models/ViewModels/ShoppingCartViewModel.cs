using AgileBookStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
namespace AgileBookStore.Models.ViewModels
{
	public class ShoppingCartViewModel
	{
		public int IdShoppingCart { get; set; }
		public Product? Product { get; set; }
		public int Quantity { get; set; }
	}

}
