using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Entities
{
    public class Order
    {
        [BindNever]
        [Key]
        public int OrderID { get; set; }
        
        public ICollection<Cart> Lines { get; set; }

        [Required(ErrorMessage = "لطفا اسم خود را وارد کنید")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "لطفا آدرس خود را وارد کنید")]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required(ErrorMessage = "لطفا شهر خود را وارد کنید")]
        [MaxLength(100)]
        public string City { get; set; }

        [Required(ErrorMessage = "لطفا استان خود را وارد کنید")]
        [MaxLength(100)]
        public string State { get; set; }

        [Required(ErrorMessage = "لطفا تلفن همراه خود را وارد کنید")]
        [MaxLength(20)]
        [Phone(ErrorMessage = "شماره تلفن شما باید در فرمت مناسب و درست باشد")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "لطفا کشور خود را وارد کنید")]
        [MaxLength(100)]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
        
        public string PaymentId { get; set; }

        public DateTime? PaymentDate { get; set; }

        public bool Shipped { get; set; }
    }
}
