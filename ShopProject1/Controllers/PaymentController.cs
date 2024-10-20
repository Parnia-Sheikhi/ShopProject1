using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Contract.Payments;
using Shop.Domain.Contract.Repositories;
using ShopProject1.Models;

namespace ShopProject1.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPayment _payment;
        private readonly IOrderRepository _orderRepository;

        public PaymentController(IPayment payment, IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _payment = payment;
        }

        public IActionResult Pay(int orderId, string price)
        {
            var result = _payment.pay(price.ToString());
            if (result.IsCorrect)
            {
                // saving for our order 
                _orderRepository.SetTransactionId(orderId, result.transId);

                // redirecting for the pay page for the paying operation
                return Redirect("https://pay.ir/payment/gateway/" + result.transId);
            }
            return View(result);
        }
        
        public IActionResult Verify(PaymentResponse model)
        {
            if (model.IsCorrect)
            {
                var verifyResult = _payment.Verify(model.transId.ToString());
                if (verifyResult.IsCorrect)
                {
                    _orderRepository.SetPaymentDone(model.transId);
                    return View("PaymentComplete", verifyResult);
                }
            }
            return View(model);
        }
    }
}
