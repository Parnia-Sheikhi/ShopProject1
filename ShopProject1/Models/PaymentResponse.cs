namespace ShopProject1.Models
{
    public class PaymentResponse
    {
        public int status { get; set; }
        public int transId { get; set; }
        public string factorNumber { get; set; }
        public string cardNumber { get; set; }
        public string message { get; set; }
        public bool IsCorrect => status == 1;
    }
}
