using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.DAL.EF;
using Shop.Domain.Contract.Repositories;
using Shop.Domain.Entities;

namespace ShopProject1.Controllers
{
    [Route("[controller]/[action]")]
    public class OrderController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly IOrderRepository _orderRepository;
        

        public OrderController(ICartRepository cart, IOrderRepository orderRepository)
        {
            _cartRepository = cart;
            _orderRepository = orderRepository;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Checkout()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Checkout(Order order) 
        {
            if (_cartRepository.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "امکان ثبت سفارش خالی وجود ندارد");
            }

            if (ModelState.IsValid)
            {
                order.Lines = _cartRepository.Lines.ToArray();
                _orderRepository.SaveOrder(order);
                TempData["OrderID"] = order.OrderID;
                TempData["Price"] = order.Lines.Sum(c => c.Quantity * c.Product.Price);

                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }

        [Authorize]
        public ViewResult Completed()
        {
            _cartRepository.Lines.Clear();
            return View();
        }
    }
}
