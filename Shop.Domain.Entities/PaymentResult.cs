using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class PaymentResult
    {
        public int status { get; set; }
        public string transId { get; set; }
        public double amount { get; set; }
        public string errorCode { get; set; }
        public string errorMessage { get; set; }
        public bool IsCorrect => status == 1;

        public PaymentResult()
        {
        }
    }
}
