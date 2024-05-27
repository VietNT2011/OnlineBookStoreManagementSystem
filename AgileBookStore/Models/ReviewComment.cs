using System.ComponentModel.DataAnnotations;

namespace AgileBookStore.Models
{
	public class ReviewComment
	{
		[Key] public int Id { get; set; }
		public Product? Product { get; set; }
		public string? UserName { get; set; }
		public string? ImgAvatar { get; set; } = "https://i.pinimg.com/564x/0d/64/98/0d64989794b1a4c9d89bff571d3d5842.jpg";
		public string? email { get; set; }
		[Required] public string? Comment { get; set; }

		[Range(0, 5)]
		public int star { get; set; } = 0;
	}
}
