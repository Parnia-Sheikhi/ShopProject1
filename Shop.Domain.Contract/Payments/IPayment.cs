using Shop.Domain.Entities;

namespace Shop.Domain.Contract.Payments
{
    public interface IPayment
    {
        PaymentResult pay(string amount);

        VerifyResponse Verify(string transID);
    }
}
