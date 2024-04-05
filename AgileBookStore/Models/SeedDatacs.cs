using AgileBookStore.Data;
using AgileBookStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AgileBookStore.Models
{
	public static class SeedData
	{
		public static void EnsurePopulated(IApplicationBuilder app)
		{
			AgileBookStoreContext context = app.ApplicationServices
				.CreateScope()
				.ServiceProvider
				.GetRequiredService<AgileBookStoreContext>();
			if (!context.Database.GetPendingMigrations().Any())
			{
				context.Database.Migrate();
			}
			if (!context.Categories.Any())
			{
				context.Categories.AddRange(
					new Category
					{
						Name = "Fantasy"
					},
					new Category
					{
						Name = "Adventure"
					},
					new Category
					{
						Name = "Mystery"
					},
					new Category
					{
						Name = "Dark"
					},
					new Category
					{
						Name = "Romance"
					},
					new Category
					{
						Name = "School"
					},
					new Category
					{
						Name = "Slice of Life"
					},
					new Category
					{
						Name = "Tragedy"
					},
					new Category
					{
						Name = "Chill"
					},
					new Category
					{
						Name = "Learning"
					},
					new Category
					{
						Name = "Toys"
					},
					new Category
					{
						Name = "Accessory"
					}
					);
				context.SaveChanges();
			}
			if (!context.Products.Any())
			{
				for (int i = 1; i <= 32; i++)
				{
					context.Products.AddRange(
						new Product
						{
							NameProduct = "Lý Thuyết Trò Chơi",
							Price = 100000,
							Categories = context.Categories.Where(c => c.Name == "Fantasy" || c.Name == "Adventure").ToList(),
							Description = "Chúa tể bóng tối đã trỗi dậy, hãy đánh bại ả.",
							imageurl1 = "https://salt.tikicdn.com/cache/750x750/ts/product/8a/b6/ba/1d95b88597f28e42d8ca91e3b3ff600f.jpg.webp",
							imageurl2 = "https://salt.tikicdn.com/cache/750x750/ts/product/aa/43/76/f6c2532e1d8780c763efc27403ddc377.jpg.webp",
							imageurl3 = "https://salt.tikicdn.com/cache/750x750/ts/product/a1/94/b7/843f590d2bcdd9ef7fa028ce54010a40.jpg.webp"
						}
					);
				}
				context.SaveChanges();
			}
		}
	}
}
