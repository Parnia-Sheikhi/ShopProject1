using Shop.Domain.Contract.Repositories;
using Shop.Domain.Entities;

namespace Shop.DAL.EF.Repositories
{
    public class EfCartRepository : ICartRepository
    {
        private readonly ApplicationContext _context;
        private readonly Cart _cart;

        public List<Cart> Lines { get => _cart.lineCollection; set => _cart.lineCollection.Take(_cart.lineCollection.Count); }

        public EfCartRepository(ApplicationContext context, Cart cart)
        {
            _context = context;
            _cart = cart;
        }
        public Cart GetCart(int userId)
        {
            return _context.ChosenItems.FirstOrDefault(c => c.CartLineID == userId);
        }
        public void AddItem(Product? product, int quantity)
        {
            var line = _context.ChosenItems.Find(product.ProductID);
            if (line == null)
            {
                var obj = new Cart() { Product = product, Quantity = quantity };
                _context.ChosenItems.Add(obj);
                _cart.lineCollection.Add(obj);
                _context.SaveChanges();
            }
            else
            {
                line.Quantity += quantity;
                _context.SaveChanges();
            }
        }

        public void Clear()
        {
            _context.ChosenItems.ToList().Clear();
            _cart.lineCollection.Clear();
            _context.SaveChanges();
        }

        public decimal ComputeTotalValue()
        {
            return _context.ChosenItems.ToList().Sum(e => e.Product.Price * e.Quantity);
        }

        public void RemoveLine(Product product)
        {
            _context.ChosenItems.ToList().RemoveAll(p => p.Product.ProductID == product.ProductID);
            _cart.lineCollection.RemoveAt(product.ProductID);
            _context.SaveChanges();
        }
    }
}
