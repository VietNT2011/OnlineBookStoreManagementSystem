using AgileBookStore.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AgileBookStore.Models
{
    public class Order
    {
        [Required]
        [Key]
        public string OrderId { get; set; } = GenerateOrderId();

        [Required]
        public string? Id { get; set; }
        public AgileBookStoreUser User { get; set; } = new AgileBookStoreUser();
        public string? OrderAddress;

        [Required]
        public List<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();
        public bool IsPaid {  get; set; } = false;
        public bool IsConfirmed { get; set; } = false;

        private static string GenerateOrderId()
        {
            return $"#{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";
        }
    }
}
