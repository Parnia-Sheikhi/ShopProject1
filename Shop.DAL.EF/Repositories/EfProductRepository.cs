using Shop.Domain.Contract.Repositories;
using Shop.Domain.Entities;

namespace Shop.DAL.EF.Repositories
{
    public class EfProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;
        
        public EfProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Product DeleteProduct(int productID)
        {
            Product? dbEntry = _context.Products.FirstOrDefault(p => p.ProductID == productID);
            if (dbEntry != null)
            {
                _context.Products.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }

        public List<Product> Find(string query)
        {
            return _context.Products.Where(c => c.Name.StartsWith(query)).OrderBy(c => c.Name).Take(10).ToList();
        }

        public List<string> GetAllCategories()
        {
            return _context.Products.Select(p => p.Category).Distinct().ToList();
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int productId)
        {
            return _context.Products.Find(productId);
        }

        public PagedResult<Product> GetPageData(string category, int pageNumber, int pageSize)
        {
            var query = _context.Products.Where(c => string.IsNullOrWhiteSpace(category) || c.Category == category);

            PagedResult<Product> result = new PagedResult<Product>();
            result.PagingData.CurrentPage = pageNumber;
            result.PagingData.ItemsPerPage = pageSize;
            result.PagingData.TotalItems = query.Count();

            result.Items = query.OrderBy(c => c.ProductID).Skip(Math.Max(0, (pageNumber - 1) * pageSize)).Take(pageSize).ToList();

            return result;
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                _context.Products.Add(product);
            }
            else
            {
                Product? dbEntry = _context.Products.FirstOrDefault(p => p.ProductID == product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            _context.SaveChanges();
        }
    }
}
