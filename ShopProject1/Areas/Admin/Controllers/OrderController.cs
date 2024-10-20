using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Contract.Repositories;
using Shop.Domain.Entities;

namespace ShopProject1.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("[controller]/[action]")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public ViewResult NewOrders()
        {
            return View(_orderRepository.GetList(false));
        }

        [HttpPost]
        public IActionResult MarkShipped(int orderID)
        {
            Order order = _orderRepository.GetById(orderID);
            if (order != null)
            {
                order.Shipped = true;
                _orderRepository.SaveOrder(order);
            }
            return RedirectToAction(nameof(NewOrders));
        }

        public IActionResult NewOrderList()
        {
            return View();
        }

    }
}
