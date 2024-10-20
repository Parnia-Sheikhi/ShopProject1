using Shop.Domain.Entities;

namespace Shop.Domain.Contract.Repositories
{
    public interface IProductRepository
    {
        /// <summary>
        /// Gets all the products that are exists in db 
        /// </summary>
        /// <returns></returns>
        List<Product> GetAllProducts();

        /// <summary>
        /// Gets all types of categories
        /// </summary>
        /// <returns></returns>
        List<string> GetAllCategories();

        /// <summary>
        /// Gets special page  based on category, pageNumber and pageSize that the user is going to choose
        /// </summary>
        /// <param name="category"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        PagedResult<Product> GetPageData(string category, int pageNumber, int pageSize);

        /// <summary>
        /// Gets the specific product on based on its id 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Product GetById(int productId);

        /// <summary>
        /// Saving product for Admin part
        /// </summary>
        /// <param name="product"></param>
        void SaveProduct(Product product);

        /// <summary>
        /// Deleting product for Admin part
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        Product DeleteProduct(int productID);

        /// <summary>
        /// Finding product for search bar
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        List<Product> Find(string query);

    }
}
