using AgileBookStore.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace AgileBookStore.Models
{
    public class Wishlist
    {
        [Key]
        public int Id { get; set; }
        public AgileBookStoreUser? User { get; set; } = new AgileBookStoreUser();
        public string? IdUser { get; set; }
        public Product? Product { get; set; }
    }
}
