using System.ComponentModel.DataAnnotations;

namespace AgileBookStore.Models
{
    public class Product
    {
        [Required]
        [Key]
        public int IdProduct { get; set; }

        [Required(ErrorMessage = "Please enter the product Name.")]
        public string NameProduct { get; set; } = "New Book";

        [Required(ErrorMessage = "Please enter the product Price.")]
        public Decimal Price { get; set; } = 99999;
        [Required(ErrorMessage = "Please enter the valid value.")]
        public string Author { get; set; } = "Anonymous";
        [Required(ErrorMessage = "Please enter the valid value.")]
        public string Publishing { get; set; } = "Anonymous Publisher";
        [Required(ErrorMessage = "Please enter the valid value.")]
        public string Description { get; set; } = "Nothing";
        [Required(ErrorMessage = "Please enter a category")]
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
        public string imageurl1 { get; set; } = "/uploads/pompom1.png";
        public string imageurl2 { get; set; } = "/uploads/pompom2.gif";
        public string imageurl3 { get; set; } = "/uploads/pompom3.gif";
        public int Inventory { get; set; } = 200;
        public string Set { get; set; } = string.Empty;
    }
}
