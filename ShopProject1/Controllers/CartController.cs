using Microsoft.AspNetCore.Mvc;
using Shop.DAL.EF;
using Shop.Domain.Contract.Repositories;
using Shop.Domain.Entities;

namespace ShopProject1.Controllers
{
    [Route("[controller]/[action]")]
    public class CartController : Controller
    {
        private readonly IProductRepository _repository;
        private ICartRepository _cartRepository;
        public CartController(IProductRepository repository, ICartRepository cart)
        {
            _cartRepository = cart;
            _repository = repository;
        }

        public IActionResult Index(string returnUrl)
        {
            List<Cart> model = new List<Cart>();
            model.Add(new Cart() { CartLineID = 1, Quantity = 1, Product = _repository.GetById(1) });
            model.Add(new Cart() { CartLineID = 2, Quantity = 1, Product = _repository.GetById(2) });
            _cartRepository.Lines.Add(new Cart() { CartLineID = 1, Quantity = 1, Product = _repository.GetById(1) });
            return View(model);
        }

        public IActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = _repository.GetById(productId);
            if (product != null)
            {
                _cartRepository.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public IActionResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = _repository.GetById(productId);
            if (product != null)
            {
                _cartRepository.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

    }
}
