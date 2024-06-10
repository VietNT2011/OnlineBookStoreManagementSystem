using AgileBookStore.Areas.Identity.Data;
using Humanizer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgileBookStore.Models
{
	public class ShoppingCart
	{
		[Required]
		[Key]
		public int IdShoppingCart { get; set; }
		[Required]
		public string? Id { get; set; }
		public AgileBookStoreUser User { get; set; } = new AgileBookStoreUser();
		[Required]
		public int IdProduct { get; set; }
		public Product? Product { get; set; }
		public int Quantity { get; set; }

		public Decimal Total
		{
			get
			{
				if (Product != null)
				{
					return Product.Price * Quantity;
				}
				return 0;
			}
		}
	}
}
