using Microsoft.EntityFrameworkCore;
using Shop.Domain.Contract.Repositories;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.EF.Repositories
{
    public class EfOrderRepository : IOrderRepository
    {
        private readonly ApplicationContext _context;
        public EfOrderRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Order GetById(int orderId)
        {
            return _context.Orders.Include(c => c.Lines).ThenInclude(p => p.Product).FirstOrDefault(o => o.OrderID == orderId);
        }

        public List<Order> GetList(bool? shipped)
        {
            return _context.Orders.Where(c => !shipped.HasValue || c.Shipped == shipped.Value).Include(c => c.Lines).ThenInclude(p => p.Product).ToList();
        }

        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderID == 0)
            {
                _context.Orders.Add(order);
            }
            _context.SaveChanges();
        }

        public void SetPaymentDone(int transId)
        {
            var order = _context.Orders.FirstOrDefault(c => c.PaymentId == transId.ToString());
            if (order != null)
            {
                order.PaymentDate = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public void SetTransactionId(int orderId, string transId)
        {
            var order = _context.Orders.Find(orderId);
            if (order != null)
            {
                order.PaymentId = transId;
                _context.SaveChanges();
            }
        }
    }
}
