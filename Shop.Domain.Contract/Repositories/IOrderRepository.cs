using Shop.Domain.Entities;

namespace Shop.Domain.Contract.Repositories
{
    public interface IOrderRepository
    {

        List<Order> GetList(bool? shipped);

        Order GetById(int orderId);

        void SaveOrder(Order order);

        void SetTransactionId(int orderId, string transId);

        void SetPaymentDone(int transId);


    }
}
