using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Domain.Entities
{
    public class Cart
    {
        public List<Cart> lineCollection = new List<Cart>();

        [Key]
        public int CartLineID { get; set; }

        [ForeignKey("ProductID")]
        public Product Product { get; set; }

        public int Quantity { get; set; }

    }
}
