using Shop.Domain.Entities;

namespace ShopProject1.Models
{
    public class HomeViewModel
    {
        public string Category { get; set; }
        public PagedResult<Product> Result { get; set; } = new PagedResult<Product>();
    }
}
