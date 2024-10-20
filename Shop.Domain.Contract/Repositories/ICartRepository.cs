using Shop.Domain.Entities;

namespace Shop.Domain.Contract.Repositories
{
    public interface ICartRepository
    {

        /// <summary>
        /// For adding specific item to CartDatabase
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        void AddItem(Product product, int quantity);

        /// <summary>
        /// For removing specific item from CartDatabase
        /// </summary>
        /// <param name="product"></param>
        void RemoveLine(Product product);

        /// <summary>
        /// For computing the amount of money on based on the price and quantity
        /// </summary>
        /// <returns></returns>
        decimal ComputeTotalValue();

        /// <summary>
        /// Removing all items from your CartDatabase
        /// </summary>
        void Clear();

        Cart GetCart(int userId);

        List<Cart> Lines { get; set; }

    }
}
